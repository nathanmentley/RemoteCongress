<a name='assembly'></a>
# RemoteCongress.Client.DAL.Http

## Contents

- [ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig')
  - [#ctor(protocol,serverHostName)](#M-RemoteCongress-Client-DAL-Http-ClientConfig-#ctor-System-String,System-String- 'RemoteCongress.Client.DAL.Http.ClientConfig.#ctor(System.String,System.String)')
  - [Protocol](#P-RemoteCongress-Client-DAL-Http-ClientConfig-Protocol 'RemoteCongress.Client.DAL.Http.ClientConfig.Protocol')
  - [ServerHostName](#P-RemoteCongress-Client-DAL-Http-ClientConfig-ServerHostName 'RemoteCongress.Client.DAL.Http.ClientConfig.ServerHostName')
- [HttpDataClient](#T-RemoteCongress-Client-DAL-Http-HttpDataClient 'RemoteCongress.Client.DAL.Http.HttpDataClient')
  - [#ctor(logger,config,httpClient,queryCodec,codecs,collectionCodecs,endpoint)](#M-RemoteCongress-Client-DAL-Http-HttpDataClient-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-DAL-Http-HttpDataClient},RemoteCongress-Client-DAL-Http-ClientConfig,System-Net-Http-HttpClient,RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Repositories-Queries-IQuery},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}}},System-String- 'RemoteCongress.Client.DAL.Http.HttpDataClient.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.DAL.Http.HttpDataClient},RemoteCongress.Client.DAL.Http.ClientConfig,System.Net.Http.HttpClient,RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Repositories.Queries.IQuery},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}},System.String)')
  - [AppendToChain(data,cancellationToken)](#M-RemoteCongress-Client-DAL-Http-HttpDataClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken- 'RemoteCongress.Client.DAL.Http.HttpDataClient.AppendToChain(RemoteCongress.Common.ISignedData,System.Threading.CancellationToken)')
  - [FetchAllFromChain(queries,cancellationToken)](#M-RemoteCongress-Client-DAL-Http-HttpDataClient-FetchAllFromChain-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.DAL.Http.HttpDataClient.FetchAllFromChain(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [FetchFromChain(id,cancellationToken)](#M-RemoteCongress-Client-DAL-Http-HttpDataClient-FetchFromChain-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.DAL.Http.HttpDataClient.FetchFromChain(System.String,System.Threading.CancellationToken)')
  - [GetSignedDataCollectionForMediaType(mediaType)](#M-RemoteCongress-Client-DAL-Http-HttpDataClient-GetSignedDataCollectionForMediaType-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Client.DAL.Http.HttpDataClient.GetSignedDataCollectionForMediaType(RemoteCongress.Common.RemoteCongressMediaType)')
  - [GetSignedDataForMediaType(mediaType)](#M-RemoteCongress-Client-DAL-Http-HttpDataClient-GetSignedDataForMediaType-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Client.DAL.Http.HttpDataClient.GetSignedDataForMediaType(RemoteCongress.Common.RemoteCongressMediaType)')

<a name='T-RemoteCongress-Client-DAL-Http-ClientConfig'></a>
## ClientConfig `type`

##### Namespace

RemoteCongress.Client.DAL.Http

##### Summary

Configuration data defining how to connect to the RemoteCongress api server.

<a name='M-RemoteCongress-Client-DAL-Http-ClientConfig-#ctor-System-String,System-String-'></a>
### #ctor(protocol,serverHostName) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| protocol | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The protocol to connect to the server with. Example: http or https |
| serverHostName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The hostname of the server running the RemoteCongress Api |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `protocol` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `serverHostName` is null. |

<a name='P-RemoteCongress-Client-DAL-Http-ClientConfig-Protocol'></a>
### Protocol `property`

##### Summary

Protocol to use to connect to the Api.

<a name='P-RemoteCongress-Client-DAL-Http-ClientConfig-ServerHostName'></a>
### ServerHostName `property`

##### Summary

The hostname of the server running the RemoteCongress Api

<a name='T-RemoteCongress-Client-DAL-Http-HttpDataClient'></a>
## HttpDataClient `type`

##### Namespace

RemoteCongress.Client.DAL.Http

##### Summary

An [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient') that operates over http.

<a name='M-RemoteCongress-Client-DAL-Http-HttpDataClient-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-DAL-Http-HttpDataClient},RemoteCongress-Client-DAL-Http-ClientConfig,System-Net-Http-HttpClient,RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Repositories-Queries-IQuery},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}}},System-String-'></a>
### #ctor(logger,config,httpClient,queryCodec,codecs,collectionCodecs,endpoint) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.DAL.Http.HttpDataClient}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-DAL-Http-HttpDataClient} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.DAL.Http.HttpDataClient}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |
| config | [RemoteCongress.Client.DAL.Http.ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') | A [ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') instance that holds configuration data on connecting to the server. |
| httpClient | [System.Net.Http.HttpClient](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpClient 'System.Net.Http.HttpClient') | A [HttpClient](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpClient 'System.Net.Http.HttpClient') instance to use to communicate with the server. |
| queryCodec | [RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Repositories.Queries.IQuery}](#T-RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Repositories-Queries-IQuery} 'RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Repositories.Queries.IQuery}') | A [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') instance to use. |
| codecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}') | An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData'). |
| collectionCodecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}}') | An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a collection of [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData')s. |
| endpoint | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The endpoint to this client should hit. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `config` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `httpClient` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `queryCodec` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `codecs` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `collectionCodecs` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `endpoint` is null. |

<a name='M-RemoteCongress-Client-DAL-Http-HttpDataClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken-'></a>
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

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is cancelled. |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.MediaType') doesn't have a registered [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1'). |

<a name='M-RemoteCongress-Client-DAL-Http-HttpDataClient-FetchAllFromChain-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### FetchAllFromChain(queries,cancellationToken) `method`

##### Summary

Fetches all matching verified data in the form of [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') from the blockchain.

##### Returns

An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance containing the block data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| queries | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The query to pull data by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `queries` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is cancelled. |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec.MediaType') doesn't have a registered [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1'). |

<a name='M-RemoteCongress-Client-DAL-Http-HttpDataClient-FetchFromChain-System-String,System-Threading-CancellationToken-'></a>
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

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is cancelled. |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.MediaType') doesn't have a registered [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1'). |

<a name='M-RemoteCongress-Client-DAL-Http-HttpDataClient-GetSignedDataCollectionForMediaType-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### GetSignedDataCollectionForMediaType(mediaType) `method`

##### Summary

Fetches the codec for a collection data for a mediatype

##### Returns

The codec

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The media type to fetch a collection codec for |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if `mediaType` doesn't have a registered [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1'). |

<a name='M-RemoteCongress-Client-DAL-Http-HttpDataClient-GetSignedDataForMediaType-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### GetSignedDataForMediaType(mediaType) `method`

##### Summary

Fetches the codec for a mediatype

##### Returns

The codec

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The media type to fetch a codec for |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if `mediaType` doesn't have a registered [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1'). |
