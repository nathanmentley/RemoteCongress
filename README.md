# RemoteCongress

A platform for conducting small scale public voting remotely and securely.

## Goal

This project was started as a result of the Covid19 pandemic and the United States Congress' inability to hold remote votes.

We have proven technology that allows safe, transparent, public votes to be held remotely, and there is currently no execuse for a nation to be forcing it's government to meet in person during a pandemic to remain functional at this critical time.

This project aims to build a simple proof of concept system that shows a working functional and safe system for holding remote votes. Ultimately this proof of concept will hopefully start conversation on how we modernize our government's ability to function at the most critical times.

## Current Status

Currently, this is a technical proof of concept that allows individuals to:
* Produce signed and immutable data (bills and votes on bills).
* Send that data to a server where it'll remained signed, get verified, and remain in an immutable state.
* Have that data persited in an immutable and decentralized storage system so it can't be lost or tampered with.
* Pull any stored bills or votes, and ensure they're valid, and untampered with.

With this proof of concept we're able to show a system that'll allow representives who cast votes publicly to do so remotely, and that anyone is able to verify the cast votes, and ensure they aren't tampered with.

## Design

This platform was designed to ensure we know who is creating data and that the data cannot be tampered with.

At a high level this is acomplished by using an immutable and decentralized data storage built on a [blockchain](https://en.wikipedia.org/wiki/Blockchain) saved in [IPFS](https://ipfs.io/), and asymmetric encryption to sign and verify votes. 

The current design of this platform would give every member of congress a [public private key pair](https://en.wikipedia.org/wiki/Public-key_cryptography).
The member's public key would be publicly known while their private key would never be shared or sent over any network. You can think of the public key almost as the member's username.

When the member of congress votes, the data that makes up their vote will be signed with an encrypted [hash](https://en.wikipedia.org/wiki/Hash_function) generated from the vote data, and then encrytped with the private key. This vote data is then packaged with the member's public key, and the encrypted hash. That package is sent to the server to be stored and persisted. It's persisted in a blockchain stored on Ipfs to ensure the data is immutable.

Using the public key we can decrypt the hash, and verify that hash still matches the vote data. If the hash still matches the vote data we can know that the vote wasn't tampered with, and was cast by the private key that matches the public key shipped with the vote. In other words, we can be sure the member of congress cast that vote, and their vote wasn't altered.

## Running the Proof Of Concept

If you want to see the proof of concept in action you'll need some software installed to run it, and the ability to run a few terminal commands.

To run the platform you currently need these installed:
* [git](https://git-scm.com/)
* [docker](https://www.docker.com/)
* [docker compose](https://docs.docker.com/compose/)

### Quick Start

Using a terminal:

1. Clone the git repository:

    git clone https://github.com/nathanmentley/RemoteCongress.git

2. Changed directories into the newly cloned git repo.

    cd RemoteCongress

3. Build and spin up the RemoteCongress server:

    docker-compose up -d

4. Run the example script to run some test data through the system.

    docker run --entrypoint /app/RemoteCongress.Example --net=host remote-congress/api

This will run a simple example test that will:
* Create votes and bills
* Sign them
* Send them over the network to the server to persist them in the immutable storage. (in this proof of concept the server is storing the signed content in a blockchain built on top of IPFS to ensure immutability)
* Load the saved votes and bills from the api server
* Finally, verify that the stored votes and bills are valid, and untampered with.

You should see an output that looks something like this:

    created bill[0c455768-e900-43a6-970b-f4a271cc7b27] {
      "title": "title",
      "content": "content"
    }

    fetched bill[0c455768-e900-43a6-970b-f4a271cc7b27] {
      "title": "title",
      "content": "content"
    } Signed And Verified

    created vote[4477b671-8f82-48a6-b260-f2bd993a946d] {
      "billId": "0c455768-e900-43a6-970b-f4a271cc7b27",
      "opinion": true,
      "message": "message"
    }

    fetched vote[4477b671-8f82-48a6-b260-f2bd993a946d] {
      "billId": "0c455768-e900-43a6-970b-f4a271cc7b27",
      "opinion": true,
      "message": "message"
    } Signed And Verified

That shows a bill was submitted with the title: "title", and the content: "content".
After submission that vote was fetched from the platform and was verified.

Then then a yes vote was cast on the bill with a message of "message".
After that vote was cast it was fetched from the platform and was verified.

### Using a cli interface to interact with the platform

Optionally, if you want to interact with the RemoteCongress platform in a more dynamic way you can use a command line tool included with the project.

There is a [dotnet core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) command line tool under the src/RemoteCongress.CliTool directory that can be compiled and used to cast votes, submit bills, fetch saved votes, and fetch saved bills. This tool can use what ever public / private key pair you supply. Example keys are in the keys directory of this git repo.

#### cli tool examples

Creating a new bill:

    dotnet run --project src/RemoteCongress.CliTool/RemoteCongress.CliTool.csproj submit-bill --key keys/example --title "Title of new bill" --content "The content of the new bill."

Voting on a bill:

    dotnet run --project src/RemoteCongress.CliTool/RemoteCongress.CliTool.csproj cast-vote --key keys/example --billId QmXJ7Zwpr2S6rbRb2wSMU6pAhWjU7RH7HHiykgWzWd4bdA --opinion False --message "Some short reason on why a vote was cast the way it was"

Viewing a bill:

    dotnet run --project src/RemoteCongress.CliTool/RemoteCongress.CliTool.csproj view-bill --id QmXJ7Zwpr2S6rbRb2wSMU6pAhWjU7RH7HHiykgWzWd4bdA

Viewing a vote:

    dotnet run --project src/RemoteCongress.CliTool/RemoteCongress.CliTool.csproj view-vote --id QmPnfkTnEYxVotRHtCLS4g3q4otAmAYKvtbtKbWZ34brXF

### Using RemoteCongress.Client to programmically interact with the platform

You can use the client assembly project to build tools in any .net language to fetch and create votes using this platform using code.

Right now there isn't much documentation outside of code, but for an example you should be able to look at:
    src/RemoteCongress.Example/Program.cs

You can also view the library source code in:
    src/RemoteCongress.Client/

## Next Steps

This is a proof of concept, and the code is not production ready, and isn't suitable to be used a core of a more built out system in it's current state.

A true system shouldn't be thrown together over a few weekends.
It shouldn't reivent the wheel as much as this project has done.
It should have more error handling and testing code than the almost nonexistent amount in this codebase.

This code could possible be used a base to built out those changes, but ultimately building a system like that is premature when the united states congress still hasn't made any real progress to move to a remote environment. If we really want to ensure our government is able to exist during real emergencies we need to urge change.