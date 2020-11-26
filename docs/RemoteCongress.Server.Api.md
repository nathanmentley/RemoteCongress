<a name='assembly'></a>
# RemoteCongress.Server.Api

## Contents

- [BaseCreateController\`1](#T-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1')
  - [Post(model)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Post-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1.Post(RemoteCongress.Common.VerifiedData{`0},System.Threading.CancellationToken)')
  - [Validate(model,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Validate-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1.Validate(RemoteCongress.Common.VerifiedData{`0},System.Threading.CancellationToken)')
- [BaseFetchCollectionController\`1](#T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController`1')
  - [Get()](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController`1.Get(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [BaseFetchController\`1](#T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1')
  - [Get(id)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Get-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1.Get(System.String,System.Threading.CancellationToken)')
  - [Validate(id,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Validate-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1.Validate(System.String,System.Threading.CancellationToken)')
- [CreateBillController](#T-RemoteCongress-Server-Api-Controllers-Bills-CreateBillController 'RemoteCongress.Server.Api.Controllers.Bills.CreateBillController')
- [CreateMemberController](#T-RemoteCongress-Server-Api-Controllers-Members-CreateMemberController 'RemoteCongress.Server.Api.Controllers.Members.CreateMemberController')
- [CreateVoteController](#T-RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController 'RemoteCongress.Server.Api.Controllers.Votes.CreateVoteController')
- [FetchBillController](#T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillController 'RemoteCongress.Server.Api.Controllers.Bills.FetchBillController')
- [FetchBillsController](#T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController 'RemoteCongress.Server.Api.Controllers.Bills.FetchBillsController')
- [FetchMemberController](#T-RemoteCongress-Server-Api-Controllers-Members-FetchMemberController 'RemoteCongress.Server.Api.Controllers.Members.FetchMemberController')
- [FetchMembersController](#T-RemoteCongress-Server-Api-Controllers-Members-FetchMembersController 'RemoteCongress.Server.Api.Controllers.Members.FetchMembersController')
- [FetchVoteController](#T-RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController 'RemoteCongress.Server.Api.Controllers.Votes.FetchVoteController')
- [FetchVotesController](#T-RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController 'RemoteCongress.Server.Api.Controllers.Votes.FetchVotesController')
- [MissingBodyException](#T-RemoteCongress-Server-Api-Exceptions-MissingBodyException 'RemoteCongress.Server.Api.Exceptions.MissingBodyException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.MissingBodyException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.MissingBodyException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor 'RemoteCongress.Server.Api.Exceptions.MissingBodyException.#ctor')
- [MissingPathParameterException](#T-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException.#ctor')
- [UnacceptableMediaTypeException](#T-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException.#ctor')
- [UnparsableMediaTypeException](#T-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException.#ctor')
- [VerifiedDataCollectionOutputFormatter\`1](#T-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1 'RemoteCongress.Server.Api.Formatters.VerifiedDataCollectionOutputFormatter`1')
  - [#ctor()](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1-#ctor-Microsoft-Extensions-Logging-ILogger,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}}}- 'RemoteCongress.Server.Api.Formatters.VerifiedDataCollectionOutputFormatter`1.#ctor(Microsoft.Extensions.Logging.ILogger,System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}})')
  - [CanWriteType(type)](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1-CanWriteType-System-Type- 'RemoteCongress.Server.Api.Formatters.VerifiedDataCollectionOutputFormatter`1.CanWriteType(System.Type)')
  - [WriteResponseBodyAsync(context,selectedEncoding)](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1-WriteResponseBodyAsync-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext,System-Text-Encoding- 'RemoteCongress.Server.Api.Formatters.VerifiedDataCollectionOutputFormatter`1.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext,System.Text.Encoding)')
- [VerifiedDataInputFormatter\`1](#T-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1 'RemoteCongress.Server.Api.Formatters.VerifiedDataInputFormatter`1')
  - [#ctor()](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1-#ctor-Microsoft-Extensions-Logging-ILogger,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{`0}}- 'RemoteCongress.Server.Api.Formatters.VerifiedDataInputFormatter`1.#ctor(Microsoft.Extensions.Logging.ILogger,System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{`0}})')
  - [CanReadType(type)](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1-CanReadType-System-Type- 'RemoteCongress.Server.Api.Formatters.VerifiedDataInputFormatter`1.CanReadType(System.Type)')
  - [ReadRequestBodyAsync(context,encoding)](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1-ReadRequestBodyAsync-Microsoft-AspNetCore-Mvc-Formatters-InputFormatterContext,System-Text-Encoding- 'RemoteCongress.Server.Api.Formatters.VerifiedDataInputFormatter`1.ReadRequestBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext,System.Text.Encoding)')
- [VerifiedDataOutputFormatter\`1](#T-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1 'RemoteCongress.Server.Api.Formatters.VerifiedDataOutputFormatter`1')
  - [#ctor()](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1-#ctor-Microsoft-Extensions-Logging-ILogger,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}}- 'RemoteCongress.Server.Api.Formatters.VerifiedDataOutputFormatter`1.#ctor(Microsoft.Extensions.Logging.ILogger,System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}})')
  - [CanWriteType(type)](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1-CanWriteType-System-Type- 'RemoteCongress.Server.Api.Formatters.VerifiedDataOutputFormatter`1.CanWriteType(System.Type)')
  - [WriteResponseBodyAsync(context,selectedEncoding)](#M-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1-WriteResponseBodyAsync-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext,System-Text-Encoding- 'RemoteCongress.Server.Api.Formatters.VerifiedDataOutputFormatter`1.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext,System.Text.Encoding)')

<a name='T-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1'></a>
## BaseCreateController\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Base

##### Summary

Exposes an endpoint to persist `TModel`s.

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Post-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken-'></a>
### Post(model) `method`

##### Summary

Persists a `TModel`.

##### Returns

The persisted, signed, and validiated `TModel`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [RemoteCongress.Common.VerifiedData{\`0}](#T-RemoteCongress-Common-VerifiedData{`0} 'RemoteCongress.Common.VerifiedData{`0}') | The `TModel` to persist. |

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Validate-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken-'></a>
### Validate(model,cancellationToken) `method`

##### Summary

Ensures that a create model request is valid.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [RemoteCongress.Common.VerifiedData{\`0}](#T-RemoteCongress-Common-VerifiedData{`0} 'RemoteCongress.Common.VerifiedData{`0}') | A `TModel` to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `model` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1'></a>
## BaseFetchCollectionController\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Base

##### Summary

Exposes an endpoint to fetch a [](#!-TModel 'TModel').

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### Get() `method`

##### Summary

Fetches all [](#!-TModel 'TModel')s.

##### Returns

The persisted, signed, and validiated [](#!-TModel 'TModel')s.

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1'></a>
## BaseFetchController\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Base

##### Summary

Exposes an endpoint to fetch a `TModel`.

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Get-System-String,System-Threading-CancellationToken-'></a>
### Get(id) `method`

##### Summary

Fetches a `TModel`.

##### Returns

The persisted, signed, and validiated `TModel`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the `TModel` to fetch. |

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Validate-System-String,System-Threading-CancellationToken-'></a>
### Validate(id,cancellationToken) `method`

##### Summary

Ensures that a fetch model request is valid.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | An id of a `TModel` to fetch. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `id` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if `cancellationToken` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Bills-CreateBillController'></a>
## CreateBillController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Bills

##### Summary

Exposes an endpoint to persist [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='T-RemoteCongress-Server-Api-Controllers-Members-CreateMemberController'></a>
## CreateMemberController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Members

##### Summary

Exposes an endpoint to persist [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='T-RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController'></a>
## CreateVoteController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Votes

##### Summary

Exposes an endpoint to persist [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillController'></a>
## FetchBillController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Bills

##### Summary

Exposes an endpoint to fetch a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

<a name='T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController'></a>
## FetchBillsController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Bills

##### Summary

Exposes an endpoint to fetch a collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='T-RemoteCongress-Server-Api-Controllers-Members-FetchMemberController'></a>
## FetchMemberController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Members

##### Summary

Exposes an endpoint to fetch a [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

<a name='T-RemoteCongress-Server-Api-Controllers-Members-FetchMembersController'></a>
## FetchMembersController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Members

##### Summary

Exposes an endpoint to fetch a collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='T-RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController'></a>
## FetchVoteController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Votes

##### Summary

Exposes an endpoint to fetch a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

<a name='T-RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController'></a>
## FetchVotesController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Votes

##### Summary

Exposes an endpoint to fetch a collection of [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='T-RemoteCongress-Server-Api-Exceptions-MissingBodyException'></a>
## MissingBodyException `type`

##### Namespace

RemoteCongress.Server.Api.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a request body is missing.

<a name='M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException'></a>
## MissingPathParameterException `type`

##### Namespace

RemoteCongress.Server.Api.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a path parameter is missing.

<a name='M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException'></a>
## UnacceptableMediaTypeException `type`

##### Namespace

RemoteCongress.Server.Api.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a request body is missing.

<a name='M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException'></a>
## UnparsableMediaTypeException `type`

##### Namespace

RemoteCongress.Server.Api.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a request body is missing.

<a name='M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1'></a>
## VerifiedDataCollectionOutputFormatter\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Formatters

##### Summary

Validates a signed [](#!-BaseBlockModel 'BaseBlockModel') and writes it to the http response [](#!-Stream 'Stream').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TData | Verified data model |

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1-#ctor-Microsoft-Extensions-Logging-ILogger,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}}}-'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1-CanWriteType-System-Type-'></a>
### CanWriteType(type) `method`

##### Summary

Checks if a [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') can be handled by this [TextOutputFormatter](#T-Microsoft-AspNetCore-Mvc-Formatters-TextOutputFormatter 'Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter').

##### Returns

True if `type` can be handled by this [TextOutputFormatter](#T-Microsoft-AspNetCore-Mvc-Formatters-TextOutputFormatter 'Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to test. |

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1-WriteResponseBodyAsync-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext,System-Text-Encoding-'></a>
### WriteResponseBodyAsync(context,selectedEncoding) `method`

##### Summary

Writes the signed and validated [](#!-BaseBlockModel 'BaseBlockModel') to the http response [](#!-Stream 'Stream').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext](#T-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext 'Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext') | The [OutputFormatterWriteContext](#T-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext 'Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext'). |
| selectedEncoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | The selected [Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding'). |

<a name='T-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1'></a>
## VerifiedDataInputFormatter\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Formatters

##### Summary

Reads and validates a signed [](#!-BaseBlockModel 'BaseBlockModel') from the input.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TData | Verified data model |

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1-#ctor-Microsoft-Extensions-Logging-ILogger,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{`0}}-'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1-CanReadType-System-Type-'></a>
### CanReadType(type) `method`

##### Summary

Checks if a [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') can be handled by this [TextInputFormatter](#T-Microsoft-AspNetCore-Mvc-Formatters-TextInputFormatter 'Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter').

##### Returns

True if `type` can be handled by this [TextInputFormatter](#T-Microsoft-AspNetCore-Mvc-Formatters-TextInputFormatter 'Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to test. |

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataInputFormatter`1-ReadRequestBodyAsync-Microsoft-AspNetCore-Mvc-Formatters-InputFormatterContext,System-Text-Encoding-'></a>
### ReadRequestBodyAsync(context,encoding) `method`

##### Summary

Reads a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') from a http request [](#!-Stream 'Stream').

##### Returns

A [Task](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task 'System.Threading.Tasks.Task') with the signed and validated [](#!-BaseBlockModel 'BaseBlockModel').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext](#T-Microsoft-AspNetCore-Mvc-Formatters-InputFormatterContext 'Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext') | The [InputFormatterContext](#T-Microsoft-AspNetCore-Mvc-Formatters-InputFormatterContext 'Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext'). |
| encoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | The selected [Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding'). |

<a name='T-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1'></a>
## VerifiedDataOutputFormatter\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Formatters

##### Summary

Validates a signed [](#!-BaseBlockModel 'BaseBlockModel') and writes it to the http response [](#!-Stream 'Stream').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TData | Verified data model |

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1-#ctor-Microsoft-Extensions-Logging-ILogger,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}}-'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1-CanWriteType-System-Type-'></a>
### CanWriteType(type) `method`

##### Summary

Checks if a [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') can be handled by this [TextOutputFormatter](#T-Microsoft-AspNetCore-Mvc-Formatters-TextOutputFormatter 'Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter').

##### Returns

True if `type` can be handled by this [TextOutputFormatter](#T-Microsoft-AspNetCore-Mvc-Formatters-TextOutputFormatter 'Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to test. |

<a name='M-RemoteCongress-Server-Api-Formatters-VerifiedDataOutputFormatter`1-WriteResponseBodyAsync-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext,System-Text-Encoding-'></a>
### WriteResponseBodyAsync(context,selectedEncoding) `method`

##### Summary

Writes the signed and validated [](#!-BaseBlockModel 'BaseBlockModel') to the http response [](#!-Stream 'Stream').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext](#T-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext 'Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext') | The [OutputFormatterWriteContext](#T-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext 'Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext'). |
| selectedEncoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | The selected [Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding'). |
