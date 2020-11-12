<a name='assembly'></a>
# RemoteCongress.Server.DataSeeder

## Contents

- [IDataProvider](#T-RemoteCongress-Server-DataSeeder-IDataProvider 'RemoteCongress.Server.DataSeeder.IDataProvider')
- [IKeyGenerator](#T-RemoteCongress-Server-DataSeeder-IKeyGenerator 'RemoteCongress.Server.DataSeeder.IKeyGenerator')
  - [GenerateKeys(bit,cancellationToken)](#M-RemoteCongress-Server-DataSeeder-IKeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.IKeyGenerator.GenerateKeys(System.Int32,System.Threading.CancellationToken)')
- [KeyGenerator](#T-RemoteCongress-Server-DataSeeder-KeyGenerator 'RemoteCongress.Server.DataSeeder.KeyGenerator')
  - [#ctor(logger)](#M-RemoteCongress-Server-DataSeeder-KeyGenerator-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-DataSeeder-KeyGenerator}- 'RemoteCongress.Server.DataSeeder.KeyGenerator.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.DataSeeder.KeyGenerator})')
  - [ExportPrivateKey(csp)](#M-RemoteCongress-Server-DataSeeder-KeyGenerator-ExportPrivateKey-System-Security-Cryptography-RSACryptoServiceProvider- 'RemoteCongress.Server.DataSeeder.KeyGenerator.ExportPrivateKey(System.Security.Cryptography.RSACryptoServiceProvider)')
  - [ExportPublicKey(csp)](#M-RemoteCongress-Server-DataSeeder-KeyGenerator-ExportPublicKey-System-Security-Cryptography-RSACryptoServiceProvider- 'RemoteCongress.Server.DataSeeder.KeyGenerator.ExportPublicKey(System.Security.Cryptography.RSACryptoServiceProvider)')
  - [GenerateKeys(bit,cancellationToken)](#M-RemoteCongress-Server-DataSeeder-KeyGenerator-GenerateKeys-System-Int32,System-Threading-CancellationToken- 'RemoteCongress.Server.DataSeeder.KeyGenerator.GenerateKeys(System.Int32,System.Threading.CancellationToken)')
- [Program](#T-RemoteCongress-Server-DataSeeder-Program 'RemoteCongress.Server.DataSeeder.Program')
  - [AdminPrivateKey](#F-RemoteCongress-Server-DataSeeder-Program-AdminPrivateKey 'RemoteCongress.Server.DataSeeder.Program.AdminPrivateKey')
  - [AdminPublicKey](#F-RemoteCongress-Server-DataSeeder-Program-AdminPublicKey 'RemoteCongress.Server.DataSeeder.Program.AdminPublicKey')

<a name='T-RemoteCongress-Server-DataSeeder-IDataProvider'></a>
## IDataProvider `type`

##### Namespace

RemoteCongress.Server.DataSeeder

##### Summary

An interface that defines a type that's able to provide data for seeding

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

<a name='M-RemoteCongress-Server-DataSeeder-KeyGenerator-ExportPrivateKey-System-Security-Cryptography-RSACryptoServiceProvider-'></a>
### ExportPrivateKey(csp) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| csp | [System.Security.Cryptography.RSACryptoServiceProvider](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Cryptography.RSACryptoServiceProvider 'System.Security.Cryptography.RSACryptoServiceProvider') |  |

<a name='M-RemoteCongress-Server-DataSeeder-KeyGenerator-ExportPublicKey-System-Security-Cryptography-RSACryptoServiceProvider-'></a>
### ExportPublicKey(csp) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| csp | [System.Security.Cryptography.RSACryptoServiceProvider](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Cryptography.RSACryptoServiceProvider 'System.Security.Cryptography.RSACryptoServiceProvider') |  |

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

<a name='F-RemoteCongress-Server-DataSeeder-Program-AdminPrivateKey'></a>
### AdminPrivateKey `constants`

##### Remarks

Throw away private / pub key

<a name='F-RemoteCongress-Server-DataSeeder-Program-AdminPublicKey'></a>
### AdminPublicKey `constants`

##### Remarks

Throw away private / pub key
