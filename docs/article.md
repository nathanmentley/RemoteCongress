**This is currently an unedited and unformatted brain dump.**

# Building a system that'll allow Congress to vote remotely

![blockchain-3750157_1920](/assets/blockchain-article-header.jpg)

*During the Covid19 pandemic it's become clear that Congress isn't able to fully function some extreme situations like this, and their inability to hold votes with easy and agility right now is downright terrifying. Here's how we can setup a system for them to securely hold votes remotely.*

**By [Nathan Mentley](https://www.github.com/nathanmentley)**

While the entire nation, or atleast those privilaged enough to be able to, are currently trying to self isolate, and stay in place to slow the spread of Covid19 our Congress is required to meet in person to keep our nation functioning. While Speaker Pelosi released a letter on April 6th outling new protocols to reduce face to face interaction of members of the House Of Representatives, members are still required to vote in person. The Senate has made pretty much zero progress.

With an average age of nearly 62 in the US Senate and 58 in the House Of Representatives we're putting the leaders of our nation, and a critical group that's required to push forward nation saving legislation at risk. Our government is currently at an unacceptable risk of becoming dysfunction. If the coronavirus was able to spread to enough members of the Senate or the House Of Represenatives we will have no way to react to the rapidly changing world that the COVID-19 pandemic has caused. It's critical at this time we setup a system to enable congress to work fully remotely. Including allowing members of congress to vote remotely.

Luckily, we actually already have proven solutions to make remote voting for groups like Congress secure, and transparent. Unfortunately, these solutions heavily rely on technology and computer science concepts. Which is something our Congress has shown it has a [pretty low level of understand of](https://mashable.com/article/google-hearing-congress-no-idea-about-internet-search/). In this article I'll attempt to explain the design of an open source proof of concept remote voting system I've [built](https://github.com/nathanmentley/RemoteCongress). I'll then explain in non-techincal language how the technologies used in the proof of concept will keep this system secure.

#### The Problems Faced

The most obvious challenge to overcome when designing a remote voting system for a body like congress is that you want to know you're able to trust the results of the vote. In other words, we don't want people to be able to alter votes taking place in Congress, or place votes as if they're someone their not.

There are three key points we need to make sure we cover in our design of this remote voting system in order to be confident in the vote's result.

1. If a Senator or Representative is voting remotely we want to be sure that the vote came from the member of congress, and nobody else.
1. We need to know that the way the member of congress voted hasn't been changed in any way when they're voting.
1. Finally, we need to make sure that historical voting data cannot be changed, and remains in an immutable state.

We can use some proven technology to design a system that meets those three needs.

#### Technologies We'll Use To Solve Those Problems

To ensure when a vote is cast it's coming from who it claims to be cast by we can use [Asymmetric Encryption](https://en.wikipedia.org/wiki/Public-key_cryptography). Asymmetric Encryption will allow our system to have votes be digitally signed.

The member of congress will have a device that contains two complicated keys. One that is known publicly which can be used to identify the member of congress, and a private key never leaves their device, and never travels on a network. These two keys are a pair that are related. A message produced with one can be read using the other.

The private key only exists on their device to generate a "signature" to attach to a vote being placed.

The signature can only be decrypted using the publicly known key. So, if you know a congress member's public key, you can decrypt the signature of a vote to ensure it's signed by the private key. Thus, ensuring the member of congress generate the vote.

However, there are are two obviously weaknesses here.
1. What if someone was able to guess the private key of a member of congress?
1. What if the device the congress member uses to vote that contains their private key is stolen?

The first case, someone guessing a private key, is techincally possible, but is absurdly improbable. The odds of guessing a 256-bit private key, like what is used in bitcoin and what could be used here, are:

1 to 115,792,089,237,316,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000.

If you didn't catch it, there are alot of zeros there.

Additionally, the estimated energy usage to guess these private keys is absurd. In [Applied Cryptography](https://amazon.com/dp/0471117099) by Bruce Schneier there is an attempt to calculate it. I don't want to give any spoilers, but it involves a [Dyson Sphere](https://en.wikipedia.org/wiki/Dyson_sphere), and collecting all the enegery output from the sun for a few decades. Needless to say, it's probably not likely.

Still, if the device a member of congress votes with, and has their private key gets stolen we'd still have a problem.

So, First, We'd need our congressional leaders to be responsible, and do their best to prevent that from happening. However if that were to happen, we could easily just have that member setup a new device, generate a new public/private key pair, and inform everyone of their new public key, and from that point forward just care about votes coming from the member's new key pair.
It's at most a hassle, and something that is easily resolvable. We just have to know votes for Rep. XYZ before some date come from their old public key, and after from their new.

Asymetric Encryption has kept things like bitcoin wallets safe for years, and will make sure we can track who would be placing votes in this system.

***IMAGES***

In addition to knowing that the vote originated from a specific congress member we also need to ensure that the vote data hasn't been altered by someone else.

Hypothetically, if a member of congress was submitting a vote from their device, and sending it to some system over a network, that vote could be intercepted and alterned by someone in the middle. That's what's called a [man in the middle attack](https://en.wikipedia.org/wiki/Man-in-the-middle_attack). We'll protected our system against that by using a [Hash Function](https://en.wikipedia.org/wiki/Hash_function). Specifically [SHA-256](https://en.wikipedia.org/wiki/SHA-2).

It's a [one way mathematical formula](https://crypto.stackexchange.com/a/45390) that given the same data will always produce the same result. However, if you alter the data slightly the result of the hash function will be different.

So, we can generate a hash of the digital content of a member's vote, and keep track of the hash. If the member's vote ever doesn't match the hash we know that something was changed.

Let's say a vote's data looked like this:

```
{
    billId: "Should we expand medicare to all us residents?",
    opinion: "Yes",
    reason: "Healthcare is a human right"
}
```
A hash of that might look like this:

```
eaf64a87da9213212653ec81aebfd645e6eb755f6a27465c689fa984881dedd0
```

If someone was intercepting this data and altering it before sending it to the destination they might change it to this:

```
{
    billId: "Should we expand medicare to all us residents?",
    opinion: "No",
    reason: "Healthcare is not a human right"
}
```
However, the hash for that data is this:
```
08c8414e9cc9cc9f117d1d4cacf1ecb38043a7437ae8ddaee15b41650a368c4b
```

If we knew the vote was suppose to have a hash of ```eaf64a87da9213212653ec81aebfd645e6eb755f6a27465c689fa984881dedd0```, but that didn't match the content we'd know the vote was tampered with.

So, we could pass the has with the vote. Like this:

```
{
    billId: "Should we expand medicare to all us residents?",
    opinion: "Yes",
    reason: "Healthcare is a human right",
    _hash: "eaf64a87da9213212653ec81aebfd645e6eb755f6a27465c689fa984881dedd0"
}
```

One issue is that anyone can generate the hash of the vote data. That's important because we want to be able to verify the hash. So we can't just blindly attach that hash to the vote like that. If someone was hypothetically able to alter the vote data they could easily just generate the new hash value for the alteration, and replace the attached real vote hash value with their new vote's hash value.

However, if we were to encrypt the hash with the congress member's Asymetric Encryption private key, like were talking about for a signature above, then we'd know that the hash came from the specific member. We could still decrypt that hash using the known public key for that member, and then use the decrypted hash to ensure it matches the content of the vote.

Attaching an Encrypted Hash to a vote will allow us to be sure that the vote hasn't been altered.

***IMAGES***

Finally, we need to ensure once the vote is placed that it never gets lost or modified. If you're familiar with the concept of Bitcoin there is a technology that Bitcoin runs on top of that fits this need. It's called [Blockchain](https://en.wikipedia.org/wiki/Blockchain), and in our solution for remote congress voting we'll be storing votes made by members of congress in a Blockchain.

An important feature of blockchain is that the data stored it becomes [immutable](https://en.wikipedia.org/wiki/Immutable_object). Meaning that the after creation the state and content cannot be altered. So once the data is stored it becomes permanent and the content cannot be changed.

This is possible because a blockchain is stored in a decentralized manner. Instead of a single server or a single organization owning and being responsible for maintaining the data 




***IMAGES***

## Describe the proof of concept that has been built

With those three design concepts I've setup [a proof of concept system](https://www.github.com/nathanmentley) that can track votes, ensure the content is valid, untampered with, and comes from who it claims.

The project has a two parts:

1. A client application that mimics what each member of congress would run on a network connected device. That tool will generate votes, sign them with a private key, and publish them.
1. There is a decentralized server that the client app will publish votes to, this server will validate the votes, and store them in an immutable blockchain data store. 

***DIAGRAM***


# Explain the next steps
