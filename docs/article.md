**This is currently an unedited and unformatted brain dump.**

## Building a Remote Voting Platform for Congress

![blockchain-3750157_1920](/assets/blockchain-article-header.jpg)

*During the Covid19 pandemic it's become clear that Congress isn't able to fully function during extreme situations like this, and their inability to hold votes with easy and agility right now is downright terrifying. Here's how we can setup a system for them to securely hold votes remotely.*

**By [Nathan Mentley](https://www.github.com/nathanmentley)**

While the entire nation, or atleast those privilaged enough to be able to, are currently trying to self isolate, and stay in place to slow the spread of Covid19 our Congress is required to meet in person to keep our nation functioning. While the House Of Representatives recently voted on temporary rule changes to allow for "remote voting", members are still required to send a person as a proxy to vote in their place. The Senate has made pretty much zero progress. As of today, neither body can hold a vote remotely, and work with the agility we'd expect it to during a crisis like this.

Forcing this in person contact is placing our government in an unacceptable risk of becoming dysfunctional. If the coronavirus was able to spread to enough members of the Senate or the House Of Represenatives we will have no way to react to the rapidly changing world that the COVID-19 pandemic has caused. As of now, if there is any dramatic need to pass something with agility our government cannot react the way we should expect it to.
It's critical at this time we setup a system to enable congress to work fully remotely. Including allowing members of congress to vote remotely. Not just for the Covid19 crisis, but for any future crisis as well.

Luckily, we actually already have proven solutions to make remote voting for groups like Congress secure, and transparent. In this article I'll attempt to explain the security hurdles we'll need to overcome to build a system like this, and how the design of an open source proof of concept remote voting system I've [built](https://github.com/nathanmentley/RemoteCongress) overcomes those hurdles.

### The Problems Faced

The most obvious challenge to overcome when designing a remote voting system for a body like congress is that you want to know you're able to trust the results of the vote. In other words, we don't want people to be able to alter votes taking place in Congress, or placing votes as if they're someone their not.

There are three key points we need to make sure we cover in our design of this remote voting system in order to be confident in the vote's result.

1. If a Senator or Representative is voting remotely we want to be sure that the vote came from the member of congress, and nobody else.
1. We need to know that the way the member of congress voted hasn't been tampered with or altered.
1. Finally, we need to make sure that historical voting data cannot be changed or removed. It must remain in an immutable state.

We can use some proven technology to design a system that meets those three needs.

### Technologies We'll Use To Solve Those Problems

#### How can we trust who sent the vote?

***IMAGE?***

To ensure when a vote is cast it's coming from who it claims to be cast by we can use [Asymmetric Encryption](https://en.wikipedia.org/wiki/Public-key_cryptography). Asymmetric Encryption will allow our system to have members of congress digitially sign votes in a way that's unique to each member, and can only be produced by the individual.

The member of congress will have a device that contains two complicated key files on it. One that is known publicly which can be used to identify the member of congress, and a private key that never leaves their device, never travels on a network, and is only ever known by the member of congress. These two keys are a pair that are related. An encrypted message produced with either one of the keys can only be decrypted using the other.
This means, if you want a message that can only be read by the member of congress you can encrypt it with their public key. Since only their private key can only decrypt it, they are the only person who can read it.
If you want to know a message came from the member of congress you can have them encrypt it with the private key, and everyone can decrypt it using the public key to be sure it came originally from them.

In our platform we'll be using the member of congresses private key to generate an encrypted signature with their vote when they cast it. Since we would all know the member's public key, we are able to decrypt the signature with that key, and verify the vote originated with the member of congress the signature claims.

Asymetric Encryption has kept things like bitcoin wallets safe for years, and will make sure we can track who would be placing votes in this system.

#### How can we trust the vote isn't modified?

***IMAGE?***

In addition to knowing that the vote originated from a specific congress member we also need to ensure that the vote data hasn't been altered by someone else.

Hypothetically, if a member of congress was submitting a vote from their device, and sending it to some system over a network, that vote could be intercepted and alterned by someone in the middle. That is called a [man in the middle attack](https://en.wikipedia.org/wiki/Man-in-the-middle_attack). We'll protected our system against that by using a [Hash Function](https://en.wikipedia.org/wiki/Hash_function). Specifically [SHA-256](https://en.wikipedia.org/wiki/SHA-2).

It's a [one way mathematical formula](https://crypto.stackexchange.com/a/45390) that given the same data will always produce the same result. However, if you alter the data slightly the result of the hash function will be different. 

So, we can generate a hash of the digital content of a member's vote, and keep track of the hash. If the member's vote ever doesn't match the hash we know that something was changed, and that the vote is invalid.

Let's say a vote's data looked like this:

```json
{
    billId: "Should we expand medicare to all us residents?",
    opinion: "Yes",
    reason: "Healthcare is a human right"
}
```
A hash of that might look like this: `eaf64a87da9213212653ec81aebfd645e6eb755f6a27465c689fa984881dedd0`

If someone was intercepting this data and altering it before sending it to the destination they might change it to this:

```json
{
    billId: "Should we expand medicare to all us residents?",
    opinion: "No",
    reason: "We should protect corporations instead of people"
}
```
However, the hash for that data is this: `d7f1f0e051ec7b9429a97247e6ed0db5df0c5647cb41924551188e3f7c2c134f`

If we knew the vote was suppose to have a hash of `eaf64a87da9213212653ec81aebfd645e6eb755f6a27465c689fa984881dedd0`, but that didn't match the content we'd know the vote was tampered with, and we could throw out the vote, and probably spit out some warning.

So, we could pass the has with the vote. Like this:

```json
{
    billId: "Should we expand medicare to all us residents?",
    opinion: "Yes",
    reason: "Healthcare is a human right",
    _hash: "eaf64a87da9213212653ec81aebfd645e6eb755f6a27465c689fa984881dedd0"
}
```

One issue is that anyone can generate the hash of the vote data. That's important because we want to be able to verify the hash against the content. So we can't just blindly attach that hash to the vote like that. If someone was hypothetically able to alter the vote data they could easily just generate the new hash value for the alteration, and replace the attached real vote hash value with their new vote's hash value.

However, if we were to encrypt the hash with the congress member's Asymetric Encryption private key, like were talking about for a signature above, then we'd know that the hash came from the specific member, and that it wasn't generated by anyone else. We could still decrypt that hash using the known public key for that member, and then use the decrypted hash to ensure it matches the content of the vote. This encrypted hash would then become their signature, and their public key would become something that could be used almost like their username. We could pull all votes using that public key to see how a specific memeber voted.

Ultimately the vote data will end up looking like this:

```json
{
    //the unique id of the bill being voted on
    billId: "Should we expand medicare to all us residents?",
    //the way the member of congress voted
    opinion: "Yes",
    //their rationale behind their vote
    reason: "Healthcare is a human right",
    //the public key of the congress member, we can use this almost as their username
    publicKey: "MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkwkwMRyHisc6diIMoNAgMBAAE=",
    //an encrypted hash we can use to validate and trust their vote
    _encryptedHash: "GBcZoGyCJOtgQ/Cq8Y8UjOwAQInUYbHhGxSU7b+QBE+cKSsyDBJPwaJqqhnQnm/m7cf1tXaem4gj1t3/hGwHCPAyAse6ecRlvqkxgFSWfQqaWu7wZ7tgHvSI6h+aEjqbeMgqKXEYiaoCRI17HmHqpxtlQAx37O5HbBKnZtcseG0="
}
```

Attaching this encrypted hash would mean we could not only trust the source of the data is the congress memeber it's claiming to be from, but also that the data hasn't be altered.


#### Can we trust

***IMAGE?***

Finally, we need to ensure once the vote is placed that it never gets lost or modified.

With what we went over we know that members of congress can generate and send data securely, but we haven't talked about how we'd store that data securely. In a traditional system there would a server running somewhere with a database, and if that were to be attacked a hacker could alter the data stored in that database.
Since we're signing and using hashes on our data we would still be able to detect that tampering, but it's still problematic because it could result in the loss or corruption of data that we couldn't resolve.

To prevent that we'll be taking a less traditional approach to storing our data. If you're familiar with the concept of Bitcoin there is a technology that Bitcoin runs on top of that fits this need. It's called [Blockchain](https://en.wikipedia.org/wiki/Blockchain), and in our solution for remote congress voting we'll be storing votes made by members of congress in a Blockchain.

An important feature of blockchain is that the data stored in it becomes [immutable](https://en.wikipedia.org/wiki/Immutable_object). Meaning that the after creation the state and content cannot be altered. So once the data is stored it becomes permanent and the content cannot be changed.

Blockchain achieves this by doing two things. Storing the data in a decentralized manner, meaning we'd store the data on multiple servers spread out geographically, and storing the data in an ordered listed of records with two hashes that ensure order and content.

In our blockchain each record would store:
1. A single vote for our system
1. A hash value of the record in the blockchain preceeding it
1. A hash value for itself that is built from the vote content, and the previous record's hash.

An example block in our chain might look like this:

```json
{
    //our vote data from before
    data: {
        //the unique id of the bill being voted on
        billId: "Should we expand medicare to all us residents?",
        //the way the member of congress voted
        opinion: "Yes",
        //their rationale behind their vote
        reason: "Healthcare is a human right",
        //the public key of the congress member, we can use this almost as their username
        publicKey: "MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkwkwMRyHisc6diIMoNAgMBAAE=",
        //an encrypted hash we can use to trust their vote
        _encryptedHash: "GBcZoGyCJOtgQ/Cq8Y8UjOwAQInUYbHhGxSU7b+QBE+cKSsyDBJPwaJqqhnQnm/m7cf1tXaem4gj1t3/hGwHCPAyAse6ecRlvqkxgFSWfQqaWu7wZ7tgHvSI6h+aEjqbeMgqKXEYiaoCRI17HmHqpxtlQAx37O5HbBKnZtcseG0="
    },
    //the hash value of the previous record in the block chain
    previousHash: "d7f1f0e051ec7b9429a97247e6ed0db5df0c5647cb41924551188e3f7c2c134f",
    //the hash build from both the vote data and the previousHash value
    hash: "29a17cc4aa01fd7be2b3f22f73b79e3ef41fc1f0361f459aec8c0b61d53cf581"
}
```

By storing the data in a decentralized structure and replicated, meaning multiple servers spread out geographically, we can prevent a hacker from destroying our data by attacking a single point of failure. Additionally, since we'd be able detect when the data is tampered with in one server because of hashes and signing we could know instantely which servers storiing the data should be ignored and rebuilt.

We can even take this a step farther. Since the data is secure once created, and should be public knowledge we can actually allow anyone to setup servers to host replicated data on this blockchain. That's how systems like Bitcoin operate. The public shared knowlege of the data prevents the alteration of it by bad actors. 

***IMAGES***

### Describe the proof of concept that has been built

With those three design concepts I've setup [a proof of concept system](https://www.github.com/nathanmentley) that can track votes, ensure the content is valid, untampered with, and comes from who it claims.

The project has a two parts:

1. A client application that mimics what each member of congress would run on a network connected device. That tool will generate votes, sign them with a private key, and publish them.
1. There is a decentralized server that the client app will publish votes to, this server will validate the votes, and store them in an immutable blockchain data store. 

***DIAGRAM***


### Explain the next steps
