<a name='assembly'></a>
# RemoteCongress.Client

## Contents

- [DataSigner\`1](#T-RemoteCongress-Client-DataSigner`1 'RemoteCongress.Client.DataSigner`1')
  - [#ctor(logger,codecs)](#M-RemoteCongress-Client-DataSigner`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-DataSigner{`0}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{`0}}- 'RemoteCongress.Client.DataSigner`1.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.DataSigner{`0}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{`0}})')
  - [_codecs](#F-RemoteCongress-Client-DataSigner`1-_codecs 'RemoteCongress.Client.DataSigner`1._codecs')
  - [_logger](#F-RemoteCongress-Client-DataSigner`1-_logger 'RemoteCongress.Client.DataSigner`1._logger')
  - [Create(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-DataSigner`1-Create-System-String,System-String,`0,System-Threading-CancellationToken- 'RemoteCongress.Client.DataSigner`1.Create(System.String,System.String,`0,System.Threading.CancellationToken)')
  - [GetCodec(mediaType)](#M-RemoteCongress-Client-DataSigner`1-GetCodec-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Client.DataSigner`1.GetCodec(RemoteCongress.Common.RemoteCongressMediaType)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Client-DataSigner`1-GetPreferredMediaType 'RemoteCongress.Client.DataSigner`1.GetPreferredMediaType')
- [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1')
  - [Create(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IDataSigner`1-Create-System-String,System-String,`0,System-Threading-CancellationToken- 'RemoteCongress.Client.IDataSigner`1.Create(System.String,System.String,`0,System.Threading.CancellationToken)')
- [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient')
  - [CreateBill(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-CreateBill-System-String,System-String,RemoteCongress-Common-Bill,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.CreateBill(System.String,System.String,RemoteCongress.Common.Bill,System.Threading.CancellationToken)')
  - [CreateMember(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-CreateMember-System-String,System-String,RemoteCongress-Common-Member,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.CreateMember(System.String,System.String,RemoteCongress.Common.Member,System.Threading.CancellationToken)')
  - [CreateVote(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-CreateVote-System-String,System-String,RemoteCongress-Common-Vote,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.CreateVote(System.String,System.String,RemoteCongress.Common.Vote,System.Threading.CancellationToken)')
  - [GetBill(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetBill-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetBill(System.String,System.Threading.CancellationToken)')
  - [GetBills(query,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetBills-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetBills(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetMember(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetMember-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetMember(System.String,System.Threading.CancellationToken)')
  - [GetMembers(query,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetMembers-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetMembers(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetVote(id,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetVote-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetVote(System.String,System.Threading.CancellationToken)')
  - [GetVotes(query,cancellationToken)](#M-RemoteCongress-Client-IRemoteCongressClient-GetVotes-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.IRemoteCongressClient.GetVotes(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [IServiceCollectionExtensions](#T-RemoteCongress-Client-IServiceCollectionExtensions 'RemoteCongress.Client.IServiceCollectionExtensions')
  - [BillEndpoint](#F-RemoteCongress-Client-IServiceCollectionExtensions-BillEndpoint 'RemoteCongress.Client.IServiceCollectionExtensions.BillEndpoint')
  - [MemberEndpoint](#F-RemoteCongress-Client-IServiceCollectionExtensions-MemberEndpoint 'RemoteCongress.Client.IServiceCollectionExtensions.MemberEndpoint')
  - [VoteEndpoint](#F-RemoteCongress-Client-IServiceCollectionExtensions-VoteEndpoint 'RemoteCongress.Client.IServiceCollectionExtensions.VoteEndpoint')
  - [AddBillDependencies(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddBillDependencies-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddBillDependencies(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddCodecs(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddCodecs-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddCodecs(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddHttpClient(collection,config)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddHttpClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-DAL-Http-ClientConfig- 'RemoteCongress.Client.IServiceCollectionExtensions.AddHttpClient(Microsoft.Extensions.DependencyInjection.IServiceCollection,RemoteCongress.Client.DAL.Http.ClientConfig)')
  - [AddMemberDependencies(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddMemberDependencies-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddMemberDependencies(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddRemoteCongressClient(collection,config)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddRemoteCongressClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-DAL-Http-ClientConfig- 'RemoteCongress.Client.IServiceCollectionExtensions.AddRemoteCongressClient(Microsoft.Extensions.DependencyInjection.IServiceCollection,RemoteCongress.Client.DAL.Http.ClientConfig)')
  - [AddVoteDependencies(collection)](#M-RemoteCongress-Client-IServiceCollectionExtensions-AddVoteDependencies-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Client.IServiceCollectionExtensions.AddVoteDependencies(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
- [RemoteCongressClient](#T-RemoteCongress-Client-RemoteCongressClient 'RemoteCongress.Client.RemoteCongressClient')
  - [#ctor(logger,billDataSigner,memberDataSigner,voteDataSigner,billRepo,memberRepo,voteRepo)](#M-RemoteCongress-Client-RemoteCongressClient-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-RemoteCongressClient},RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Bill},RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Member},RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Vote},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}- 'RemoteCongress.Client.RemoteCongressClient.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.RemoteCongressClient},RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Bill},RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Member},RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Vote},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote})')
  - [_billDataSigner](#F-RemoteCongress-Client-RemoteCongressClient-_billDataSigner 'RemoteCongress.Client.RemoteCongressClient._billDataSigner')
  - [_billRepo](#F-RemoteCongress-Client-RemoteCongressClient-_billRepo 'RemoteCongress.Client.RemoteCongressClient._billRepo')
  - [_logger](#F-RemoteCongress-Client-RemoteCongressClient-_logger 'RemoteCongress.Client.RemoteCongressClient._logger')
  - [_memberDataSigner](#F-RemoteCongress-Client-RemoteCongressClient-_memberDataSigner 'RemoteCongress.Client.RemoteCongressClient._memberDataSigner')
  - [_memberRepo](#F-RemoteCongress-Client-RemoteCongressClient-_memberRepo 'RemoteCongress.Client.RemoteCongressClient._memberRepo')
  - [_voteDataSigner](#F-RemoteCongress-Client-RemoteCongressClient-_voteDataSigner 'RemoteCongress.Client.RemoteCongressClient._voteDataSigner')
  - [_voteRepo](#F-RemoteCongress-Client-RemoteCongressClient-_voteRepo 'RemoteCongress.Client.RemoteCongressClient._voteRepo')
  - [CreateBill(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-CreateBill-System-String,System-String,RemoteCongress-Common-Bill,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.CreateBill(System.String,System.String,RemoteCongress.Common.Bill,System.Threading.CancellationToken)')
  - [CreateMember(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-CreateMember-System-String,System-String,RemoteCongress-Common-Member,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.CreateMember(System.String,System.String,RemoteCongress.Common.Member,System.Threading.CancellationToken)')
  - [CreateVote(privateKey,publicKey,data,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-CreateVote-System-String,System-String,RemoteCongress-Common-Vote,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.CreateVote(System.String,System.String,RemoteCongress.Common.Vote,System.Threading.CancellationToken)')
  - [GetBill(id,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetBill-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetBill(System.String,System.Threading.CancellationToken)')
  - [GetBills(query,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetBills-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetBills(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetMember(id,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetMember-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetMember(System.String,System.Threading.CancellationToken)')
  - [GetMembers(query,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetMembers-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetMembers(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [GetVote(id,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetVote-System-String,System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetVote(System.String,System.Threading.CancellationToken)')
  - [GetVotes(query,cancellationToken)](#M-RemoteCongress-Client-RemoteCongressClient-GetVotes-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Client.RemoteCongressClient.GetVotes(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')

<a name='T-RemoteCongress-Client-DataSigner`1'></a>
## DataSigner\`1 `type`

##### Namespace

RemoteCongress.Client

##### Summary

A client used to interact an endpoint of the api.

<a name='M-RemoteCongress-Client-DataSigner`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-DataSigner{`0}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{`0}}-'></a>
### #ctor(logger,codecs) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.DataSigner{\`0}}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-DataSigner{`0}} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.DataSigner{`0}}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |
| codecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{`0}}') | An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for `TModel`s. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `codecs` is null. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if `codecs` contains zero [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1')s. |

<a name='F-RemoteCongress-Client-DataSigner`1-_codecs'></a>
### _codecs `constants`

##### Summary

A collection of codecs to endode and decode data.

<a name='F-RemoteCongress-Client-DataSigner`1-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against.

<a name='M-RemoteCongress-Client-DataSigner`1-Create-System-String,System-String,`0,System-Threading-CancellationToken-'></a>
### Create(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a `TModel` instance.

##### Returns

The persisted `TModel`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the `TModel`. |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable `TModel` to the producing individual. |
| data | [\`0](#T-`0 '`0') | The `TModel` data to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `privateKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `publicKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is null. |

<a name='M-RemoteCongress-Client-DataSigner`1-GetCodec-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### GetCodec(mediaType) `method`

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

<a name='M-RemoteCongress-Client-DataSigner`1-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the primary media type for the client.

##### Returns

The primary media type.

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Client-IDataSigner`1'></a>
## IDataSigner\`1 `type`

##### Namespace

RemoteCongress.Client

##### Summary

An interface for a client used to interact an endpoint of the api.

<a name='M-RemoteCongress-Client-IDataSigner`1-Create-System-String,System-String,`0,System-Threading-CancellationToken-'></a>
### Create(privateKey,publicKey,data,cancellationToken) `method`

##### Summary

Creates, signs, and persists a `TModel` instance.

##### Returns

The persisted `TModel`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The private key to use to generate the [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature') of the `TModel`. |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable `TModel` to the producing individual. |
| data | [\`0](#T-`0 '`0') | The `TModel` data to persist. |
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
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to the producing individual. |
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
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') to the producing individual. |
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
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') to the producing individual. |
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
### GetBills(query,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') collection to filer [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s on. |
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
### GetMembers(query,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') collection to filer [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s on. |
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
### GetVotes(query,cancellationToken) `method`

##### Summary

Fetches a signed, and verified [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') by it's [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id').

##### Returns

The persisted [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | The [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') collection to filer [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s on. |
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

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddBillDependencies-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddBillDependencies(collection) `method`

##### Summary

Registers a [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') and [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') implementation.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddCodecs-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddCodecs(collection) `method`

##### Summary

Registers all supported [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1')s.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddHttpClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-DAL-Http-ClientConfig-'></a>
### AddHttpClient(collection,config) `method`

##### Summary

Registers a [HttpClient](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpClient 'System.Net.Http.HttpClient') to use for communicating over http.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |
| config | [RemoteCongress.Client.DAL.Http.ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') | [ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') to configure [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') with. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddMemberDependencies-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddMemberDependencies(collection) `method`

##### Summary

Registers a [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') and [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') implementation.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddRemoteCongressClient-Microsoft-Extensions-DependencyInjection-IServiceCollection,RemoteCongress-Client-DAL-Http-ClientConfig-'></a>
### AddRemoteCongressClient(collection,config) `method`

##### Summary

Sets up an [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') implementation in `collection`.

##### Returns

`collection`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to define [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') in. |
| config | [RemoteCongress.Client.DAL.Http.ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') | [ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') to configure [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') with. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `collection` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `config` is null. |

<a name='M-RemoteCongress-Client-IServiceCollectionExtensions-AddVoteDependencies-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddVoteDependencies(collection) `method`

##### Summary

Registers a [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') and [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') implementation.

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

<a name='M-RemoteCongress-Client-RemoteCongressClient-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-RemoteCongressClient},RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Bill},RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Member},RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Vote},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}-'></a>
### #ctor(logger,billDataSigner,memberDataSigner,voteDataSigner,billRepo,memberRepo,voteRepo) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.RemoteCongressClient}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Client-RemoteCongressClient} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Client.RemoteCongressClient}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| billDataSigner | [RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Bill}](#T-RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Bill} 'RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Bill}') | An [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') to sign [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s. |
| memberDataSigner | [RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Member}](#T-RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Member} 'RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Member}') | An [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') to sign [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s. |
| voteDataSigner | [RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Vote}](#T-RemoteCongress-Client-IDataSigner{RemoteCongress-Common-Vote} 'RemoteCongress.Client.IDataSigner{RemoteCongress.Common.Vote}') | An [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') to sign [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s. |
| billRepo | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') to interact with [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s. |
| memberRepo | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') to interact with [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s. |
| voteRepo | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') to interact with [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `billDataSigner` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `memberDataSigner` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `voteDataSigner` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `billRepo` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `memberRepo` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `voteRepo` is null. |

<a name='F-RemoteCongress-Client-RemoteCongressClient-_billDataSigner'></a>
### _billDataSigner `constants`

##### Summary

An [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') to sign [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_billRepo'></a>
### _billRepo `constants`

##### Summary

An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') to interact with [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_memberDataSigner'></a>
### _memberDataSigner `constants`

##### Summary

An [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') to sign [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_memberRepo'></a>
### _memberRepo `constants`

##### Summary

An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') to interact with [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_voteDataSigner'></a>
### _voteDataSigner `constants`

##### Summary

An [IDataSigner\`1](#T-RemoteCongress-Client-IDataSigner`1 'RemoteCongress.Client.IDataSigner`1') to sign [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='F-RemoteCongress-Client-RemoteCongressClient-_voteRepo'></a>
### _voteRepo `constants`

##### Summary

An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') to interact with [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

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
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to the producing individual. |
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
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') to the producing individual. |
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
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The public key that matches `privateKey` to link the immutable [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') to the producing individual. |
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
