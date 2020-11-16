<a name='assembly'></a>
# RemoteCongress.Server.DataSeeder

## Contents

- [App](#T-RemoteCongress-Server-DataSeeder-App 'RemoteCongress.Server.DataSeeder.App')
  - [#ctor(logger,adminPrivateKey,adminPublicKey,client,dataProvider)](#M-RemoteCongress-Server-DataSeeder-App-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-App},System-String,System-String,RemoteCongress-Client-IRemoteCongressClient,RemoteCongress-Server-DataSeeder-IDataProvider- 'RemoteCongress.Server.DataSeeder.App.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.App},System.String,System.String,RemoteCongress.Client.IRemoteCongressClient,RemoteCongress.Server.DataSeeder.IDataProvider)')
  - [_adminPrivateKey](#F-RemoteCongress-Server-DataSeeder-App-_adminPrivateKey 'RemoteCongress.Server.DataSeeder.App._adminPrivateKey')
  - [_adminPublicKey](#F-RemoteCongress-Server-DataSeeder-App-_adminPublicKey 'RemoteCongress.Server.DataSeeder.App._adminPublicKey')
  - [_client](#F-RemoteCongress-Server-DataSeeder-App-_client 'RemoteCongress.Server.DataSeeder.App._client')
  - [_dataProvider](#F-RemoteCongress-Server-DataSeeder-App-_dataProvider 'RemoteCongress.Server.DataSeeder.App._dataProvider')
  - [_logger](#F-RemoteCongress-Server-DataSeeder-App-_logger 'RemoteCongress.Server.DataSeeder.App._logger')
  - [Logic(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-App-Logic-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.App.Logic(System.Threading.CancellationToken)')
  - [Run(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-App-Run-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.App.Run(System.Threading.CancellationToken)')
- [IApp](#T-RemoteCongress-Server-DataSeeder-IApp 'RemoteCongress.Server.DataSeeder.IApp')
  - [Run(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-IApp-Run-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.IApp.Run(System.Threading.CancellationToken)')
- [IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider')
  - [GetBills(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-IDataProvider-GetBills-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.IDataProvider.GetBills(System.Threading.CancellationToken)')
  - [GetMembers(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-IDataProvider-GetMembers-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.IDataProvider.GetMembers(System.Threading.CancellationToken)')
  - [GetVotes(id,bill,cancellationToken)](#M-RemoteCongress-Server-DataSeeder-IDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.IDataProvider.GetVotes(System.String,RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Threading.CancellationToken)')
- [IKeyGenerator](#T-RemoteCongress-Server-DataSeeder-IKeyGenerator 'RemoteCongress.Server.DataSeeder.IKeyGenerator')
  - [GenerateKeys(bit,cancellationToken)](#M-RemoteCongress-Server-DataSeeder-IKeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.IKeyGenerator.GenerateKeys(System.Int32,System.Threading.CancellationToken)')
- [KeyGenerator](#T-RemoteCongress-Server-DataSeeder-KeyGenerator 'RemoteCongress.Server.DataSeeder.KeyGenerator')
  - [#ctor(logger)](#M-RemoteCongress-Server-DataSeeder-KeyGenerator-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-KeyGenerator}- 'RemoteCongress.Server.DataSeeder.KeyGenerator.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.KeyGenerator})')
  - [GenerateKeys(bit,cancellationToken)](#M-RemoteCongress-Server-DataSeeder-KeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.KeyGenerator.GenerateKeys(System.Int32,System.Threading.CancellationToken)')
- [Program](#T-RemoteCongress-Server-DataSeeder-Program 'RemoteCongress.Server.DataSeeder.Program')
  - [AdminPrivateKey](#F-RemoteCongress-Server-DataSeeder-Program-AdminPrivateKey 'RemoteCongress.Server.DataSeeder.Program.AdminPrivateKey')
  - [AdminPublicKey](#F-RemoteCongress-Server-DataSeeder-Program-AdminPublicKey 'RemoteCongress.Server.DataSeeder.Program.AdminPublicKey')
  - [Congress](#F-RemoteCongress-Server-DataSeeder-Program-Congress 'RemoteCongress.Server.DataSeeder.Program.Congress')
  - [Hostname](#F-RemoteCongress-Server-DataSeeder-Program-Hostname 'RemoteCongress.Server.DataSeeder.Program.Hostname')
  - [Protocol](#F-RemoteCongress-Server-DataSeeder-Program-Protocol 'RemoteCongress.Server.DataSeeder.Program.Protocol')
  - [Session](#F-RemoteCongress-Server-DataSeeder-Program-Session 'RemoteCongress.Server.DataSeeder.Program.Session')
  - [GetCancellationTokenSource()](#M-RemoteCongress-Server-DataSeeder-Program-GetCancellationTokenSource 'RemoteCongress.Server.DataSeeder.Program.GetCancellationTokenSource')
  - [GetServiceProvider(config)](#M-RemoteCongress-Server-DataSeeder-Program-GetServiceProvider-RemoteCongress-Client-ClientConfig- 'RemoteCongress.Server.DataSeeder.Program.GetServiceProvider(RemoteCongress.Client.ClientConfig)')
  - [Main(args)](#M-RemoteCongress-Server-DataSeeder-Program-Main-System-String[]- 'RemoteCongress.Server.DataSeeder.Program.Main(System.String[])')
- [SenateDataProvider](#T-RemoteCongress-Server-DataSeeder-SenateDataProvider 'RemoteCongress.Server.DataSeeder.SenateDataProvider')
  - [#ctor(keyGenerator,congress,session)](#M-RemoteCongress-Server-DataSeeder-SenateDataProvider-#ctor-RemoteCongress-Server-DataSeeder-IKeyGenerator,System-Int32,System-Int32- 'RemoteCongress.Server.DataSeeder.SenateDataProvider.#ctor(RemoteCongress.Server.DataSeeder.IKeyGenerator,System.Int32,System.Int32)')
  - [_congress](#F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_congress 'RemoteCongress.Server.DataSeeder.SenateDataProvider._congress')
  - [_keyGenerator](#F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_keyGenerator 'RemoteCongress.Server.DataSeeder.SenateDataProvider._keyGenerator')
  - [_keys](#F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_keys 'RemoteCongress.Server.DataSeeder.SenateDataProvider._keys')
  - [_session](#F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_session 'RemoteCongress.Server.DataSeeder.SenateDataProvider._session')
  - [BuildVote(bill,member)](#M-RemoteCongress-Server-DataSeeder-SenateDataProvider-BuildVote-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Xml-Linq-XElement- 'RemoteCongress.Server.DataSeeder.SenateDataProvider.BuildVote(RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Xml.Linq.XElement)')
  - [GetBills(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-SenateDataProvider-GetBills-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.SenateDataProvider.GetBills(System.Threading.CancellationToken)')
  - [GetMembers(cancellationToken)](#M-RemoteCongress-Server-DataSeeder-SenateDataProvider-GetMembers-System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.SenateDataProvider.GetMembers(System.Threading.CancellationToken)')
  - [GetVotes(id,bill,cancellationToken)](#M-RemoteCongress-Server-DataSeeder-SenateDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.SenateDataProvider.GetVotes(System.String,RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Threading.CancellationToken)')

<a name='T-RemoteCongress-Server-DataSeeder-App'></a>
## App `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

Application logic.

##### Remarks

This impl is essentially glue code that ties an [IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider'), and an [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed data.

<a name='M-RemoteCongress-Server-DataSeeder-App-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-App},System-String,System-String,RemoteCongress-Client-IRemoteCongressClient,RemoteCongress-Server-DataSeeder-IDataProvider-'></a>
### #ctor(logger,adminPrivateKey,adminPublicKey,client,dataProvider) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.App}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-App} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.App}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |
| adminPrivateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The "admin" private key to seed members |
| adminPublicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The "admin" public key to seed members |
| client | [RemoteCongress.Client.IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') | The [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed against. |
| dataProvider | [RemoteCongress.Server.DataSeeder.IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider') | The [IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider') to load data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `adminPrivateKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `adminPublicKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `client` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `dataProvider` is null. |

<a name='F-RemoteCongress-Server-DataSeeder-App-_adminPrivateKey'></a>
### _adminPrivateKey `constants`

##### Summary

The "admin" private key to seed members

<a name='F-RemoteCongress-Server-DataSeeder-App-_adminPublicKey'></a>
### _adminPublicKey `constants`

##### Summary

The "admin" public key to seed members

<a name='F-RemoteCongress-Server-DataSeeder-App-_client'></a>
### _client `constants`

##### Summary

The [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed against.

<a name='F-RemoteCongress-Server-DataSeeder-App-_dataProvider'></a>
### _dataProvider `constants`

##### Summary

The [IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider') to load data from.

<a name='F-RemoteCongress-Server-DataSeeder-App-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against.

<a name='M-RemoteCongress-Server-DataSeeder-App-Logic-System-Threading-CancellationToken-'></a>
### Logic(cancellationToken) `method`

##### Summary

Runs the logic to seed data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='M-RemoteCongress-Server-DataSeeder-App-Run-System-Threading-CancellationToken-'></a>
### Run(cancellationToken) `method`

##### Summary

Runs the seed data logic.

##### Returns

The result code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Server-DataSeeder-IApp'></a>
## IApp `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

Application logic.

<a name='M-RemoteCongress-Server-DataSeeder-IApp-Run-System-Threading-CancellationToken-'></a>
### Run(cancellationToken) `method`

##### Summary

Runs application logic.

##### Returns

The result code from the logic.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Server-DataSeeder-IDataProvider'></a>
## IDataProvider `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

An interface that defines a type that's able to provide data for seeding

<a name='M-RemoteCongress-Server-DataSeeder-IDataProvider-GetBills-System-Threading-CancellationToken-'></a>
### GetBills(cancellationToken) `method`

##### Summary

Fetches all [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Returns

A collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Server-DataSeeder-IDataProvider-GetMembers-System-Threading-CancellationToken-'></a>
### GetMembers(cancellationToken) `method`

##### Summary

Fetches all [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Returns

A collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Server-DataSeeder-IDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken-'></a>
### GetVotes(id,bill,cancellationToken) `method`

##### Summary

Fetches all [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s for a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to seed.

##### Returns

A collection of [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique id of the bill. |
| bill | [RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill} 'RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}') | The seeded [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') wrapped in a [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='T-RemoteCongress-Server-DataSeeder-IKeyGenerator'></a>
## IKeyGenerator `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

An interface that abstracts the generation of key pairs.

<a name='M-RemoteCongress-Server-DataSeeder-IKeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken-'></a>
### GenerateKeys(bit,cancellationToken) `method`

##### Summary

Generates a public and private key pair.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bit | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many bits should the key be. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Server-DataSeeder-KeyGenerator'></a>
## KeyGenerator `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

An implementation of [IKeyGenerator](#T-RemoteCongress-Server-DataSeeder-IKeyGenerator 'RemoteCongress.Server.DataSeeder.IKeyGenerator') that'll return RSA key pairs.

<a name='M-RemoteCongress-Server-DataSeeder-KeyGenerator-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-KeyGenerator}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.KeyGenerator}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-KeyGenerator} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.KeyGenerator}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='M-RemoteCongress-Server-DataSeeder-KeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken-'></a>
### GenerateKeys(bit,cancellationToken) `method`

##### Summary

Generates a public and private key pair.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bit | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many bits should the key be. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is cancelled. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if `bit` is less than 1. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is cancelled. |

<a name='T-RemoteCongress-Server-DataSeeder-Program'></a>
## Program `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

Entry point class.

<a name='F-RemoteCongress-Server-DataSeeder-Program-AdminPrivateKey'></a>
### AdminPrivateKey `constants`

##### Remarks

Throw away private / pub key

<a name='F-RemoteCongress-Server-DataSeeder-Program-AdminPublicKey'></a>
### AdminPublicKey `constants`

##### Remarks

Throw away private / pub key

<a name='F-RemoteCongress-Server-DataSeeder-Program-Congress'></a>
### Congress `constants`

##### Summary

The congress to seed.

<a name='F-RemoteCongress-Server-DataSeeder-Program-Hostname'></a>
### Hostname `constants`

##### Summary

The hardcoded hostname to seed against

##### Remarks

TODO: Provide this from the cli.

<a name='F-RemoteCongress-Server-DataSeeder-Program-Protocol'></a>
### Protocol `constants`

##### Summary

The hardcoded protocol to seed against

##### Remarks

TODO: Provide this from the cli.

<a name='F-RemoteCongress-Server-DataSeeder-Program-Session'></a>
### Session `constants`

##### Summary

The session to seed.

<a name='M-RemoteCongress-Server-DataSeeder-Program-GetCancellationTokenSource'></a>
### GetCancellationTokenSource() `method`

##### Summary

Sets up the [CancellationTokenSource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource') for the cli application.

##### Returns

A [CancellationTokenSource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource') linked to the application cancellation event.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Server-DataSeeder-Program-GetServiceProvider-RemoteCongress-Client-ClientConfig-'></a>
### GetServiceProvider(config) `method`

##### Summary

Sets up the [ServiceProvider](#T-Microsoft-Extensions-DependencyInjection-ServiceProvider 'Microsoft.Extensions.DependencyInjection.ServiceProvider') and registers the Remote Congress client in DI.

##### Returns

The DI [ServiceProvider](#T-Microsoft-Extensions-DependencyInjection-ServiceProvider 'Microsoft.Extensions.DependencyInjection.ServiceProvider').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| config | [RemoteCongress.Client.ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig') | The [ClientConfig](#T-RemoteCongress-Client-ClientConfig 'RemoteCongress.Client.ClientConfig') to use to configure the RemoteCongress client instances. |

<a name='M-RemoteCongress-Server-DataSeeder-Program-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

Runs the application logic

##### Returns

Result code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Command line arguments |

<a name='T-RemoteCongress-Server-DataSeeder-SenateDataProvider'></a>
## SenateDataProvider `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

A [IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider') for fetching data for the US Senate from xml files.

<a name='M-RemoteCongress-Server-DataSeeder-SenateDataProvider-#ctor-RemoteCongress-Server-DataSeeder-IKeyGenerator,System-Int32,System-Int32-'></a>
### #ctor(keyGenerator,congress,session) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keyGenerator | [RemoteCongress.Server.DataSeeder.IKeyGenerator](#T-RemoteCongress-Server-DataSeeder-IKeyGenerator 'RemoteCongress.Server.DataSeeder.IKeyGenerator') | A [IKeyGenerator](#T-RemoteCongress-Server-DataSeeder-IKeyGenerator 'RemoteCongress.Server.DataSeeder.IKeyGenerator') to create keys for seeded [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s. |
| congress | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The congress number to seed. |
| session | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The session number to seed. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `keyGenerator` is null. |

<a name='F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_congress'></a>
### _congress `constants`

##### Summary

The congress number to seed.

<a name='F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_keyGenerator'></a>
### _keyGenerator `constants`

##### Summary

A [IKeyGenerator](#T-RemoteCongress-Server-DataSeeder-IKeyGenerator 'RemoteCongress.Server.DataSeeder.IKeyGenerator') to create keys for seeded [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_keys'></a>
### _keys `constants`

##### Summary

A local in memory cache of members, and their pub/priv keys.

<a name='F-RemoteCongress-Server-DataSeeder-SenateDataProvider-_session'></a>
### _session `constants`

##### Summary

The session number to seed.

<a name='M-RemoteCongress-Server-DataSeeder-SenateDataProvider-BuildVote-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Xml-Linq-XElement-'></a>
### BuildVote(bill,member) `method`

##### Summary

Generates a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') poco.

##### Returns

The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') poco to use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bill | [RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill} 'RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}') | The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') related to the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| member | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The XML element containing the vote data. |

<a name='M-RemoteCongress-Server-DataSeeder-SenateDataProvider-GetBills-System-Threading-CancellationToken-'></a>
### GetBills(cancellationToken) `method`

##### Summary

Fetches all [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Returns

A collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Server-DataSeeder-SenateDataProvider-GetMembers-System-Threading-CancellationToken-'></a>
### GetMembers(cancellationToken) `method`

##### Summary

Fetches all [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Returns

A collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Server-DataSeeder-SenateDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken-'></a>
### GetVotes(id,bill,cancellationToken) `method`

##### Summary

Fetches all [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s for a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to seed.

##### Returns

A collection of [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique id of the bill. |
| bill | [RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill} 'RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}') | The seeded [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') wrapped in a [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1'). |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |
