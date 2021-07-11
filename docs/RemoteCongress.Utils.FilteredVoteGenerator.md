<a name='assembly'></a>
# RemoteCongress.Utils.FilteredVoteGenerator

## Contents

- [App](#T-RemoteCongress-Util-FilteredVoteGenerator-App 'RemoteCongress.Util.FilteredVoteGenerator.App')
  - [#ctor(logger,client)](#M-RemoteCongress-Util-FilteredVoteGenerator-App-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Util-FilteredVoteGenerator-App},RemoteCongress-Client-IRemoteCongressClient- 'RemoteCongress.Util.FilteredVoteGenerator.App.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Util.FilteredVoteGenerator.App},RemoteCongress.Client.IRemoteCongressClient)')
  - [_client](#F-RemoteCongress-Util-FilteredVoteGenerator-App-_client 'RemoteCongress.Util.FilteredVoteGenerator.App._client')
  - [_logger](#F-RemoteCongress-Util-FilteredVoteGenerator-App-_logger 'RemoteCongress.Util.FilteredVoteGenerator.App._logger')
  - [Logic(cancellationToken)](#M-RemoteCongress-Util-FilteredVoteGenerator-App-Logic-System-Threading-CancellationToken- 'RemoteCongress.Util.FilteredVoteGenerator.App.Logic(System.Threading.CancellationToken)')
  - [Run(cancellationToken)](#M-RemoteCongress-Util-FilteredVoteGenerator-App-Run-System-Threading-CancellationToken- 'RemoteCongress.Util.FilteredVoteGenerator.App.Run(System.Threading.CancellationToken)')
- [AppResultCode](#T-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode 'RemoteCongress.Util.FilteredVoteGenerator.AppResultCode')
  - [OperationCancelled](#F-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode-OperationCancelled 'RemoteCongress.Util.FilteredVoteGenerator.AppResultCode.OperationCancelled')
  - [Success](#F-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode-Success 'RemoteCongress.Util.FilteredVoteGenerator.AppResultCode.Success')
  - [UnknownError](#F-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode-UnknownError 'RemoteCongress.Util.FilteredVoteGenerator.AppResultCode.UnknownError')
- [BillResult](#T-RemoteCongress-Util-FilteredVoteGenerator-BillResult 'RemoteCongress.Util.FilteredVoteGenerator.BillResult')
  - [Bill](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-Bill 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.Bill')
  - [BillId](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-BillId 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.BillId')
  - [BillLegitimatelyPassed](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-BillLegitimatelyPassed 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.BillLegitimatelyPassed')
  - [BillPassed](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-BillPassed 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.BillPassed')
  - [InvalidNays](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-InvalidNays 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.InvalidNays')
  - [InvalidPresents](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-InvalidPresents 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.InvalidPresents')
  - [InvalidYays](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-InvalidYays 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.InvalidYays')
  - [ValidNays](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-ValidNays 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.ValidNays')
  - [ValidPresents](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-ValidPresents 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.ValidPresents')
  - [ValidYays](#P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-ValidYays 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.ValidYays')
  - [AddVote(vote)](#M-RemoteCongress-Util-FilteredVoteGenerator-BillResult-AddVote-RemoteCongress-Util-FilteredVoteGenerator-VoteResult- 'RemoteCongress.Util.FilteredVoteGenerator.BillResult.AddVote(RemoteCongress.Util.FilteredVoteGenerator.VoteResult)')
- [IApp](#T-RemoteCongress-Util-FilteredVoteGenerator-IApp 'RemoteCongress.Util.FilteredVoteGenerator.IApp')
  - [Run(cancellationToken)](#M-RemoteCongress-Util-FilteredVoteGenerator-IApp-Run-System-Threading-CancellationToken- 'RemoteCongress.Util.FilteredVoteGenerator.IApp.Run(System.Threading.CancellationToken)')
- [Program](#T-RemoteCongress-Util-FilteredVoteGenerator-Program 'RemoteCongress.Util.FilteredVoteGenerator.Program')
  - [Hostname](#F-RemoteCongress-Util-FilteredVoteGenerator-Program-Hostname 'RemoteCongress.Util.FilteredVoteGenerator.Program.Hostname')
  - [Protocol](#F-RemoteCongress-Util-FilteredVoteGenerator-Program-Protocol 'RemoteCongress.Util.FilteredVoteGenerator.Program.Protocol')
  - [GetCancellationTokenSource()](#M-RemoteCongress-Util-FilteredVoteGenerator-Program-GetCancellationTokenSource 'RemoteCongress.Util.FilteredVoteGenerator.Program.GetCancellationTokenSource')
  - [GetServiceProvider(config)](#M-RemoteCongress-Util-FilteredVoteGenerator-Program-GetServiceProvider-RemoteCongress-Client-DAL-Http-ClientConfig- 'RemoteCongress.Util.FilteredVoteGenerator.Program.GetServiceProvider(RemoteCongress.Client.DAL.Http.ClientConfig)')
  - [Main(args)](#M-RemoteCongress-Util-FilteredVoteGenerator-Program-Main-System-String[]- 'RemoteCongress.Util.FilteredVoteGenerator.Program.Main(System.String[])')
- [VoteResult](#T-RemoteCongress-Util-FilteredVoteGenerator-VoteResult 'RemoteCongress.Util.FilteredVoteGenerator.VoteResult')
  - [IsInvalid](#P-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-IsInvalid 'RemoteCongress.Util.FilteredVoteGenerator.VoteResult.IsInvalid')
  - [Member](#P-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-Member 'RemoteCongress.Util.FilteredVoteGenerator.VoteResult.Member')
  - [Opinion](#P-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-Opinion 'RemoteCongress.Util.FilteredVoteGenerator.VoteResult.Opinion')

<a name='T-RemoteCongress-Util-FilteredVoteGenerator-App'></a>
## App `type`

##### Namespace

RemoteCongress.Util.FilteredVoteGenerator

##### Summary

Application logic.

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-App-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Util-FilteredVoteGenerator-App},RemoteCongress-Client-IRemoteCongressClient-'></a>
### #ctor(logger,client) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Util.FilteredVoteGenerator.App}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Util-FilteredVoteGenerator-App} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Util.FilteredVoteGenerator.App}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against. |
| client | [RemoteCongress.Client.IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') | The [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `client` is null. |

<a name='F-RemoteCongress-Util-FilteredVoteGenerator-App-_client'></a>
### _client `constants`

##### Summary

The [IRemoteCongressClient](#T-RemoteCongress-Client-IRemoteCongressClient 'RemoteCongress.Client.IRemoteCongressClient') to seed against.

<a name='F-RemoteCongress-Util-FilteredVoteGenerator-App-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log against.

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-App-Logic-System-Threading-CancellationToken-'></a>
### Logic(cancellationToken) `method`

##### Summary

Runs the logic to seed data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-App-Run-System-Threading-CancellationToken-'></a>
### Run(cancellationToken) `method`

##### Summary

Runs the seed data logic.

##### Returns

The result code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode'></a>
## AppResultCode `type`

##### Namespace

RemoteCongress.Util.FilteredVoteGenerator

##### Summary



<a name='F-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode-OperationCancelled'></a>
### OperationCancelled `constants`

##### Summary



<a name='F-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode-Success'></a>
### Success `constants`

##### Summary



<a name='F-RemoteCongress-Util-FilteredVoteGenerator-AppResultCode-UnknownError'></a>
### UnknownError `constants`

##### Summary



<a name='T-RemoteCongress-Util-FilteredVoteGenerator-BillResult'></a>
## BillResult `type`

##### Namespace

RemoteCongress.Util.FilteredVoteGenerator

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-Bill'></a>
### Bill `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-BillId'></a>
### BillId `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-BillLegitimatelyPassed'></a>
### BillLegitimatelyPassed `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-BillPassed'></a>
### BillPassed `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-InvalidNays'></a>
### InvalidNays `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-InvalidPresents'></a>
### InvalidPresents `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-InvalidYays'></a>
### InvalidYays `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-ValidNays'></a>
### ValidNays `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-ValidPresents'></a>
### ValidPresents `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-BillResult-ValidYays'></a>
### ValidYays `property`

##### Summary



<a name='M-RemoteCongress-Util-FilteredVoteGenerator-BillResult-AddVote-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-'></a>
### AddVote(vote) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vote | [RemoteCongress.Util.FilteredVoteGenerator.VoteResult](#T-RemoteCongress-Util-FilteredVoteGenerator-VoteResult 'RemoteCongress.Util.FilteredVoteGenerator.VoteResult') |  |

<a name='T-RemoteCongress-Util-FilteredVoteGenerator-IApp'></a>
## IApp `type`

##### Namespace

RemoteCongress.Util.FilteredVoteGenerator

##### Summary

Application logic.

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-IApp-Run-System-Threading-CancellationToken-'></a>
### Run(cancellationToken) `method`

##### Summary

Runs application logic.

##### Returns

The result code from the logic.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Util-FilteredVoteGenerator-Program'></a>
## Program `type`

##### Namespace

RemoteCongress.Util.FilteredVoteGenerator

##### Summary

Entry point class.

<a name='F-RemoteCongress-Util-FilteredVoteGenerator-Program-Hostname'></a>
### Hostname `constants`

##### Summary

The hardcoded hostname to seed against

##### Remarks

TODO: Provide this from the cli.

<a name='F-RemoteCongress-Util-FilteredVoteGenerator-Program-Protocol'></a>
### Protocol `constants`

##### Summary

The hardcoded protocol to seed against

##### Remarks

TODO: Provide this from the cli.

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-Program-GetCancellationTokenSource'></a>
### GetCancellationTokenSource() `method`

##### Summary

Sets up the [CancellationTokenSource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource') for the cli application.

##### Returns

A [CancellationTokenSource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource') linked to the application cancellation event.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-Program-GetServiceProvider-RemoteCongress-Client-DAL-Http-ClientConfig-'></a>
### GetServiceProvider(config) `method`

##### Summary

Sets up the [ServiceProvider](#T-Microsoft-Extensions-DependencyInjection-ServiceProvider 'Microsoft.Extensions.DependencyInjection.ServiceProvider') and registers the Remote Congress client in DI.

##### Returns

The DI [ServiceProvider](#T-Microsoft-Extensions-DependencyInjection-ServiceProvider 'Microsoft.Extensions.DependencyInjection.ServiceProvider').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| config | [RemoteCongress.Client.DAL.Http.ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') | The [ClientConfig](#T-RemoteCongress-Client-DAL-Http-ClientConfig 'RemoteCongress.Client.DAL.Http.ClientConfig') to use to configure the RemoteCongress client instances. |

<a name='M-RemoteCongress-Util-FilteredVoteGenerator-Program-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

Runs the application logic

##### Returns

Result code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Command line arguments |

<a name='T-RemoteCongress-Util-FilteredVoteGenerator-VoteResult'></a>
## VoteResult `type`

##### Namespace

RemoteCongress.Util.FilteredVoteGenerator

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-IsInvalid'></a>
### IsInvalid `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-Member'></a>
### Member `property`

##### Summary



<a name='P-RemoteCongress-Util-FilteredVoteGenerator-VoteResult-Opinion'></a>
### Opinion `property`

##### Summary


