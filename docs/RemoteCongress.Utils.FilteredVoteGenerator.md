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
- [IApp](#T-RemoteCongress-Util-FilteredVoteGenerator-IApp 'RemoteCongress.Util.FilteredVoteGenerator.IApp')
  - [Run(cancellationToken)](#M-RemoteCongress-Util-FilteredVoteGenerator-IApp-Run-System-Threading-CancellationToken- 'RemoteCongress.Util.FilteredVoteGenerator.IApp.Run(System.Threading.CancellationToken)')
- [Program](#T-RemoteCongress-Util-FilteredVoteGenerator-Program 'RemoteCongress.Util.FilteredVoteGenerator.Program')
  - [Hostname](#F-RemoteCongress-Util-FilteredVoteGenerator-Program-Hostname 'RemoteCongress.Util.FilteredVoteGenerator.Program.Hostname')
  - [Protocol](#F-RemoteCongress-Util-FilteredVoteGenerator-Program-Protocol 'RemoteCongress.Util.FilteredVoteGenerator.Program.Protocol')
  - [GetCancellationTokenSource()](#M-RemoteCongress-Util-FilteredVoteGenerator-Program-GetCancellationTokenSource 'RemoteCongress.Util.FilteredVoteGenerator.Program.GetCancellationTokenSource')
  - [GetServiceProvider(config)](#M-RemoteCongress-Util-FilteredVoteGenerator-Program-GetServiceProvider-RemoteCongress-Client-DAL-Http-ClientConfig- 'RemoteCongress.Util.FilteredVoteGenerator.Program.GetServiceProvider(RemoteCongress.Client.DAL.Http.ClientConfig)')
  - [Main(args)](#M-RemoteCongress-Util-FilteredVoteGenerator-Program-Main-System-String[]- 'RemoteCongress.Util.FilteredVoteGenerator.Program.Main(System.String[])')

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
