<a name='assembly'></a>
# RemoteCongress.Server.DAL.InMemory

## Contents

- [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock')
  - [#ctor(previousBlock,content,mediaType)](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-#ctor-RemoteCongress-Server-DAL-InMemory-InMemoryBlock,System-String,RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.#ctor(RemoteCongress.Server.DAL.InMemory.InMemoryBlock,System.String,RemoteCongress.Common.RemoteCongressMediaType)')
  - [#ctor()](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-#ctor 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.#ctor')
  - [Content](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Content 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Content')
  - [Hash](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Hash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Hash')
  - [Id](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Id 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Id')
  - [IsValid](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-IsValid 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.IsValid')
  - [LastBlockHash](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-LastBlockHash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.LastBlockHash')
  - [MediaType](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-MediaType 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.MediaType')
  - [Timestamp](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Timestamp 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Timestamp')
  - [CreateGenisysBlock()](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-CreateGenisysBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.CreateGenisysBlock')
  - [GenerateHash()](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-GenerateHash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.GenerateHash')
- [InMemoryBlockchain](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchain')
  - [#ctor()](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain-#ctor 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchain.#ctor')
  - [GenerateBlock(last,content,mediaType)](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain-GenerateBlock-RemoteCongress-Server-DAL-InMemory-InMemoryBlock,System-String,RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchain.GenerateBlock(RemoteCongress.Server.DAL.InMemory.InMemoryBlock,System.String,RemoteCongress.Common.RemoteCongressMediaType)')
  - [GenerateGenisysBlock()](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain-GenerateGenisysBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchain.GenerateGenisysBlock')
- [InMemoryBlockchainClient](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchainClient')
  - [#ctor(codecs)](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-#ctor-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}}- 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchainClient.#ctor(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}})')
  - [AppendToChain(data,cancellationToken)](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchainClient.AppendToChain(RemoteCongress.Common.ISignedData,System.Threading.CancellationToken)')
  - [FetchAllFromChain(query,cancellationToken)](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchainClient.FetchAllFromChain(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [FetchFromChain(id,cancellationToken)](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-FetchFromChain-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchainClient.FetchFromChain(System.String,System.Threading.CancellationToken)')

<a name='T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock'></a>
## InMemoryBlock `type`

##### Namespace

RemoteCongress.Server.DAL.InMemory

##### Summary

A simple class to exist as a block inside a blockchain.

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-#ctor-RemoteCongress-Server-DAL-InMemory-InMemoryBlock,System-String,RemoteCongress-Common-RemoteCongressMediaType-'></a>
### #ctor(previousBlock,content,mediaType) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| previousBlock | [RemoteCongress.Server.DAL.InMemory.InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') | The previous [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') in the [InMemoryBlockchain](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchain'). |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content to be stored in the [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock'). |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of the block. |

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

##### Remarks

This private constructor is used to generate the Genisys block.

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Content'></a>
### Content `property`

##### Summary

The raw content of the block.

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Hash'></a>
### Hash `property`

##### Summary

The SHA256 hash of the concatinated:
    * [Id](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Id 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Id')
    * [Timestamp](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Timestamp 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Timestamp')
    * [LastBlockHash](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-LastBlockHash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.LastBlockHash')
    * [Content](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Content 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Content')

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Id'></a>
### Id `property`

##### Summary

The unique Identifier from the block.

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-IsValid'></a>
### IsValid `property`

##### Summary

An [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') is valid if the [Hash](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Hash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Hash') equals the result from [GenerateHash](#M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-GenerateHash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.GenerateHash').

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-LastBlockHash'></a>
### LastBlockHash `property`

##### Summary

The [Hash](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Hash 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Hash') of the previous [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') in the [InMemoryBlockchain](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain 'RemoteCongress.Server.DAL.InMemory.InMemoryBlockchain').

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-MediaType'></a>
### MediaType `property`

##### Summary

The MediaType of [Content](#P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Content 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock.Content').

<a name='P-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-Timestamp'></a>
### Timestamp `property`

##### Summary

A UTC timestamp for when the block was created.

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-CreateGenisysBlock'></a>
### CreateGenisysBlock() `method`

##### Summary

Logic to generate a root [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock').

##### Returns

A special [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') that can be used as the root of a blockchain.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlock-GenerateHash'></a>
### GenerateHash() `method`

##### Summary

Generates a Hash based on the block content.

##### Returns

A SHA256 Hash for the current [InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') state.

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain'></a>
## InMemoryBlockchain `type`

##### Namespace

RemoteCongress.Server.DAL.InMemory

##### Summary

A simple proof of concept in memory blockchain implementation.

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain-GenerateBlock-RemoteCongress-Server-DAL-InMemory-InMemoryBlock,System-String,RemoteCongress-Common-RemoteCongressMediaType-'></a>
### GenerateBlock(last,content,mediaType) `method`

##### Summary

Creates a new block

##### Returns

The created block

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| last | [RemoteCongress.Server.DAL.InMemory.InMemoryBlock](#T-RemoteCongress-Server-DAL-InMemory-InMemoryBlock 'RemoteCongress.Server.DAL.InMemory.InMemoryBlock') | The previous block |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content of the block |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The mediatype of the block content |

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchain-GenerateGenisysBlock'></a>
### GenerateGenisysBlock() `method`

##### Summary

Creates a genisys block

##### Returns

The genisys block

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient'></a>
## InMemoryBlockchainClient `type`

##### Namespace

RemoteCongress.Server.DAL.InMemory

##### Summary

An In Memory implementation of [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient') for testing.

##### Remarks

This data store is not distributed, and since it's in memory it's also not immutable.
    It is only useful for testing code and validating the layers above this.
    It should not be used for a production version.

    This implementation is also pretty naive. It's really only useful for development testing.

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-#ctor-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}}-'></a>
### #ctor(codecs) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}') | The [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') to use for [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') data. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `codecs` is null. |

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken-'></a>
### AppendToChain(data,cancellationToken) `method`

##### Summary

Creates a new block containing the verified content in `data` in the blockchain.

##### Returns

The unique id of the stored block.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [RemoteCongress.Common.ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') | The signed and verified data structure to store in the blockchain. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### FetchAllFromChain(query,cancellationToken) `method`

##### Summary

Fetches all matching verified data in the form of [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') from the blockchain.

##### Returns

An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance containing the block data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | The query to pull data by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Server-DAL-InMemory-InMemoryBlockchainClient-FetchFromChain-System-String,System-Threading-CancellationToken-'></a>
### FetchFromChain(id,cancellationToken) `method`

##### Summary

Fetches the verified data in the form of [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') from the blockchain by block id.

##### Returns

An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance containing the block data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique block id to pull verified data from. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |
