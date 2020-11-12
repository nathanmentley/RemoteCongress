# DataSeeder tool

Currently the tool is hardcoded to seed US senate data.

1. It'll generate private / public key pairs for each senator.
2. Seed member blocks for each one in the blockchain.
3. Seed each bill.
4. Seed each vote on each bill using the voting senator's key pair.

Once seeded you can hit the api and fetch immutable verified voting data that is signed by the key of each senator who cast that vote.


## TODO
* This code needs a lot of documenting
* There should be more abstractions made to easily support other data sources.
* IDataProviders should be loadable using a plugin system.