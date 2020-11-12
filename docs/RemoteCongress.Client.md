<a name='assembly'></a>
# RemoteCongress.Client

## Contents

- [ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig')
  - [#ctor(protocol,serverHostName)](#M-RemoteCongress-Client-ClientConfig-#ctor-System-String,System-String- 'RemoteCongress.Client.ClientConfig.#ctor(System.String,System.String)')
  - [Protocol](#P-RemoteCongress-Client-ClientConfig-Protocol 'RemoteCongress.Client.ClientConfig.Protocol')
  - [ServerHostName](#P-RemoteCongress-Client-ClientConfig-ServerHostName 'RemoteCongress.Client.ClientConfig.ServerHostName')
- [EndpointClient\`1](#T-RemoteCongress-Client-EndpointClient`1 'RemoteCongress.Client.EndpointClient`1')
  - [_codecs](#F-RemoteCongress-Client-EndpointClient`1-_codecs 'RemoteCongress.Client.EndpointClient`1._codecs')
  - [_logger](#F-RemoteCongress-Client-EndpointClient`1-_logger 'RemoteCongress.Client.EndpointClient`1._logger')
  - [_repository](#F-RemoteCongress-Client-EndpointClient`1-_repository 'RemoteCongress.Client.EndpointClient`1._repository')
  - [Create(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-EndpointClient`1-Create-System-String,System-String,`0,System-Threading-CancellationToken- 'RemoteCongress.Client.EndpointClient`1.Create(System.String,System.String,`0,System.Threading.CancellationToken)')
  - [Get(id,cancellationToken)](#M-RemoteCongress-Client-EndpointClient`1-Get-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.EndpointClient`1.Get(System.String,System.Threading.CancellationToken)')
  - [Get(query,cancellationToken)](#M-RemoteCongress-Client-EndpointClient`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.EndpointClient`1.Get(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Client-EndpointClient`1-GetPreferredMediaType 'RemoteCongress.Client.EndpointClient`1.GetPreferredMediaType')
  - [GetTModelCodec(mediaType)](#M-RemoteCongress-Client-EndpointClient`1-GetTModelCodec-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Client.EndpointClient`1.GetTModelCodec(RemoteCongress.Common.RemoteCongressMediaType)')
- [HttpDataClient](#T-RemoteCongress-Client-HttpDataClient 'RemoteCongress.Client.HttpDataClient')
  - [FetchFromChain(id,cancellationToken)](#M-RemoteCongress-Client-HttpDataClient-FetchFromChain-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.HttpDataClient.FetchFromChain(System.String,System.Threading.CancellationToken)')
  - [GetSignedDataCollectionForMediaType(mediaType)](#M-RemoteCongress-Client-HttpDataClient-GetSignedDataCollectionForMediaType-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Client.HttpDataClient.GetSignedDataCollectionForMediaType(RemoteCongress.Common.RemoteCongressMediaType)')
  - [GetSignedDataForMediaType(mediaType)](#M-RemoteCongress-Client-HttpDataClient-GetSignedDataForMediaType-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Client.HttpDataClient.GetSignedDataForMediaType(RemoteCongress.Common.RemoteCongressMediaType)')
- [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1')
  - [Create(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IEndpointClient`1-Create-System-String,System-String,`0,System-Threading-CancellationToken- 'RemoteCongress.Client.IEndpointClient`1.Create(System.String,System.String,`0,System.Threading.CancellationToken)')
  - [Get(id,cancellationToken)](#M-RemoteCongress-Client-IEndpointClient`1-Get-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IEndpointClient`1.Get(System.String,System.Threading.CancellationToken)')
  - [Get(query,cancellationToken)](#M-RemoteCongress-Client-IEndpointClient`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IEndpointClient`1.Get(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient')
  - [CreateBill(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-CreateBill-System-String,System-String,RemoteCongress-Common-Bill,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.CreateBill(System.String,System.String,RemoteCongress.Common.Bill,System.Threading.CancellationToken)')
  - [CreateMember(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-CreateMember-System-String,System-String,RemoteCongress-Common-Member,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.CreateMember(System.String,System.String,RemoteCongress.Common.Member,System.Threading.CancellationToken)')
  - [CreateVote(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-CreateVote-System-String,System-String,RemoteCongress-Common-Vote,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.CreateVote(System.String,System.String,RemoteCongress.Common.Vote,System.Threading.CancellationToken)')
  - [GetBill(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetBill-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetBill(System.String,System.Threading.CancellationToken)')
  - [GetBills(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetBills-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetBills(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetMember(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetMember-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetMember(System.String,System.Threading.CancellationToken)')
  - [GetMembers(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetMembers-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetMembers(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetVote(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetVote-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetVote(System.String,System.Threading.CancellationToken)')
  - [GetVotes(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetVotes-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetVotes(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [IServiceCollectionExtensions](#T-RemoteCongress-Client-IServiceCollectionExtensions 'RemoteCongress.Client.IServiceCollectionExtensions')
  - [BillEndpoint](#F-RemoteCongress-Client-IServiceCollectionExtensions-BillEndpoint 'RemoteCongress.Client.IServiceCollectionExtensions.BillEndpoint')
  - [MemberEndpoint](#F-RemoteCongress-Client-IServiceCollectionExtensions-MemberEndpoint 'RemoteCongress.Client.IServiceCollectionExtensions.MemberEndpoint')
  - [VoteEndpoint](#F-RemoteCongress-Client-IServiceCollectionExtensions-VoteEndpoint 'RemoteCongress.Client.IServiceCollectionExtensions.VoteEndpoint')
  - [AddBillClient(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddBillClient-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddBillClient(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddCodecs(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddCodecs-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddCodecs(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddHttpClient(collection,client)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddHttpClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-ClientConfig- 'RemoteCongress.Client.IServiceCollectionExtensions.AddHttpClient(Microsoft.Extensions.DependencyInjection.IServiceCollection,RemoteCongress.Client.ClientConfig)')
  - [AddMemberClient(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddMemberClient-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddMemberClient(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddRemoteCongressClient(collection,client)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddRemoteCongressClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-ClientConfig- 'RemoteCongress.Client.IServiceCollectionExtensions.AddRemoteCongressClient(Microsoft.Extensions.DependencyInjection.IServiceCollection,RemoteCongress.Client.ClientConfig)')
  - [AddVoteClient(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddVoteClient-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddVoteClient(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
- [RemoteCongressClient](#T-RemoteCongress-Client-RemoteCongressClient 'RemoteCongress.Client.RemoteCongressClient')
  - [#ctor(billClient,memberClient,voteClient)](#M-RemoteCongress-Client-RemoteCongressClient-#ctor-RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Bill},RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Member},RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Vote}- 'RemoteCongress.Client.RemoteCongressClient.#ctor(RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Bill},RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Member},RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Vote})')
  - [_billClient](#F-RemoteCongress-Client-RemoteCongressClient-_billClient 'RemoteCongress.Client.RemoteCongressClient._billClient')
  - [_memberClient](#F-RemoteCongress-Client-RemoteCongressClient-_memberClient 'RemoteCongress.Client.RemoteCongressClient._memberClient')
  - [_voteClient](#F-RemoteCongress-Client-RemoteCongressClient-_voteClient 'RemoteCongress.Client.RemoteCongressClient._voteClient')
  - [CreateBill(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-CreateBill-System-String,System-String,RemoteCongress-Common-Bill,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.CreateBill(System.String,System.String,RemoteCongress.Common.Bill,System.Threading.CancellationToken)')
  - [CreateMember(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-CreateMember-System-String,System-String,RemoteCongress-Common-Member,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.CreateMember(System.String,System.String,RemoteCongress.Common.Member,System.Threading.CancellationToken)')
  - [CreateVote(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-CreateVote-System-String,System-String,RemoteCongress-Common-Vote,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.CreateVote(System.String,System.String,RemoteCongress.Common.Vote,System.Threading.CancellationToken)')
  - [GetBill(id,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetBill-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetBill(System.String,System.Threading.CancellationToken)')
  - [GetBills(query,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetBills-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetBills(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetMember(id,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetMember-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetMember(System.String,System.Threading.CancellationToken)')
  - [GetMembers(query,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetMembers-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetMembers(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetVote(id,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetVote-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetVote(System.String,System.Threading.CancellationToken)')
  - [GetVotes(query,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetVotes-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetVotes(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')

<a name='T-RemoteCongress-Client-ClientConfig'></a>
## ClientConfig `type`

##### Namespace

RemoteCongress.Client

##### Summary

Configuration data defining how to connect to the RemoteCongress api server.

<a name='M-RemoteCongress-Client-ClientConfig-#ctor-System-String,System-String-'></a>
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

<a name='P-RemoteCongress-Client-ClientConfig-Protocol'></a>
### Protocol `property`

##### Summary

Protocol to use to connect to the Api.

<a name='P-RemoteCongress-Client-ClientConfig-ServerHostName'></a>
### ServerHostName `property`

##### Summary

The hostname of the server running the RemoteCongress Api

<a name='T-RemoteCongress-Client-EndpointClient`1'></a>
## EndpointClient\`1 `type`

##### Namespace

RemoteCongress.Client

##### Summary

A client used to interact an endpoint of the api.

<a name='F-RemoteCongress-Client-EndpointClient`1-_codecs'></a>
### _codecs `constants`

##### Summary

A collection of codecs to endode and decode data.

<a name='F-RemoteCongress-Client-EndpointClient`1-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against.

<a name='F-RemoteCongress-Client-EndpointClient`1-_repository'></a>
### _repository `constants`

##### Summary

A repository to interact with data.

<a name='M-RemoteCongress-Client-EndpointClient`1-Create-System-String,System-String,`0,System-Threading-CancellationToken-'></a>
### Create(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [](#!-TModel 'TModel') instance.

##### Returns

The persisted [](#!-TModel 'TModel').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [](#!-TModel 'TModel'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [](#!-TModel 'TModel') to
    the producing individual. |
| data | [\`0](#T-`0 '`0') | The [](#!-TModel 'TModel') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `privateKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `publicKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is null. |

<a name='M-RemoteCongress-Client-EndpointClient`1-Get-System-String,System-Threading-CancellationToken-'></a>
### Get(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [](#!-TModel 'TModel') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [](#!-TModel 'TModel').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [](#!-TModel 'TModel'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `id` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is null. |

<a name='M-RemoteCongress-Client-EndpointClient`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### Get(query,cancellationToken) `method`

##### Summary

Fetches a collection of signed, and verified [](#!-TModel 'TModel')s by `query`.

##### Returns

A collection of persisted [](#!-TModel 'TModel') that matches `query`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter [](#!-TModel 'TModel') by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `query` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is null. |

<a name='M-RemoteCongress-Client-EndpointClient`1-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the primary media type for the client.

##### Returns

The primary media type.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Client-EndpointClient`1-GetTModelCodec-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### GetTModelCodec(mediaType) `method`

##### Summary

Fetches the codec for a media type.

##### Returns

The codec.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The media type to find a codec for |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if a codec could not be found for the media type. |

<a name='T-RemoteCongress-Client-HttpDataClient'></a>
## HttpDataClient `type`

##### Namespace

RemoteCongress.Client

##### Summary

An [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient') that operates over http.

<a name='M-RemoteCongress-Client-HttpDataClient-FetchFromChain-System-String,System-Threading-CancellationToken-'></a>
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
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.MediaType') doesn't have a registered [](#!-ICodec 'ICodec'). |

<a name='M-RemoteCongress-Client-HttpDataClient-GetSignedDataCollectionForMediaType-RemoteCongress-Common-RemoteCongressMediaType-'></a>
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
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if `mediaType` doesn't have a registered [](#!-ICodec 'ICodec'). |

<a name='M-RemoteCongress-Client-HttpDataClient-GetSignedDataForMediaType-RemoteCongress-Common-RemoteCongressMediaType-'></a>
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
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if `mediaType` doesn't have a registered [](#!-ICodec 'ICodec'). |

<a name='T-RemoteCongress-Client-IEndpointClient`1'></a>
## IEndpointClient\`1 `type`

##### Namespace

RemoteCongress.Client

##### Summary

An interface for a client used to interact an endpoint of the api.

<a name='M-RemoteCongress-Client-IEndpointClient`1-Create-System-String,System-String,`0,System-Threading-CancellationToken-'></a>
### Create(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [](#!-TModel 'TModel') instance.

##### Returns

The persisted [](#!-TModel 'TModel').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [](#!-TModel 'TModel'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [](#!-TModel 'TModel') to
    the producing individual. |
| data | [\`0](#T-`0 '`0') | The [](#!-TModel 'TModel') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IEndpointClient`1-Get-System-String,System-Threading-CancellationToken-'></a>
### Get(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [](#!-TModel 'TModel') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [](#!-TModel 'TModel').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [](#!-TModel 'TModel'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IEndpointClient`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### Get(query,cancellationToken) `method`

##### Summary

Fetches a collection of signed, and verified [](#!-TModel 'TModel')s by `query`.

##### Returns

A collection of persisted [](#!-TModel 'TModel') that matches `query`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter [](#!-TModel 'TModel') by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='T-RemoteCongress-Client-IRemoteCongressClient'></a>
## IRemoteCongressClient `type`

##### Namespace

RemoteCongress.Client

##### Summary

An interface that defines a client for communicating with the RemoteCongress Api Server

<a name='M-RemoteCongress-Client-IRemoteCongressClient-CreateBill-System-String,System-String,RemoteCongress-Common-Bill,System-Threading-CancellationToken-'></a>
### CreateBill(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') instance.

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to
    the producing individual. |
| data | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') | The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-CreateMember-System-String,System-String,RemoteCongress-Common-Member,System-Threading-CancellationToken-'></a>
### CreateMember(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') instance.

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') to
    the producing individual. |
| data | [RemoteCongress.Common.Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') | The [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-CreateVote-System-String,System-String,RemoteCongress-Common-Vote,System-Threading-CancellationToken-'></a>
### CreateVote(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') instance.

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') to
    the producing individual. |
| data | [RemoteCongress.Common.Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') | The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-GetBill-System-String,System-Threading-CancellationToken-'></a>
### GetBill(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-GetBills-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### GetBills(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-GetMember-System-String,System-Threading-CancellationToken-'></a>
### GetMember(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-GetMembers-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### GetMembers(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-GetVote-System-String,System-Threading-CancellationToken-'></a>
### GetVote(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-IRemoteCongressClient-GetVotes-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### GetVotes(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='T-RemoteCongress-Client-IServiceCollectionExtensions'></a>
## IServiceCollectionExtensions `type`

##### Namespace

RemoteCongress.Client

##### Summary

Extension methods for [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection').

<a name='F-RemoteCongress-Client-IServiceCollectionExtensions-BillEndpoint'></a>
### BillEndpoint `constants`

##### Summary

Endpoint for interacting with bills.

<a name='F-RemoteCongress-Client-IServiceCollectionExtensions-MemberEndpoint'></a>
### MemberEndpoint `constants`

##### Summary

Endpoint for interacting with members.

<a name='F-RemoteCongress-Client-IServiceCollectionExtensions-VoteEndpoint'></a>
### VoteEndpoint `constants`

##### Summary

Endpoint for interacting with votes.

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddBillClient-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddBillClient(collection) `method`

##### Summary

Registers a [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1') implementation.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddCodecs-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddCodecs(collection) `method`

##### Summary

Registers all supported [](#!-ICodec 'ICodec')s.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddHttpClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-ClientConfig-'></a>
### AddHttpClient(collection,client) `method`

##### Summary

Registers a [HttpClient](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpClient 'System.Net.Http.HttpClient') to use for communicating over http.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |
| client | [RemoteCongress.Client.ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig') | [ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig') to configure [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') with. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddMemberClient-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddMemberClient(collection) `method`

##### Summary

Registers a [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1') implementation.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddRemoteCongressClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-ClientConfig-'></a>
### AddRemoteCongressClient(collection,client) `method`

##### Summary

Sets up an [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') implementation in `collection`.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |
| client | [RemoteCongress.Client.ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig') | [ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig') to configure [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') with. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `collection` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `config` is null. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddVoteClient-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddVoteClient(collection) `method`

##### Summary

Registers a [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1') implementation.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='T-RemoteCongress-Client-RemoteCongressClient'></a>
## RemoteCongressClient `type`

##### Namespace

RemoteCongress.Client

##### Summary

A client used to interact with the RemoteCongress api.

<a name='M-RemoteCongress-Client-RemoteCongressClient-#ctor-RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Bill},RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Member},RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Vote}-'></a>
### #ctor(billClient,memberClient,voteClient) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| billClient | [RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Bill}](#T-RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Bill} 'RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Bill}') |  |
| memberClient | [RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Member}](#T-RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Member} 'RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Member}') |  |
| voteClient | [RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Vote}](#T-RemoteCongress-Client-IEndpointClient{RemoteCongress-Common-Vote} 'RemoteCongress.Client.IEndpointClient{RemoteCongress.Common.Vote}') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `billClient` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `memberClient` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `voteClient` is null. |

<a name='F-RemoteCongress-Client-RemoteCongressClient-_billClient'></a>
### _billClient `constants`

##### Summary

An [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1') to interact with [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_memberClient'></a>
### _memberClient `constants`

##### Summary

An [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1') to interact with [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_voteClient'></a>
### _voteClient `constants`

##### Summary

An [IEndpointClient\`1](#T-RemoteCongress-Client-IEndpointClient`1 'RemoteCongress.Client.IEndpointClient`1') to interact with [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='M-RemoteCongress-Client-RemoteCongressClient-CreateBill-System-String,System-String,RemoteCongress-Common-Bill,System-Threading-CancellationToken-'></a>
### CreateBill(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') instance.

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to
    the producing individual. |
| data | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') | The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-CreateMember-System-String,System-String,RemoteCongress-Common-Member,System-Threading-CancellationToken-'></a>
### CreateMember(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') instance.

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') to
    the producing individual. |
| data | [RemoteCongress.Common.Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') | The [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-CreateVote-System-String,System-String,RemoteCongress-Common-Vote,System-Threading-CancellationToken-'></a>
### CreateVote(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') instance.

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') to
    the producing individual. |
| data | [RemoteCongress.Common.Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') | The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-GetBill-System-String,System-Threading-CancellationToken-'></a>
### GetBill(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-GetBills-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### GetBills(query,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s that match `query`.

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s that match `query`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-GetMember-System-String,System-Threading-CancellationToken-'></a>
### GetMember(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-GetMembers-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### GetMembers(query,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s that match `query`.

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s that match `query`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-GetVote-System-String,System-Threading-CancellationToken-'></a>
### GetVote(id,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Client-RemoteCongressClient-GetVotes-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### GetVotes(query,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s that match `query`.

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s that match `query`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |
