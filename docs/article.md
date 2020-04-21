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

To ensure when a vote is cast it's coming from who it claims to be cast by we can use [Asymmetric Encryption](https://en.wikipedia.org/wiki/Public-key_cryptography). Asymmetric Encryption will allow our system to have the members of congress digitally sign votes using two seperate keys. 
The member of congress will have a device that contains two complicated keys. One that is known publicly which can be used to identify the member of congress, and a private key never leaves their device, and never travels on a network. These two keys are a pair that are related.
The private key only exists on their device to generate a "signature". The signature is basically an encrypted value that is generated using the private key.
The signature can only be decrypted using the publicly known key. So, if you know a congress member's public key, you can decrypt the signature of a vote to ensure it's signed by the private key. Thus, ensuring the member of congress generate the vote.

***IMAGES***

In addition to knowing that the vote originated from a specific congress member we also need to ensure that the vote data hasn't been altered by someone else. To ensure that we'll use a [Hash Function](https://en.wikipedia.org/wiki/Hash_function). It's a one way mathematical formula that given the same data will always produce the same result. However, if you alter the data slightly the result of the hash function will be different.
So, we can generate a hash of the digital content of a member's vote, and keep track of the hash. If the member's vote ever doesn't match the hash we know that something was changed.
One issue is that anyone can generate the hash of the vote data. So we can't just blindly attach that hash to the vote. If someone is able to alter the vote data they could easily just generate the new hash value, and alter that as well.
However, if we encrypt the hash with the congress member's private key when they create the vote and use that as a signature we can create a hash that cannot be altered by anyone but the member of congress, and anyone can decrypt it by using the public key. Since that signature also contains the hash of the vote data we can then verify the vote data is unaltered by regenerating the hash of that data and comparing it to hash we pulled from the encrypted signature.

***IMAGES***

Finally, we need to ensure once the vote is placed that it never gets lost or modified. If you're familiar with the concept of Bitcoin there is a technology that Bitcoin runs on top of that fits this need. It's called [Blockchain](https://en.wikipedia.org/wiki/Blockchain), and in our solution for remote congress voting we'll be storing votes made by members of congress in a Blockchain.
We're doing that for a few reasons, but the biggest reason is that the data stored in a Blockchain is immutable and distributed. ***Add Blockchain description***

***IMAGES***

## Describe the proof of concept that has been built

With those three design concepts I've setup [a proof of concept system](https://www.github.com/nathanmentley) that can track votes, ensure the content is valid, untampered with, and comes from who it claims.

The project has a two parts:

1. A client application that mimics what each member of congress would run on a network connected device. That tool will generate votes, sign them with a private key, and publish them.
1. There is a decentralized server that the client app will publish votes to, this server will validate the votes, and store them in an immutable blockchain data store. 

The server isn't centralized. Since we're using a distributed blockchain there can be as many server instance running, 

# Explain the next steps

## What needs to be built still
## What conversation needs to be had
## A call to action or some kind