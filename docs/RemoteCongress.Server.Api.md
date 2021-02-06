<a name='assembly'></a>
# RemoteCongress.Server.Api

## Contents

- [BaseCreateController\`1](#T-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseCreateController{`0}},RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}- 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseCreateController{`0}},RemoteCongress.Common.Repositories.IImmutableDataRepository{`0})')
  - [Post(model,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Post-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1.Post(RemoteCongress.Common.VerifiedData{`0},System.Threading.CancellationToken)')
  - [Validate(model,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Validate-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseCreateController`1.Validate(RemoteCongress.Common.VerifiedData{`0},System.Threading.CancellationToken)')
- [BaseExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.BaseExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger- 'RemoteCongress.Server.Api.ExceptionFilters.BaseExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger)')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.BaseExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.BaseExceptionFilter.CanHandle(System.Exception)')
  - [Logic(context)](#M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-Logic-Microsoft-AspNetCore-Mvc-Filters-ExceptionContext- 'RemoteCongress.Server.Api.ExceptionFilters.BaseExceptionFilter.Logic(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)')
  - [OnExceptionAsync(context)](#M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-OnExceptionAsync-Microsoft-AspNetCore-Mvc-Filters-ExceptionContext- 'RemoteCongress.Server.Api.ExceptionFilters.BaseExceptionFilter.OnExceptionAsync(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)')
- [BaseFetchCollectionController\`1](#T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController`1')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController{`0}},RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController`1.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController{`0}},RemoteCongress.Common.Repositories.IImmutableDataRepository{`0})')
  - [Get(query,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController`1.Get(System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [BaseFetchController\`1](#T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseFetchController{`0}},RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseFetchController{`0}},RemoteCongress.Common.Repositories.IImmutableDataRepository{`0})')
  - [Get(id,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Get-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1.Get(System.String,System.Threading.CancellationToken)')
  - [Validate(id,cancellationToken)](#M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Validate-System-String,System-Threading-CancellationToken- 'RemoteCongress.Server.Api.Controllers.Base.BaseFetchController`1.Validate(System.String,System.Threading.CancellationToken)')
- [BlockNotFoundExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter.CanHandle(System.Exception)')
- [BlockNotStorableExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter.CanHandle(System.Exception)')
- [BuildFromQueryAttribute](#T-RemoteCongress-Server-Api-ModelBinders-BuildFromQueryAttribute 'RemoteCongress.Server.Api.ModelBinders.BuildFromQueryAttribute')
  - [#ctor()](#M-RemoteCongress-Server-Api-ModelBinders-BuildFromQueryAttribute-#ctor 'RemoteCongress.Server.Api.ModelBinders.BuildFromQueryAttribute.#ctor')
- [ConfigureMvcOptions](#T-RemoteCongress-Server-Api-ConfigureMvcOptions 'RemoteCongress.Server.Api.ConfigureMvcOptions')
  - [#ctor(logger,loggerFactory,signedDataCodecs,signedDataCollectionCodecs,billDataCodecs,memberDataCodecs,voteDataCodecs)](#M-RemoteCongress-Server-Api-ConfigureMvcOptions-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ConfigureMvcOptions},Microsoft-Extensions-Logging-ILoggerFactory,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Bill}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Member}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Vote}}- 'RemoteCongress.Server.Api.ConfigureMvcOptions.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ConfigureMvcOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Bill}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Member}},System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Vote}})')
  - [Configure(options)](#M-RemoteCongress-Server-Api-ConfigureMvcOptions-Configure-Microsoft-AspNetCore-Mvc-MvcOptions- 'RemoteCongress.Server.Api.ConfigureMvcOptions.Configure(Microsoft.AspNetCore.Mvc.MvcOptions)')
- [CreateBillController](#T-RemoteCongress-Server-Api-Controllers-Bills-CreateBillController 'RemoteCongress.Server.Api.Controllers.Bills.CreateBillController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Bills-CreateBillController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-CreateBillController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill}- 'RemoteCongress.Server.Api.Controllers.Bills.CreateBillController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.CreateBillController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill})')
- [CreateMemberController](#T-RemoteCongress-Server-Api-Controllers-Members-CreateMemberController 'RemoteCongress.Server.Api.Controllers.Members.CreateMemberController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Members-CreateMemberController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-CreateMemberController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member}- 'RemoteCongress.Server.Api.Controllers.Members.CreateMemberController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.CreateMemberController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member})')
- [CreateVoteController](#T-RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController 'RemoteCongress.Server.Api.Controllers.Votes.CreateVoteController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}- 'RemoteCongress.Server.Api.Controllers.Votes.CreateVoteController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.CreateVoteController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote})')
- [FetchBillController](#T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillController 'RemoteCongress.Server.Api.Controllers.Bills.FetchBillController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Bills-FetchBillController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-FetchBillController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill}- 'RemoteCongress.Server.Api.Controllers.Bills.FetchBillController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.FetchBillController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill})')
- [FetchBillsController](#T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController 'RemoteCongress.Server.Api.Controllers.Bills.FetchBillsController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill}- 'RemoteCongress.Server.Api.Controllers.Bills.FetchBillsController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.FetchBillsController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill})')
- [FetchMemberController](#T-RemoteCongress-Server-Api-Controllers-Members-FetchMemberController 'RemoteCongress.Server.Api.Controllers.Members.FetchMemberController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Members-FetchMemberController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-FetchMemberController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member}- 'RemoteCongress.Server.Api.Controllers.Members.FetchMemberController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.FetchMemberController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member})')
- [FetchMembersController](#T-RemoteCongress-Server-Api-Controllers-Members-FetchMembersController 'RemoteCongress.Server.Api.Controllers.Members.FetchMembersController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Members-FetchMembersController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-FetchMembersController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member}- 'RemoteCongress.Server.Api.Controllers.Members.FetchMembersController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.FetchMembersController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member})')
- [FetchVoteController](#T-RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController 'RemoteCongress.Server.Api.Controllers.Votes.FetchVoteController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}- 'RemoteCongress.Server.Api.Controllers.Votes.FetchVoteController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.FetchVoteController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote})')
- [FetchVotesController](#T-RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController 'RemoteCongress.Server.Api.Controllers.Votes.FetchVotesController')
  - [#ctor(logger,repository)](#M-RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}- 'RemoteCongress.Server.Api.Controllers.Votes.FetchVotesController.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.FetchVotesController},RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote})')
- [InvalidBlockSignatureExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter.CanHandle(System.Exception)')
- [MissingBodyException](#T-RemoteCongress-Server-Api-Exceptions-MissingBodyException 'RemoteCongress.Server.Api.Exceptions.MissingBodyException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.MissingBodyException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.MissingBodyException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-MissingBodyException-#ctor 'RemoteCongress.Server.Api.Exceptions.MissingBodyException.#ctor')
- [MissingBodyExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter.CanHandle(System.Exception)')
- [MissingPathParameterException](#T-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException-#ctor 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException.#ctor')
- [MissingPathParameterExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter.CanHandle(System.Exception)')
- [Program](#T-RemoteCongress-Server-Api-Program 'RemoteCongress.Server.Api.Program')
  - [CreateHostBuilder(args)](#M-RemoteCongress-Server-Api-Program-CreateHostBuilder-System-String[]- 'RemoteCongress.Server.Api.Program.CreateHostBuilder(System.String[])')
  - [Main(args)](#M-RemoteCongress-Server-Api-Program-Main-System-String[]- 'RemoteCongress.Server.Api.Program.Main(System.String[])')
- [QueryModelBinder](#T-RemoteCongress-Server-Api-ModelBinders-QueryModelBinder 'RemoteCongress.Server.Api.ModelBinders.QueryModelBinder')
  - [#ctor(codec)](#M-RemoteCongress-Server-Api-ModelBinders-QueryModelBinder-#ctor-RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Repositories-Queries-IQuery}- 'RemoteCongress.Server.Api.ModelBinders.QueryModelBinder.#ctor(RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Repositories.Queries.IQuery})')
  - [BindModelAsync(bindingContext)](#M-RemoteCongress-Server-Api-ModelBinders-QueryModelBinder-BindModelAsync-Microsoft-AspNetCore-Mvc-ModelBinding-ModelBindingContext- 'RemoteCongress.Server.Api.ModelBinders.QueryModelBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)')
- [Startup](#T-RemoteCongress-Server-Api-Startup 'RemoteCongress.Server.Api.Startup')
  - [#ctor(configuration)](#M-RemoteCongress-Server-Api-Startup-#ctor-Microsoft-Extensions-Configuration-IConfiguration- 'RemoteCongress.Server.Api.Startup.#ctor(Microsoft.Extensions.Configuration.IConfiguration)')
  - [Configure(app,env)](#M-RemoteCongress-Server-Api-Startup-Configure-Microsoft-AspNetCore-Builder-IApplicationBuilder,Microsoft-AspNetCore-Hosting-IWebHostEnvironment- 'RemoteCongress.Server.Api.Startup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder,Microsoft.AspNetCore.Hosting.IWebHostEnvironment)')
  - [ConfigureServices(services)](#M-RemoteCongress-Server-Api-Startup-ConfigureServices-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'RemoteCongress.Server.Api.Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
- [UnacceptableMediaTypeException](#T-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException-#ctor 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException.#ctor')
- [UnacceptableMediaTypeExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter.CanHandle(System.Exception)')
- [UnknownBlockMediaTypeExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter.CanHandle(System.Exception)')
- [UnparsableMediaTypeException](#T-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor-System-String,System-Exception- 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor-System-String- 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException-#ctor 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException.#ctor')
- [UnparsableMediaTypeExceptionFilter](#T-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter 'RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter')
  - [#ctor(logger)](#M-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter}- 'RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter})')
  - [StatusCode](#P-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter-StatusCode 'RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter.StatusCode')
  - [CanHandle(exception)](#M-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter-CanHandle-System-Exception- 'RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter.CanHandle(System.Exception)')
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

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseCreateController{`0}},RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseCreateController{\`0}}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseCreateController{`0}} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseCreateController{`0}}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{\`0}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{`0} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{`0}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseCreateController`1-Post-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken-'></a>
### Post(model,cancellationToken) `method`

##### Summary

Persists a `TModel`.

##### Returns

The persisted, signed, and validiated `TModel`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [RemoteCongress.Common.VerifiedData{\`0}](#T-RemoteCongress-Common-VerifiedData{`0} 'RemoteCongress.Common.VerifiedData{`0}') | The `TModel` to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

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

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter'></a>
## BaseExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An abstract excpetion handler implementation to transform exceptions into http status codes.

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-Logic-Microsoft-AspNetCore-Mvc-Filters-ExceptionContext-'></a>
### Logic(context) `method`

##### Summary

Updates the status code for the response.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Filters.ExceptionContext](#T-Microsoft-AspNetCore-Mvc-Filters-ExceptionContext 'Microsoft.AspNetCore.Mvc.Filters.ExceptionContext') | The exception context of the exceptional event. |

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BaseExceptionFilter-OnExceptionAsync-Microsoft-AspNetCore-Mvc-Filters-ExceptionContext-'></a>
### OnExceptionAsync(context) `method`

##### Summary

Tests and runs this handle for an exceptional event

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Filters.ExceptionContext](#T-Microsoft-AspNetCore-Mvc-Filters-ExceptionContext 'Microsoft.AspNetCore.Mvc.Filters.ExceptionContext') | The exception context of the exceptional event. |

<a name='T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1'></a>
## BaseFetchCollectionController\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Base

##### Summary

Exposes an endpoint to fetch a `TModel`.

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController{`0}},RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController{\`0}}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController{`0}} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseFetchCollectionController{`0}}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{\`0}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{`0} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{`0}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchCollectionController`1-Get-System-Collections-Generic-IList{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### Get(query,cancellationToken) `method`

##### Summary

Fetches all `TModel`s.

##### Returns

The persisted, signed, and validated `TModel`s.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter the result by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

<a name='T-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1'></a>
## BaseFetchController\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Base

##### Summary

Exposes an endpoint to fetch a `TModel`.

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseFetchController{`0}},RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseFetchController{\`0}}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Base-BaseFetchController{`0}} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Base.BaseFetchController{`0}}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{\`0}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{`0} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{`0}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='M-RemoteCongress-Server-Api-Controllers-Base-BaseFetchController`1-Get-System-String,System-Threading-CancellationToken-'></a>
### Get(id,cancellationToken) `method`

##### Summary

Fetches a `TModel`.

##### Returns

The persisted, signed, and validiated `TModel`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the `TModel` to fetch. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation. |

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

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter'></a>
## BlockNotFoundExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [BlockNotFoundException](#T-RemoteCongress-Common-Exceptions-BlockNotFoundException 'RemoteCongress.Common.Exceptions.BlockNotFoundException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.BlockNotFoundExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotFoundExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter'></a>
## BlockNotStorableExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [BlockNotStorableException](#T-RemoteCongress-Common-Exceptions-BlockNotStorableException 'RemoteCongress.Common.Exceptions.BlockNotStorableException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.BlockNotStorableExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-BlockNotStorableExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

<a name='T-RemoteCongress-Server-Api-ModelBinders-BuildFromQueryAttribute'></a>
## BuildFromQueryAttribute `type`

##### Namespace

RemoteCongress.Server.Api.ModelBinders

##### Summary

An attribute to build [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') from the query string.

<a name='M-RemoteCongress-Server-Api-ModelBinders-BuildFromQueryAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Server-Api-ConfigureMvcOptions'></a>
## ConfigureMvcOptions `type`

##### Namespace

RemoteCongress.Server.Api

##### Summary



<a name='M-RemoteCongress-Server-Api-ConfigureMvcOptions-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ConfigureMvcOptions},Microsoft-Extensions-Logging-ILoggerFactory,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-SignedData}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Bill}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Member}},System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Vote}}-'></a>
### #ctor(logger,loggerFactory,signedDataCodecs,signedDataCollectionCodecs,billDataCodecs,memberDataCodecs,voteDataCodecs) `constructor`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ConfigureMvcOptions}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ConfigureMvcOptions} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ConfigureMvcOptions}') |  |
| loggerFactory | [Microsoft.Extensions.Logging.ILoggerFactory](#T-Microsoft-Extensions-Logging-ILoggerFactory 'Microsoft.Extensions.Logging.ILoggerFactory') |  |
| signedDataCodecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.SignedData}}') |  |
| signedDataCollectionCodecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}}}') |  |
| billDataCodecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Bill}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Bill}}') |  |
| memberDataCodecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Member}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Member}}') |  |
| voteDataCodecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Vote}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Vote}}') |  |

<a name='M-RemoteCongress-Server-Api-ConfigureMvcOptions-Configure-Microsoft-AspNetCore-Mvc-MvcOptions-'></a>
### Configure(options) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [Microsoft.AspNetCore.Mvc.MvcOptions](#T-Microsoft-AspNetCore-Mvc-MvcOptions 'Microsoft.AspNetCore.Mvc.MvcOptions') |  |

<a name='T-RemoteCongress-Server-Api-Controllers-Bills-CreateBillController'></a>
## CreateBillController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Bills

##### Summary

Exposes an endpoint to persist [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='M-RemoteCongress-Server-Api-Controllers-Bills-CreateBillController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-CreateBillController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.CreateBillController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-CreateBillController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.CreateBillController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Members-CreateMemberController'></a>
## CreateMemberController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Members

##### Summary

Exposes an endpoint to persist [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='M-RemoteCongress-Server-Api-Controllers-Members-CreateMemberController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-CreateMemberController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.CreateMemberController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-CreateMemberController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.CreateMemberController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController'></a>
## CreateVoteController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Votes

##### Summary

Exposes an endpoint to persist [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='M-RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.CreateVoteController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-CreateVoteController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.CreateVoteController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillController'></a>
## FetchBillController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Bills

##### Summary

Exposes an endpoint to fetch a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

<a name='M-RemoteCongress-Server-Api-Controllers-Bills-FetchBillController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-FetchBillController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.FetchBillController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-FetchBillController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.FetchBillController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController'></a>
## FetchBillsController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Bills

##### Summary

Exposes an endpoint to fetch a collection of [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')s.

<a name='M-RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.FetchBillsController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Bills-FetchBillsController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Bills.FetchBillsController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Bill} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Bill}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Members-FetchMemberController'></a>
## FetchMemberController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Members

##### Summary

Exposes an endpoint to fetch a [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

<a name='M-RemoteCongress-Server-Api-Controllers-Members-FetchMemberController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-FetchMemberController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.FetchMemberController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-FetchMemberController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.FetchMemberController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Members-FetchMembersController'></a>
## FetchMembersController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Members

##### Summary

Exposes an endpoint to fetch a collection of [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')s.

<a name='M-RemoteCongress-Server-Api-Controllers-Members-FetchMembersController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-FetchMembersController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.FetchMembersController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Members-FetchMembersController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Members.FetchMembersController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Member} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Member}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController'></a>
## FetchVoteController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Votes

##### Summary

Exposes an endpoint to fetch a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

<a name='M-RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.FetchVoteController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-FetchVoteController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.FetchVoteController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController'></a>
## FetchVotesController `type`

##### Namespace

RemoteCongress.Server.Api.Controllers.Votes

##### Summary

Exposes an endpoint to fetch a collection of [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='M-RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController},RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote}-'></a>
### #ctor(logger,repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.FetchVotesController}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-Controllers-Votes-FetchVotesController} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.Controllers.Votes.FetchVotesController}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| repository | [RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository{RemoteCongress-Common-Vote} 'RemoteCongress.Common.Repositories.IImmutableDataRepository{RemoteCongress.Common.Vote}') | An [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `repository` is null. |

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter'></a>
## InvalidBlockSignatureExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [InvalidBlockSignatureException](#T-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.InvalidBlockSignatureExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-InvalidBlockSignatureExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

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

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter'></a>
## MissingBodyExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [MissingBodyException](#T-RemoteCongress-Server-Api-Exceptions-MissingBodyException 'RemoteCongress.Server.Api.Exceptions.MissingBodyException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.MissingBodyExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-MissingBodyExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

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

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter'></a>
## MissingPathParameterExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [MissingPathParameterException](#T-RemoteCongress-Server-Api-Exceptions-MissingPathParameterException 'RemoteCongress.Server.Api.Exceptions.MissingPathParameterException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.MissingPathParameterExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-MissingPathParameterExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

<a name='T-RemoteCongress-Server-Api-Program'></a>
## Program `type`

##### Namespace

RemoteCongress.Server.Api

##### Summary

The entrypoint class

<a name='M-RemoteCongress-Server-Api-Program-CreateHostBuilder-System-String[]-'></a>
### CreateHostBuilder(args) `method`

##### Summary

Setsup the post builder for the api server.

##### Returns

An [IHostBuilder](#T-Microsoft-Extensions-Hosting-IHostBuilder 'Microsoft.Extensions.Hosting.IHostBuilder') configured to build the api server host.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Arguments passed to the program when it was called. |

<a name='M-RemoteCongress-Server-Api-Program-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

The entrypoint method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Arguments passed to the program when it was called. |

<a name='T-RemoteCongress-Server-Api-ModelBinders-QueryModelBinder'></a>
## QueryModelBinder `type`

##### Namespace

RemoteCongress.Server.Api.ModelBinders

##### Summary

A [IModelBinder](#T-Microsoft-AspNetCore-Mvc-ModelBinding-IModelBinder 'Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder') implementation for [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s.

<a name='M-RemoteCongress-Server-Api-ModelBinders-QueryModelBinder-#ctor-RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Repositories-Queries-IQuery}-'></a>
### #ctor(codec) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codec | [RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Repositories.Queries.IQuery}](#T-RemoteCongress-Common-Serialization-ICodec{RemoteCongress-Common-Repositories-Queries-IQuery} 'RemoteCongress.Common.Serialization.ICodec{RemoteCongress.Common.Repositories.Queries.IQuery}') | A codec used to serialize and deserialize. |

<a name='M-RemoteCongress-Server-Api-ModelBinders-QueryModelBinder-BindModelAsync-Microsoft-AspNetCore-Mvc-ModelBinding-ModelBindingContext-'></a>
### BindModelAsync(bindingContext) `method`

##### Summary

Processes the request in `bindingContext` for any included queries.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bindingContext | [Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext](#T-Microsoft-AspNetCore-Mvc-ModelBinding-ModelBindingContext 'Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext') | The [ModelBindingContext](#T-Microsoft-AspNetCore-Mvc-ModelBinding-ModelBindingContext 'Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext') to process |

<a name='T-RemoteCongress-Server-Api-Startup'></a>
## Startup `type`

##### Namespace

RemoteCongress.Server.Api

##### Summary

Startup logic to execute when spinning up the api.

<a name='M-RemoteCongress-Server-Api-Startup-#ctor-Microsoft-Extensions-Configuration-IConfiguration-'></a>
### #ctor(configuration) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configuration | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') | An [IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance to use when configuring the server. |

<a name='M-RemoteCongress-Server-Api-Startup-Configure-Microsoft-AspNetCore-Builder-IApplicationBuilder,Microsoft-AspNetCore-Hosting-IWebHostEnvironment-'></a>
### Configure(app,env) `method`

##### Summary

Configures teh application

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| app | [Microsoft.AspNetCore.Builder.IApplicationBuilder](#T-Microsoft-AspNetCore-Builder-IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') | The [IApplicationBuilder](#T-Microsoft-AspNetCore-Builder-IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') to configure |
| env | [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](#T-Microsoft-AspNetCore-Hosting-IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment') | The [IWebHostEnvironment](#T-Microsoft-AspNetCore-Hosting-IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment') to configure against. |

<a name='M-RemoteCongress-Server-Api-Startup-ConfigureServices-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### ConfigureServices(services) `method`

##### Summary

Configures and sets up DI for the server.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | An [IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') to use to register services against. |

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

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter'></a>
## UnacceptableMediaTypeExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [UnacceptableMediaTypeException](#T-RemoteCongress-Server-Api-Exceptions-UnacceptableMediaTypeException 'RemoteCongress.Server.Api.Exceptions.UnacceptableMediaTypeException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnacceptableMediaTypeExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-UnacceptableMediaTypeExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter'></a>
## UnknownBlockMediaTypeExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnknownBlockMediaTypeExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-UnknownBlockMediaTypeExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

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

<a name='T-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter'></a>
## UnparsableMediaTypeExceptionFilter `type`

##### Namespace

RemoteCongress.Server.Api.ExceptionFilters

##### Summary

An excpetion handler for [UnparsableMediaTypeException](#T-RemoteCongress-Server-Api-Exceptions-UnparsableMediaTypeException 'RemoteCongress.Server.Api.Exceptions.UnparsableMediaTypeException')

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Server.Api.ExceptionFilters.UnparsableMediaTypeExceptionFilter}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance for logging |

<a name='P-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter-StatusCode'></a>
### StatusCode `property`

##### Summary

The http status code to be returned from this handler

<a name='M-RemoteCongress-Server-Api-ExceptionFilters-UnparsableMediaTypeExceptionFilter-CanHandle-System-Exception-'></a>
### CanHandle(exception) `method`

##### Summary

Checks if the exception can be handled by this handler

##### Returns

true, if the exception can be handled

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that needs handling |

<a name='T-RemoteCongress-Server-Api-Formatters-VerifiedDataCollectionOutputFormatter`1'></a>
## VerifiedDataCollectionOutputFormatter\`1 `type`

##### Namespace

RemoteCongress.Server.Api.Formatters

##### Summary

Validates a signed [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1') and writes it to the http response [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream').

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

Writes the signed and validated [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1') to the http response [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream').

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

Reads and validates a signed [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1') from the input.

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

Reads a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') from a http request [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream').

##### Returns

A [Task](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task 'System.Threading.Tasks.Task') with the signed and validated [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1').

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

Validates a signed [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1') and writes it to the http response [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream').

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

Writes the signed and validated [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1') to the http response [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext](#T-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext 'Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext') | The [OutputFormatterWriteContext](#T-Microsoft-AspNetCore-Mvc-Formatters-OutputFormatterWriteContext 'Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext'). |
| selectedEncoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | The selected [Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding'). |
