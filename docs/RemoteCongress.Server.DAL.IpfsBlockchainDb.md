<a name='assembly'></a>
# RemoteCongress.Server.DAL.IpfsBlockchainDb

## Contents

- [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block')
  - [#ctor(previousBlock,content,mediaType)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-#ctor-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block,System-String,RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.#ctor(RemoteCongress.Server.DAL.IpfsBlockchainDb.Block,System.String,RemoteCongress.Common.RemoteCongressMediaType)')
  - [#ctor()](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-#ctor 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.#ctor')
  - [Content](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Content 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Content')
  - [Hash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Hash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Hash')
  - [Id](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Id 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Id')
  - [IsValid](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-IsValid 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.IsValid')
  - [LastBlockHash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-LastBlockHash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.LastBlockHash')
  - [LastBlockId](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-LastBlockId 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.LastBlockId')
  - [MediaType](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-MediaType 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.MediaType')
  - [Timestamp](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Timestamp 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Timestamp')
  - [CreateFromData(id,lastBlockId,timestampUtc,lastBlockHash,content,mediaType,hash)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-CreateFromData-System-String,System-String,System-DateTime,System-String,System-String,RemoteCongress-Common-RemoteCongressMediaType,System-String- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.CreateFromData(System.String,System.String,System.DateTime,System.String,System.String,RemoteCongress.Common.RemoteCongressMediaType,System.String)')
  - [CreateGenisysBlock()](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-CreateGenisysBlock 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.CreateGenisysBlock')
  - [GenerateHash()](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-GenerateHash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.GenerateHash')
- [BlockV1JsonCodec](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization.BlockV1JsonCodec')
  - [CanHandle(mediaType)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-CanHandle-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization.BlockV1JsonCodec.CanHandle(RemoteCongress.Common.RemoteCongressMediaType)')
  - [Decode(mediaType,data)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization.BlockV1JsonCodec.Decode(RemoteCongress.Common.RemoteCongressMediaType,System.IO.Stream)')
  - [Encode(mediaType,data)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-Encode-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Server-DAL-IpfsBlockchainDb-Block- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization.BlockV1JsonCodec.Encode(RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Server.DAL.IpfsBlockchainDb.Block)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization.BlockV1JsonCodec.GetPreferredMediaType')
- [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain')
  - [#ctor(coreApi,config)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-#ctor-Ipfs-CoreApi-ICoreApi,RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.#ctor(Ipfs.CoreApi.ICoreApi,RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig)')
  - [IsValid](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-IsValid 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.IsValid')
  - [AppendToChain(content,mediaType,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-AppendToChain-System-String,RemoteCongress-Common-RemoteCongressMediaType,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.AppendToChain(System.String,RemoteCongress.Common.RemoteCongressMediaType,System.Threading.CancellationToken)')
  - [FetchAllFromChain(query,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.FetchAllFromChain(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [FetchFromChain(id)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FetchFromChain-System-String- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.FetchFromChain(System.String)')
  - [FromBlock(data)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FromBlock-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.FromBlock(RemoteCongress.Server.DAL.IpfsBlockchainDb.Block)')
  - [FromString(data)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FromString-System-String- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.FromString(System.String)')
  - [InitializeIpfs()](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-InitializeIpfs-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.InitializeIpfs(RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig)')
  - [LoadPreviousBlockIntoChain(id,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-LoadPreviousBlockIntoChain-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.LoadPreviousBlockIntoChain(System.String,System.Threading.CancellationToken)')
  - [PersistBlock(block,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-PersistBlock-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.PersistBlock(RemoteCongress.Server.DAL.IpfsBlockchainDb.Block,System.Threading.CancellationToken)')
- [IpfsBlockchainClient](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainClient')
  - [#ctor(coreApi,config,codecs)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-#ctor-Ipfs-CoreApi-ICoreApi,RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}}- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainClient.#ctor(Ipfs.CoreApi.ICoreApi,RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig,System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}})')
  - [AppendToChain(data,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainClient.AppendToChain(RemoteCongress.Common.ISignedData,System.Threading.CancellationToken)')
  - [FetchAllFromChain(query,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainClient.FetchAllFromChain(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [FetchFromChain(id,cancellationToken)](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-FetchFromChain-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainClient.FetchFromChain(System.String,System.Threading.CancellationToken)')
- [IpfsBlockchainConfig](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig')
  - [AbsoluteDataDirectoryPath](#F-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-AbsoluteDataDirectoryPath 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig.AbsoluteDataDirectoryPath')
  - [LastBlockId](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-LastBlockId 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig.LastBlockId')
  - [Password](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-Password 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig.Password')

<a name='T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block'></a>
## Block `type`

##### Namespace

RemoteCongress.Server.DAL.IpfsBlockchainDb

##### Summary

A block POCO inside a [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain').

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-#ctor-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block,System-String,RemoteCongress-Common-RemoteCongressMediaType-'></a>
### #ctor(previousBlock,content,mediaType) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| previousBlock | [RemoteCongress.Server.DAL.IpfsBlockchainDb.Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') | The previous [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') in the [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain'). |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content to be stored in the [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block'). |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of the block. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

##### Remarks

This private constructor is used to generate the Genisys block.

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Content'></a>
### Content `property`

##### Summary

The raw content of the block.

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Hash'></a>
### Hash `property`

##### Summary

The SHA256 hash of the concatinated:
    * [Timestamp](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Timestamp 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Timestamp')
    * [LastBlockHash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-LastBlockHash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.LastBlockHash')
    * [Content](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Content 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Content')

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Id'></a>
### Id `property`

##### Summary

The unique Identifier from the block.

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-IsValid'></a>
### IsValid `property`

##### Summary

An [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') is valid if the [Hash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Hash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Hash') equals the result from [GenerateHash](#M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-GenerateHash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.GenerateHash').

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-LastBlockHash'></a>
### LastBlockHash `property`

##### Summary

The [Hash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Hash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Hash') of the previous [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') in the [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain').

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-LastBlockId'></a>
### LastBlockId `property`

##### Summary

The [Id](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Id 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Id') of the previous [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') in the [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain').

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-MediaType'></a>
### MediaType `property`

##### Summary

media type of [Content](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Content 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Content').

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Timestamp'></a>
### Timestamp `property`

##### Summary

A UTC timestamp for when the block was created.

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-CreateFromData-System-String,System-String,System-DateTime,System-String,System-String,RemoteCongress-Common-RemoteCongressMediaType,System-String-'></a>
### CreateFromData(id,lastBlockId,timestampUtc,lastBlockHash,content,mediaType,hash) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| lastBlockId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| timestampUtc | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| lastBlockHash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') |  |
| hash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-CreateGenisysBlock'></a>
### CreateGenisysBlock() `method`

##### Summary

Logic to generate a root [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block').

##### Returns

A special [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') that can be used as the root of a blockchain.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-GenerateHash'></a>
### GenerateHash() `method`

##### Summary

Generates a Hash based on the block content.

##### Returns

A SHA256 Hash for the current [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') state.

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec'></a>
## BlockV1JsonCodec `type`

##### Namespace

RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block').

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-CanHandle-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### CanHandle(mediaType) `method`

##### Summary

Checks if `mediaType` can be handled by the codec.

##### Returns

True if `mediaType` can be handled.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to check if it can be handled. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream-'></a>
### Decode(mediaType,data) `method`

##### Summary

Decodes a `data` into a [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block').

##### Returns

The [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [System.IO.Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') | The [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') to decode data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-Encode-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-'></a>
### Encode(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Server.DAL.IpfsBlockchainDb.Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') | The data to encode. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Serialization-BlockV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain'></a>
## Blockchain `type`

##### Namespace

RemoteCongress.Server.DAL.IpfsBlockchainDb

##### Summary

A simple proof of concept blockchain implementation that is persisted in Ipfs.

##### Remarks

This is not production ready code. It's fine for a proof of concept, but it needs to be
    updating and to be much better thoughtout before it is really ready to be running
    production level data.

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-#ctor-Ipfs-CoreApi-ICoreApi,RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-'></a>
### #ctor(coreApi,config) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coreApi | [Ipfs.CoreApi.ICoreApi](#T-Ipfs-CoreApi-ICoreApi 'Ipfs.CoreApi.ICoreApi') | The IPFS api interface |
| config | [RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig') | An [IpfsBlockchainConfig](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig') instance to use to configure Ipfs |

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-IsValid'></a>
### IsValid `property`

##### Summary

A [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain') is valid if:
    * Every [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain')'s [IsValid](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-IsValid 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain.IsValid') is true
    * Every [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain')'s [LastBlockHash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-LastBlockHash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.LastBlockHash') matches the
        previous [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain')'s [Hash](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Hash 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Hash').

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-AppendToChain-System-String,RemoteCongress-Common-RemoteCongressMediaType,System-Threading-CancellationToken-'></a>
### AppendToChain(content,mediaType,cancellationToken) `method`

##### Summary

Appends data to the blockchain.

##### Returns

The created [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') that contains `content`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The raw content to append to the blockchain. |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of the block to append. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### FetchAllFromChain(query,cancellationToken) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') |  |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') |  |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FetchFromChain-System-String-'></a>
### FetchFromChain(id) `method`

##### Summary

Fetches a [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') by `id`.

##### Returns

The matching [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block'), or null if it's not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique identifier to look up the [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') by. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FromBlock-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-'></a>
### FromBlock(data) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [RemoteCongress.Server.DAL.IpfsBlockchainDb.Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') |  |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-FromString-System-String-'></a>
### FromString(data) `method`

##### Summary

Generates a [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') from a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-InitializeIpfs-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-'></a>
### InitializeIpfs() `method`

##### Summary

Sets the absolute path for Ipfs, and starts the the ipfs engine.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-LoadPreviousBlockIntoChain-System-String,System-Threading-CancellationToken-'></a>
### LoadPreviousBlockIntoChain(id,cancellationToken) `method`

##### Summary

Loads a [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') into the first position of the [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain') by `id`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The previous [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block')'s [Id](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Id 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Id'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain-PersistBlock-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block,System-Threading-CancellationToken-'></a>
### PersistBlock(block,cancellationToken) `method`

##### Summary

"
Persists a [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') inside the [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain').

##### Returns

The peristed version of `block`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| block | [RemoteCongress.Server.DAL.IpfsBlockchainDb.Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') | The [Block](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block') to persist in the chain |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient'></a>
## IpfsBlockchainClient `type`

##### Namespace

RemoteCongress.Server.DAL.IpfsBlockchainDb

##### Summary

An Ipfs Blockchain implementation of [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient').

##### Remarks

This implementation is also pretty naive. It's really meant for a proof of concept.

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-#ctor-Ipfs-CoreApi-ICoreApi,RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}}-'></a>
### #ctor(coreApi,config,codecs) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coreApi | [Ipfs.CoreApi.ICoreApi](#T-Ipfs-CoreApi-ICoreApi 'Ipfs.CoreApi.ICoreApi') | A [ICoreApi](#T-Ipfs-CoreApi-ICoreApi 'Ipfs.CoreApi.ICoreApi') to use to interact with IPFS |
| config | [RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig 'RemoteCongress.Server.DAL.IpfsBlockchainDb.IpfsBlockchainConfig') | The IPFS configuration data. |
| codecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}') | The [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') to use for [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') data. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `coreApi` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `config` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `codecs` is null. |

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken-'></a>
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

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
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

<a name='M-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainClient-FetchFromChain-System-String,System-Threading-CancellationToken-'></a>
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

<a name='T-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig'></a>
## IpfsBlockchainConfig `type`

##### Namespace

RemoteCongress.Server.DAL.IpfsBlockchainDb

##### Summary

Configuration data for Ipfs

<a name='F-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-AbsoluteDataDirectoryPath'></a>
### AbsoluteDataDirectoryPath `constants`

##### Summary



<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-LastBlockId'></a>
### LastBlockId `property`

##### Summary

The ending [Id](#P-RemoteCongress-Server-DAL-IpfsBlockchainDb-Block-Id 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Block.Id') of the [Blockchain](#T-RemoteCongress-Server-DAL-IpfsBlockchainDb-Blockchain 'RemoteCongress.Server.DAL.IpfsBlockchainDb.Blockchain')

<a name='P-RemoteCongress-Server-DAL-IpfsBlockchainDb-IpfsBlockchainConfig-Password'></a>
### Password `property`

##### Summary

The ipfs node password
