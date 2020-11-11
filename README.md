# RemoteCongress ![Build Status](https://github.com/nathanmentley/RemoteCongress/workflows/Build%20Status/badge.svg?branch=master)

A proof of concept platform for conducting small scale public voting remotely and securely.

## Goal

This project was started as a result of the Covid19 pandemic and the United States Congress' inability to hold remote votes.

We have proven technology that allows safe, transparent, public votes to be held remotely, and there is currently no excuse for a nation to be forcing it's government to meet in person during a pandemic to remain functional at this critical time.

This project aims to build a simple proof of concept system that shows a working functional and safe system for holding remote votes. Ultimately this proof of concept will hopefully start conversation on how we modernize our government's ability to function at the most critical times.

## Current Status

Currently, this is a technical proof of concept that allows individuals to:
* Produce signed and immutable data (bills and votes on bills).
* Send that data to a server where it'll remained signed, get verified, and remain in an immutable state.
* Have that data persisted in an immutable and decentralized storage system so it can't be lost or tampered with.
* Pull any stored bills or votes, and ensure they're valid, and untampered with.

With this proof of concept we're able to show a system that'll allow representatives who cast votes publicly to do so remotely, and that anyone is able to verify the cast votes, and ensure they aren't tampered with.

## Design

This platform was designed to ensure we know who is creating data and that the data cannot be tampered with.

At a high level this is accomplished by using an immutable and decentralized data storage built on a [blockchain](https://en.wikipedia.org/wiki/Blockchain) saved in [IPFS](https://ipfs.io/), and asymmetric encryption to sign and verify votes. 

The current design of this platform would give every member of congress a [public private key pair](https://en.wikipedia.org/wiki/Public-key_cryptography).
The member's public key would be publicly known while their private key would never be shared or sent over any network. You can think of the public key almost as the member's username.

When the member of congress votes, the data that makes up their vote will be signed with a [hash](https://en.wikipedia.org/wiki/Hash_function) generated from the vote data, and then encrypted with the private key. This vote data is then packaged with the member's public key, and the encrypted hash. That package is sent to the server to be stored and persisted. It's persisted in a blockchain stored on Ipfs to ensure the data is immutable.

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

4. Run the example app to run some test data through the system.

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

### Data Seeder

There is a data seeder tool that can be used to load real senate voting data from the second session of the 116th congress.

Once there is a server running, either locally or in docker, you can run the dataloader tool located at src/RemoteCongress.Server.DataSeeder

    dotnet run --project src/RemoteCongress.Server.DataSeeder/RemoteCongress.Server.DataSeeder.csproj

The data seeder will parse included xml files to generate public private key pairs for each senator, then it'll post bill and vote data using the RemoteCongress.Client library.

Once run you should be able to use the api to search through votes and bills. All the persisted data is immutable, signed and verified. The data you receive back from the api is signed and can be verified with the packaged hash, and public key.

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
    examples/RemoteCongress.Example/Program.cs

You can also view the library source code in:
    src/RemoteCongress.Client/

### Loading Real Data

There is a DataSeeder project. It's currently setup to seed data from the current us senate session.

It'll generate a key pair for each senator, seed member blocks that define that in the block chain. Those keys will then be used to seed blocks for each bill, and blocks for each vote cast by each senator.

Each vote will be signed with the key for the respective senator who cast the vote.

### Querying Data

There are endpoints for members, bills, and votes

    /member

    /bill

    /vote

You can fetch a single member, bill, or vote by passing an id when making a GET request.

    /{endpoint}/{id}

You can also request a collection of members, bills, or votes by making a GET request by not passing an ID.

You can also query that data by passing a query parameter. For example, to fetch all yes votes for a specific bill you could make a GET request to:

    localhost:8000/vote?query={'_type': 'billId', 'billId': '9843575c-accf-4f3a-b0a3-ca08ec2193ee'}&query={'_type': 'opinion', 'opinion': true}

Finally, You to get data back the server requires you to pass in a valid mediatype in the accept header.

If you're fetching a single block you should pass a media type like one of these:

    application/json; structure=remotecongress.signeddata; version=1

    application/avro; structure=remotecongress.signeddata; version=1

If you're fetching a collection you'll want to use a media type like this:

    application/json; structure=remotecongress.signeddatacollection; version=1




## Next Steps

This is a proof of concept, and the code is not production ready, and isn't suitable to be used a core of a more built out system in it's current state.

A true system shouldn't be thrown together over a few weekends, it shouldn't reinvent the wheel as much as this project has done, and it should have more error handling and testing code than the almost nonexistent amount in this codebase.

This code could possibly be used as a base to built out those changes, but first we'll need congress and the american public to understand how a system like this would function, what makes it secure, and why it's essential in or out of a crisis.
