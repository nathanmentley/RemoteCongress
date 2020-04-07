# RemoteCongress

A platform for conducting small scale public voting remotely and securely.

## Goal

This project was started as a result of the Covid19 pandemic and the United States Congress' inability to hold remote votes.

We have proven technology that allows safe, transparent, Remote Congresss to be held remotely, and there is currently no execuse for a nation to be forcing it's government to meet in person during a pandemic to remain functional at this critical time.

This project aims to build a simple proof of concept system that shows a working functional and safe system for holding remote votes. Ultimately this proof of concept will hopefully start conversation on how we modernize our government's ability to function at the most critical times.

## Current Status

Currently, this is a technical proof of concept that allows individuals to:
* Produce signed and immutable data (bills and votes on bills).
* Send that data to a server where it'll remained signed, get verified, and remain in an immutable state.
* Have that data persited in an immutable and decentralized storage system so it can't be lost or tampered with.

All of this signed, immutable data can be retreived by anyone, and be validated by anyone.
Using this signed validated data we can know that a specific person voted a specific way, and we can know that data hasn't been altered.

With this proof of concept we're able to show a system that'll allow representives who make Remote Congresss to do so remotely in a way we can verify their vote, and ensure their vote isn't tampered with.

## Design

This platform was design to ensure we know who is creating data and that the data cannot be tampered with.

At a high level this is acomplished by using immutable and decentralized data storage, and asymmetric encryption to sign data. These concepts are extremely similar to the core ideas of blockchain, and in a non proof of concept state this project would be using a true blockchain to store data instead of using Ipfs.

The current design of this platform would give every member of congress a [public private key pair](https://en.wikipedia.org/wiki/Public-key_cryptography).
The member's public key would be publically known while their private key would never be shared or sent over any network.

When the member of congress votes, the data that makes up their vote will be signed with a hash generated from their private key and the vote data. This vote data is then packaged with the member's public key, and the signed hash. That package is sent to the server to be stored and persisted.

Using the public key we can tell who made the vote, since ever member of congress' public key is public.

Using the Hash and the public key we can verify that the voting data hasn't be changed, and it truely came from the owner of the public key's private pair. This gives us a high level of confidence who made the vote, and the vote is being recorded correctly.


## Startup

If you want to see the proof of concept in action you'll need some software installed to run it.


To run the platform you currently need these installed:
    Docker
    Docker Compose
    dotnet sdk 3.0

Quick Start:
In a terminal session cd to the git root directory run:

    docker-compose up

This will spin up an instance of Ipfs. Which we'll use for decentralized immutable data storage.


In another terminal session cd to the git root and run:

    dotnet run --project src/PublicApi.Server.Web/PublicApi.Server.Web.csproj

This will run the Api Server we'll use to connect to Ipfs.


In another terminal session cd to the git root and run:

    dotnet run --project src/PublicApi.CliTool/PublicApi.CliTool.csproj

This will run a simple command line tool that'll connect to our api server.



After running the final command you'll see that command line tool will connect to the api project and generate immutable bills and votes. The created bill and vote are immutable, and have a signature and public key attached to them that can be used to prove the that they were created by a specific individual attached to the private / public key pair.