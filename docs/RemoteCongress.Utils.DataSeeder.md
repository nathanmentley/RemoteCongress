<a name='assembly'></a>
# RemoteCongress.Utils.DataSeeder

## Contents

- [App](#T-RemoteCongress-Utils-DataSeeder-App 'RemoteCongress.Utils.DataSeeder.App')
  - [#ctor(logger,adminPrivateKey,adminPublicKey,client,dataProviders)](#M-RemoteCongress-Utils-DataSeeder-App-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Utils-DataSeeder-App},System-String,System-String,RemoteCongress-Client-IRemoteCongressClient,System-Collections-Generic-IEnumerable{RemoteCongress-Utils-DataSeeder-IDataProvider}- 'RemoteCongress.Utils.DataSeeder.App.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Utils.DataSeeder.App},System.String,System.String,RemoteCongress.Client.IRemoteCongressClient,System.Collections.Generic.IEnumerable{RemoteCongress.Utils.DataSeeder.IDataProvider})')
  - [_adminPrivateKey](#F-RemoteCongress-Utils-DataSeeder-App-_adminPrivateKey 'RemoteCongress.Utils.DataSeeder.App._adminPrivateKey')
  - [_adminPublicKey](#F-RemoteCongress-Utils-DataSeeder-App-_adminPublicKey 'RemoteCongress.Utils.DataSeeder.App._adminPublicKey')
  - [_client](#F-RemoteCongress-Utils-DataSeeder-App-_client 'RemoteCongress.Utils.DataSeeder.App._client')
  - [_dataProviders](#F-RemoteCongress-Utils-DataSeeder-App-_dataProviders 'RemoteCongress.Utils.DataSeeder.App._dataProviders')
  - [_logger](#F-RemoteCongress-Utils-DataSeeder-App-_logger 'RemoteCongress.Utils.DataSeeder.App._logger')
  - [Logic(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-App-Logic-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.App.Logic(System.Threading.CancellationToken)')
  - [Run(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-App-Run-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.App.Run(System.Threading.CancellationToken)')
  - [SeedBill(bill,id,dataProvider,cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-App-SeedBill-RemoteCongress-Common-Bill,System-String,RemoteCongress-Utils-DataSeeder-IDataProvider,System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.App.SeedBill(RemoteCongress.Common.Bill,System.String,RemoteCongress.Utils.DataSeeder.IDataProvider,System.Threading.CancellationToken)')
- [AppResultCode](#T-RemoteCongress-Utils-DataSeeder-AppResultCode 'RemoteCongress.Utils.DataSeeder.AppResultCode')
  - [OperationCancelled](#F-RemoteCongress-Utils-DataSeeder-AppResultCode-OperationCancelled 'RemoteCongress.Utils.DataSeeder.AppResultCode.OperationCancelled')
  - [Success](#F-RemoteCongress-Utils-DataSeeder-AppResultCode-Success 'RemoteCongress.Utils.DataSeeder.AppResultCode.Success')
  - [UnknownError](#F-RemoteCongress-Utils-DataSeeder-AppResultCode-UnknownError 'RemoteCongress.Utils.DataSeeder.AppResultCode.UnknownError')
- [HouseDataProvider](#T-RemoteCongress-Utils-DataSeeder-HouseDataProvider 'RemoteCongress.Utils.DataSeeder.HouseDataProvider')
  - [#ctor(keyGenerator,congress,session)](#M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-#ctor-RemoteCongress-Utils-DataSeeder-IKeyGenerator,System-Int32,System-Int32- 'RemoteCongress.Utils.DataSeeder.HouseDataProvider.#ctor(RemoteCongress.Utils.DataSeeder.IKeyGenerator,System.Int32,System.Int32)')
  - [_congress](#F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_congress 'RemoteCongress.Utils.DataSeeder.HouseDataProvider._congress')
  - [_keyGenerator](#F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_keyGenerator 'RemoteCongress.Utils.DataSeeder.HouseDataProvider._keyGenerator')
  - [_keys](#F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_keys 'RemoteCongress.Utils.DataSeeder.HouseDataProvider._keys')
  - [_session](#F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_session 'RemoteCongress.Utils.DataSeeder.HouseDataProvider._session')
  - [BuildVote(bill,recordedVote)](#M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-BuildVote-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Xml-Linq-XElement- 'RemoteCongress.Utils.DataSeeder.HouseDataProvider.BuildVote(RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Xml.Linq.XElement)')
  - [GetBills(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-GetBills-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.HouseDataProvider.GetBills(System.Threading.CancellationToken)')
  - [GetMembers(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-GetMembers-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.HouseDataProvider.GetMembers(System.Threading.CancellationToken)')
  - [GetVotes(id,bill,cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.HouseDataProvider.GetVotes(System.String,RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Threading.CancellationToken)')
- [IApp](#T-RemoteCongress-Utils-DataSeeder-IApp 'RemoteCongress.Utils.DataSeeder.IApp')
  - [Run(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-IApp-Run-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.IApp.Run(System.Threading.CancellationToken)')
- [IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider')
  - [GetBills(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-IDataProvider-GetBills-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.IDataProvider.GetBills(System.Threading.CancellationToken)')
  - [GetMembers(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-IDataProvider-GetMembers-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.IDataProvider.GetMembers(System.Threading.CancellationToken)')
  - [GetVotes(id,bill,cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-IDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.IDataProvider.GetVotes(System.String,RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Threading.CancellationToken)')
- [IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator')
  - [GenerateKeys(bit,cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-IKeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.IKeyGenerator.GenerateKeys(System.Int32,System.Threading.CancellationToken)')
- [KeyGenerator](#T-RemoteCongress-Utils-DataSeeder-KeyGenerator 'RemoteCongress.Utils.DataSeeder.KeyGenerator')
  - [#ctor(logger)](#M-RemoteCongress-Utils-DataSeeder-KeyGenerator-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Utils-DataSeeder-KeyGenerator}- 'RemoteCongress.Utils.DataSeeder.KeyGenerator.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Utils.DataSeeder.KeyGenerator})')
  - [GenerateKeys(bit,cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-KeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.KeyGenerator.GenerateKeys(System.Int32,System.Threading.CancellationToken)')
- [Program](#T-RemoteCongress-Utils-DataSeeder-Program 'RemoteCongress.Utils.DataSeeder.Program')
  - [AdminPrivateKey](#F-RemoteCongress-Utils-DataSeeder-Program-AdminPrivateKey 'RemoteCongress.Utils.DataSeeder.Program.AdminPrivateKey')
  - [AdminPublicKey](#F-RemoteCongress-Utils-DataSeeder-Program-AdminPublicKey 'RemoteCongress.Utils.DataSeeder.Program.AdminPublicKey')
  - [Congress](#F-RemoteCongress-Utils-DataSeeder-Program-Congress 'RemoteCongress.Utils.DataSeeder.Program.Congress')
  - [Hostname](#F-RemoteCongress-Utils-DataSeeder-Program-Hostname 'RemoteCongress.Utils.DataSeeder.Program.Hostname')
  - [Protocol](#F-RemoteCongress-Utils-DataSeeder-Program-Protocol 'RemoteCongress.Utils.DataSeeder.Program.Protocol')
  - [Session](#F-RemoteCongress-Utils-DataSeeder-Program-Session 'RemoteCongress.Utils.DataSeeder.Program.Session')
  - [GetCancellationTokenSource()](#M-RemoteCongress-Utils-DataSeeder-Program-GetCancellationTokenSource 'RemoteCongress.Utils.DataSeeder.Program.GetCancellationTokenSource')
  - [GetServiceProvider(config)](#M-RemoteCongress-Utils-DataSeeder-Program-GetServiceProvider-RemoteCongress-Client-DAL-Http-ClientConfig- 'RemoteCongress.Utils.DataSeeder.Program.GetServiceProvider(RemoteCongress.Client.DAL.Http.ClientConfig)')
  - [Main(args)](#M-RemoteCongress-Utils-DataSeeder-Program-Main-System-String[]- 'RemoteCongress.Utils.DataSeeder.Program.Main(System.String[])')
- [SenateDataProvider](#T-RemoteCongress-Utils-DataSeeder-SenateDataProvider 'RemoteCongress.Utils.DataSeeder.SenateDataProvider')
  - [#ctor(keyGenerator,congress,session)](#M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-#ctor-RemoteCongress-Utils-DataSeeder-IKeyGenerator,System-Int32,System-Int32- 'RemoteCongress.Utils.DataSeeder.SenateDataProvider.#ctor(RemoteCongress.Utils.DataSeeder.IKeyGenerator,System.Int32,System.Int32)')
  - [_congress](#F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_congress 'RemoteCongress.Utils.DataSeeder.SenateDataProvider._congress')
  - [_keyGenerator](#F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_keyGenerator 'RemoteCongress.Utils.DataSeeder.SenateDataProvider._keyGenerator')
  - [_keys](#F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_keys 'RemoteCongress.Utils.DataSeeder.SenateDataProvider._keys')
  - [_session](#F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_session 'RemoteCongress.Utils.DataSeeder.SenateDataProvider._session')
  - [BuildVote(bill,member)](#M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-BuildVote-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Xml-Linq-XElement- 'RemoteCongress.Utils.DataSeeder.SenateDataProvider.BuildVote(RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Xml.Linq.XElement)')
  - [GetBills(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-GetBills-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.SenateDataProvider.GetBills(System.Threading.CancellationToken)')
  - [GetMembers(cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-GetMembers-System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.SenateDataProvider.GetMembers(System.Threading.CancellationToken)')
  - [GetVotes(id,bill,cancellationToken)](#M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken- 'RemoteCongress.Utils.DataSeeder.SenateDataProvider.GetVotes(System.String,RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill},System.Threading.CancellationToken)')

<a name='T-RemoteCongress-Utils-DataSeeder-App'></a>
## App `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

Application logic.

##### Remarks

This impl is essentially glue code that ties an [IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider'), and an [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed data.

<a name='M-RemoteCongress-Utils-DataSeeder-App-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Utils-DataSeeder-App},System-String,System-String,RemoteCongress-Client-IRemoteCongressClient,System-Collections-Generic-IEnumerable{RemoteCongress-Utils-DataSeeder-IDataProvider}-'></a>
### #ctor(logger,adminPrivateKey,adminPublicKey,client,dataProviders) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Utils.DataSeeder.App}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Utils-DataSeeder-App} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Utils.DataSeeder.App}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |
| adminPrivateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The "admin" private key to seed members |
| adminPublicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The "admin" public key to seed members |
| client | [RemoteCongress.Client.IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') | The [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed against. |
| dataProviders | [System.Collections.Generic.IEnumerable{RemoteCongress.Utils.DataSeeder.IDataProvider}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Utils.DataSeeder.IDataProvider}') | All the [IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider') to load data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `adminPrivateKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `adminPublicKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `client` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `dataProviders` is null. |

<a name='F-RemoteCongress-Utils-DataSeeder-App-_adminPrivateKey'></a>
### _adminPrivateKey `constants`

##### Summary

The "admin" private key to seed members

<a name='F-RemoteCongress-Utils-DataSeeder-App-_adminPublicKey'></a>
### _adminPublicKey `constants`

##### Summary

The "admin" public key to seed members

<a name='F-RemoteCongress-Utils-DataSeeder-App-_client'></a>
### _client `constants`

##### Summary

The [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed against.

<a name='F-RemoteCongress-Utils-DataSeeder-App-_dataProviders'></a>
### _dataProviders `constants`

##### Summary

The [IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider') to load data from.

<a name='F-RemoteCongress-Utils-DataSeeder-App-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against.

<a name='M-RemoteCongress-Utils-DataSeeder-App-Logic-System-Threading-CancellationToken-'></a>
### Logic(cancellationToken) `method`

##### Summary

Runs the logic to seed data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-App-Run-System-Threading-CancellationToken-'></a>
### Run(cancellationToken) `method`

##### Summary

Runs the seed data logic.

##### Returns

The result code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-App-SeedBill-RemoteCongress-Common-Bill,System-String,RemoteCongress-Utils-DataSeeder-IDataProvider,System-Threading-CancellationToken-'></a>
### SeedBill(bill,id,dataProvider,cancellationToken) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bill | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') |  |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| dataProvider | [RemoteCongress.Utils.DataSeeder.IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider') |  |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Utils-DataSeeder-AppResultCode'></a>
## AppResultCode `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary



<a name='F-RemoteCongress-Utils-DataSeeder-AppResultCode-OperationCancelled'></a>
### OperationCancelled `constants`

##### Summary



<a name='F-RemoteCongress-Utils-DataSeeder-AppResultCode-Success'></a>
### Success `constants`

##### Summary



<a name='F-RemoteCongress-Utils-DataSeeder-AppResultCode-UnknownError'></a>
### UnknownError `constants`

##### Summary



<a name='T-RemoteCongress-Utils-DataSeeder-HouseDataProvider'></a>
## HouseDataProvider `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

A [IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider') for fetching data for the US House from xml files.

<a name='M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-#ctor-RemoteCongress-Utils-DataSeeder-IKeyGenerator,System-Int32,System-Int32-'></a>
### #ctor(keyGenerator,congress,session) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keyGenerator | [RemoteCongress.Utils.DataSeeder.IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') | A [IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') to create keys for seeded [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s. |
| congress | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The congress number to seed. |
| session | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The session number to seed. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `keyGenerator` is null. |

<a name='F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_congress'></a>
### _congress `constants`

##### Summary

The congress number to seed.

<a name='F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_keyGenerator'></a>
### _keyGenerator `constants`

##### Summary

A [IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') to create keys for seeded [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_keys'></a>
### _keys `constants`

##### Summary

A local in memory cache of members, and their pub/priv keys.

<a name='F-RemoteCongress-Utils-DataSeeder-HouseDataProvider-_session'></a>
### _session `constants`

##### Summary

The session number to seed.

<a name='M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-BuildVote-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Xml-Linq-XElement-'></a>
### BuildVote(bill,recordedVote) `method`

##### Summary

Generates a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') poco.

##### Returns

The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') poco to use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bill | [RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill} 'RemoteCongress.Common.VerifiedData{RemoteCongress.Common.Bill}') | The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') related to the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). |
| recordedVote | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The XML element containing the vote data. |

<a name='M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-GetBills-System-Threading-CancellationToken-'></a>
### GetBills(cancellationToken) `method`

##### Summary

Fetches all [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Returns

A collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-GetMembers-System-Threading-CancellationToken-'></a>
### GetMembers(cancellationToken) `method`

##### Summary

Fetches all [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Returns

A collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-HouseDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken-'></a>
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

<a name='T-RemoteCongress-Utils-DataSeeder-IApp'></a>
## IApp `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

Application logic.

<a name='M-RemoteCongress-Utils-DataSeeder-IApp-Run-System-Threading-CancellationToken-'></a>
### Run(cancellationToken) `method`

##### Summary

Runs application logic.

##### Returns

The result code from the logic.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Utils-DataSeeder-IDataProvider'></a>
## IDataProvider `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

An interface that defines a type that's able to provide data for seeding

<a name='M-RemoteCongress-Utils-DataSeeder-IDataProvider-GetBills-System-Threading-CancellationToken-'></a>
### GetBills(cancellationToken) `method`

##### Summary

Fetches all [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Returns

A collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-IDataProvider-GetMembers-System-Threading-CancellationToken-'></a>
### GetMembers(cancellationToken) `method`

##### Summary

Fetches all [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Returns

A collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-IDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken-'></a>
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

<a name='T-RemoteCongress-Utils-DataSeeder-IKeyGenerator'></a>
## IKeyGenerator `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

An interface that abstracts the generation of key pairs.

<a name='M-RemoteCongress-Utils-DataSeeder-IKeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken-'></a>
### GenerateKeys(bit,cancellationToken) `method`

##### Summary

Generates a public and private key pair.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bit | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many bits should the key be. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Utils-DataSeeder-KeyGenerator'></a>
## KeyGenerator `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

An implementation of [IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') that'll return RSA key pairs.

<a name='M-RemoteCongress-Utils-DataSeeder-KeyGenerator-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Utils-DataSeeder-KeyGenerator}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Utils.DataSeeder.KeyGenerator}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Utils-DataSeeder-KeyGenerator} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Utils.DataSeeder.KeyGenerator}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='M-RemoteCongress-Utils-DataSeeder-KeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken-'></a>
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

<a name='T-RemoteCongress-Utils-DataSeeder-Program'></a>
## Program `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

Entry point class.

<a name='F-RemoteCongress-Utils-DataSeeder-Program-AdminPrivateKey'></a>
### AdminPrivateKey `constants`

##### Remarks

Throw away private / pub key

<a name='F-RemoteCongress-Utils-DataSeeder-Program-AdminPublicKey'></a>
### AdminPublicKey `constants`

##### Remarks

Throw away private / pub key

<a name='F-RemoteCongress-Utils-DataSeeder-Program-Congress'></a>
### Congress `constants`

##### Summary

The congress to seed.

<a name='F-RemoteCongress-Utils-DataSeeder-Program-Hostname'></a>
### Hostname `constants`

##### Summary

The hardcoded hostname to seed against

##### Remarks

TODO: Provide this from the cli.

<a name='F-RemoteCongress-Utils-DataSeeder-Program-Protocol'></a>
### Protocol `constants`

##### Summary

The hardcoded protocol to seed against

##### Remarks

TODO: Provide this from the cli.

<a name='F-RemoteCongress-Utils-DataSeeder-Program-Session'></a>
### Session `constants`

##### Summary

The session to seed.

<a name='M-RemoteCongress-Utils-DataSeeder-Program-GetCancellationTokenSource'></a>
### GetCancellationTokenSource() `method`

##### Summary

Sets up the [CancellationTokenSource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource') for the cli application.

##### Returns

A [CancellationTokenSource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource') linked to the application cancellation event.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Utils-DataSeeder-Program-GetServiceProvider-RemoteCongress-Client-DAL-Http-ClientConfig-'></a>
### GetServiceProvider(config) `method`

##### Summary

Sets up the [ServiceProvider](#T-Microsoft-Extensions-DependencyInjection-ServiceProvider 'Microsoft.Extensions.DependencyInjection.ServiceProvider') and registers the Remote Congress client in DI.

##### Returns

The DI [ServiceProvider](#T-Microsoft-Extensions-DependencyInjection-ServiceProvider 'Microsoft.Extensions.DependencyInjection.ServiceProvider').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| config | [RemoteCongress.Client.DAL.Http.ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') | The [ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') to use to configure the RemoteCongress client instances. |

<a name='M-RemoteCongress-Utils-DataSeeder-Program-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

Runs the application logic

##### Returns

Result code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Command line arguments |

<a name='T-RemoteCongress-Utils-DataSeeder-SenateDataProvider'></a>
## SenateDataProvider `type`

##### Namespace

RemoteCongress.Utils.DataSeeder

##### Summary

A [IDataProvider](#T-RemoteCongress-Utils-DataSeeder-IDataProvider 'RemoteCongress.Utils.DataSeeder.IDataProvider') for fetching data for the US Senate from xml files.

<a name='M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-#ctor-RemoteCongress-Utils-DataSeeder-IKeyGenerator,System-Int32,System-Int32-'></a>
### #ctor(keyGenerator,congress,session) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keyGenerator | [RemoteCongress.Utils.DataSeeder.IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') | A [IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') to create keys for seeded [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s. |
| congress | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The congress number to seed. |
| session | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The session number to seed. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `keyGenerator` is null. |

<a name='F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_congress'></a>
### _congress `constants`

##### Summary

The congress number to seed.

<a name='F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_keyGenerator'></a>
### _keyGenerator `constants`

##### Summary

A [IKeyGenerator](#T-RemoteCongress-Utils-DataSeeder-IKeyGenerator 'RemoteCongress.Utils.DataSeeder.IKeyGenerator') to create keys for seeded [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_keys'></a>
### _keys `constants`

##### Summary

A local in memory cache of members, and their pub/priv keys.

<a name='F-RemoteCongress-Utils-DataSeeder-SenateDataProvider-_session'></a>
### _session `constants`

##### Summary

The session number to seed.

<a name='M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-BuildVote-RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Xml-Linq-XElement-'></a>
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

<a name='M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-GetBills-System-Threading-CancellationToken-'></a>
### GetBills(cancellationToken) `method`

##### Summary

Fetches all [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Returns

A collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-GetMembers-System-Threading-CancellationToken-'></a>
### GetMembers(cancellationToken) `method`

##### Summary

Fetches all [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Returns

A collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s to seed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') that triggers a cancellation. |

<a name='M-RemoteCongress-Utils-DataSeeder-SenateDataProvider-GetVotes-System-String,RemoteCongress-Common-VerifiedData{RemoteCongress-Common-Bill},System-Threading-CancellationToken-'></a>
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
