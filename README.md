# PublicVote

A platform for conducting small scale public votes remotely and securely. Specifically with government legislative bodies in mind.

## Current Status

Currently, there is a proof of concept developed that allows clients to:
* Produce signed and immutable data (bills and votes on bills).
* Send that data to a server where it'll remained signed, get verified, and remain in an immutable state.
* Have that data gets persited in an immutable and decentralized storage system so it can't be lost or tampered with.

All of this signed, immutable data can be retreived by clients, and be validated as untampered with on the client side.

With this proof of concept we're able to show a system that'll allow representives who make public votes to do so remotely in a way we can verify their vote, and ensure their vote isn't tampered with.

## Design

This platform was design to ensure we know who is creating data and that the data cannot be tampered with.

This is acomplished by 


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