<a name='assembly'></a>
# RemoteCongress.Server.DAL.Blockchain

## Contents

- [BaseBlock](#T-RemoteCongress-Server-DAL-Blockchain-BaseBlock 'RemoteCongress.Server.DAL.Blockchain.BaseBlock')
  - [Id](#P-RemoteCongress-Server-DAL-Blockchain-BaseBlock-Id 'RemoteCongress.Server.DAL.Blockchain.BaseBlock.Id')
  - [IsValid](#P-RemoteCongress-Server-DAL-Blockchain-BaseBlock-IsValid 'RemoteCongress.Server.DAL.Blockchain.BaseBlock.IsValid')
- [BaseBlockchain\`1](#T-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1')
  - [#ctor()](#M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-#ctor 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.#ctor')
  - [_blocks](#F-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-_blocks 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1._blocks')
  - [IsValid](#P-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-IsValid 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.IsValid')
  - [AppendToChain(content,mediaType)](#M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-AppendToChain-System-String,RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.AppendToChain(System.String,RemoteCongress.Common.RemoteCongressMediaType)')
  - [FetchAllFromChain(query,cancellationToken)](#M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.FetchAllFromChain(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [FetchFromChain(id)](#M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-FetchFromChain-System-String- 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.FetchFromChain(System.String)')
  - [GenerateBlock(last,content,mediaType)](#M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-GenerateBlock-`0,System-String,RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.GenerateBlock(`0,System.String,RemoteCongress.Common.RemoteCongressMediaType)')
  - [GenerateGenisysBlock()](#M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-GenerateGenisysBlock 'RemoteCongress.Server.DAL.Blockchain.BaseBlockchain`1.GenerateGenisysBlock')

<a name='T-RemoteCongress-Server-DAL-Blockchain-BaseBlock'></a>
## BaseBlock `type`

##### Namespace

RemoteCongress.Server.DAL.Blockchain

##### Summary

A base model for a blockchain block

<a name='P-RemoteCongress-Server-DAL-Blockchain-BaseBlock-Id'></a>
### Id `property`

##### Summary

The id of the block.

<a name='P-RemoteCongress-Server-DAL-Blockchain-BaseBlock-IsValid'></a>
### IsValid `property`

##### Summary

Is the block valid

<a name='T-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1'></a>
## BaseBlockchain\`1 `type`

##### Namespace

RemoteCongress.Server.DAL.Blockchain

##### Summary

A base blockchain class

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBlock | The block model stored in the blockchain |

<a name='M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='F-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-_blocks'></a>
### _blocks `constants`

##### Summary

The in memory collection of blocks in the chain.

<a name='P-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-IsValid'></a>
### IsValid `property`

##### Summary

A `TBlock` is valid if:

<a name='M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-AppendToChain-System-String,RemoteCongress-Common-RemoteCongressMediaType-'></a>
### AppendToChain(content,mediaType) `method`

##### Summary

Appends data to the blockchain.

##### Returns

The created `TBlock` that contains `content`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The raw content to append to the blockchain. |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of the block to append. |

<a name='M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### FetchAllFromChain(query,cancellationToken) `method`

##### Summary

Fetches all matching blocks from the chain

##### Returns

The matching blocks from the chain

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of queries to match each block on. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A token to handle cancellation |

<a name='M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-FetchFromChain-System-String-'></a>
### FetchFromChain(id) `method`

##### Summary

Fetches a `TBlock` by `id`.

##### Returns

The matching `TBlock`, or null if it's not found.
///

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique identifier to look up the `TBlock` by. |

<a name='M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-GenerateBlock-`0,System-String,RemoteCongress-Common-RemoteCongressMediaType-'></a>
### GenerateBlock(last,content,mediaType) `method`

##### Summary

Creates a new block

##### Returns

The created block

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| last | [\`0](#T-`0 '`0') | The previous block |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The block content |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The mediatype of the block |

<a name='M-RemoteCongress-Server-DAL-Blockchain-BaseBlockchain`1-GenerateGenisysBlock'></a>
### GenerateGenisysBlock() `method`

##### Summary

Creates a genisys block.

##### Returns

The genisys block

##### Parameters

This method has no parameters.
