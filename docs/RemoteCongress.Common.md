<a name='assembly'></a>
# RemoteCongress.Common

## Contents

- [BaseAvroCodec\`1](#T-RemoteCongress-Common-Serialization-BaseAvroCodec`1 'RemoteCongress.Common.Serialization.BaseAvroCodec`1')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-#ctor-Microsoft-Extensions-Logging-ILogger- 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.#ctor(Microsoft.Extensions.Logging.ILogger)')
  - [_logger](#F-RemoteCongress-Common-Serialization-BaseAvroCodec`1-_logger 'RemoteCongress.Common.Serialization.BaseAvroCodec`1._logger')
  - [CanHandle(mediaType)](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-CanHandle-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.CanHandle(RemoteCongress.Common.RemoteCongressMediaType)')
  - [Decode(mediaType,data)](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream- 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.Decode(RemoteCongress.Common.RemoteCongressMediaType,System.IO.Stream)')
  - [DecodeAvro(mediaType,decoder)](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder- 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.DecodeAvro(RemoteCongress.Common.RemoteCongressMediaType,Avro.IO.Decoder)')
  - [Encode(mediaType,data)](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-Encode-RemoteCongress-Common-RemoteCongressMediaType,`0- 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.Encode(RemoteCongress.Common.RemoteCongressMediaType,`0)')
  - [EncodeAvro(encoder,mediaType,data)](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,`0- 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.EncodeAvro(Avro.IO.Encoder,RemoteCongress.Common.RemoteCongressMediaType,`0)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-GetPreferredMediaType 'RemoteCongress.Common.Serialization.BaseAvroCodec`1.GetPreferredMediaType')
- [BaseJsonCodec\`1](#T-RemoteCongress-Common-Serialization-BaseJsonCodec`1 'RemoteCongress.Common.Serialization.BaseJsonCodec`1')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-#ctor-Microsoft-Extensions-Logging-ILogger- 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.#ctor(Microsoft.Extensions.Logging.ILogger)')
  - [_logger](#F-RemoteCongress-Common-Serialization-BaseJsonCodec`1-_logger 'RemoteCongress.Common.Serialization.BaseJsonCodec`1._logger')
  - [CanHandle(mediaType)](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-CanHandle-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.CanHandle(RemoteCongress.Common.RemoteCongressMediaType)')
  - [Decode(mediaType,data)](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream- 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.Decode(RemoteCongress.Common.RemoteCongressMediaType,System.IO.Stream)')
  - [DecodeJson(mediaType,jToken)](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [Encode(mediaType,data)](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-Encode-RemoteCongress-Common-RemoteCongressMediaType,`0- 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.Encode(RemoteCongress.Common.RemoteCongressMediaType,`0)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,`0- 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,`0)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-GetPreferredMediaType 'RemoteCongress.Common.Serialization.BaseJsonCodec`1.GetPreferredMediaType')
- [BaseRemoteCongressException](#T-RemoteCongress-Common-Exceptions-BaseRemoteCongressException 'RemoteCongress.Common.Exceptions.BaseRemoteCongressException')
- [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill')
  - [Content](#P-RemoteCongress-Common-Bill-Content 'RemoteCongress.Common.Bill.Content')
  - [Title](#P-RemoteCongress-Common-Bill-Title 'RemoteCongress.Common.Bill.Title')
- [BillIdQuery](#T-RemoteCongress-Common-Repositories-Queries-BillIdQuery 'RemoteCongress.Common.Repositories.Queries.BillIdQuery')
  - [#ctor(billId)](#M-RemoteCongress-Common-Repositories-Queries-BillIdQuery-#ctor-System-String- 'RemoteCongress.Common.Repositories.Queries.BillIdQuery.#ctor(System.String)')
  - [BillId](#P-RemoteCongress-Common-Repositories-Queries-BillIdQuery-BillId 'RemoteCongress.Common.Repositories.Queries.BillIdQuery.BillId')
- [BillQueryProcessor](#T-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor 'RemoteCongress.Common.Repositories.Queries.BillQueryProcessor')
  - [#ctor(logger)](#M-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-BillQueryProcessor}- 'RemoteCongress.Common.Repositories.Queries.BillQueryProcessor.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.BillQueryProcessor})')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,RemoteCongress-Common-Bill- 'RemoteCongress.Common.Repositories.Queries.BillQueryProcessor.BlockMatchesQuery(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},RemoteCongress.Common.SignedData,RemoteCongress.Common.Bill)')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor-BlockMatchesQuery-RemoteCongress-Common-Repositories-Queries-IQuery,RemoteCongress-Common-SignedData,RemoteCongress-Common-Bill- 'RemoteCongress.Common.Repositories.Queries.BillQueryProcessor.BlockMatchesQuery(RemoteCongress.Common.Repositories.Queries.IQuery,RemoteCongress.Common.SignedData,RemoteCongress.Common.Bill)')
- [BillV1AvroCodec](#T-RemoteCongress-Common-Serialization-BillV1AvroCodec 'RemoteCongress.Common.Serialization.BillV1AvroCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-BillV1AvroCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-BillV1AvroCodec}- 'RemoteCongress.Common.Serialization.BillV1AvroCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.BillV1AvroCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-BillV1AvroCodec-MediaType 'RemoteCongress.Common.Serialization.BillV1AvroCodec.MediaType')
  - [DecodeAvro(mediaType,decoder)](#M-RemoteCongress-Common-Serialization-BillV1AvroCodec-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder- 'RemoteCongress.Common.Serialization.BillV1AvroCodec.DecodeAvro(RemoteCongress.Common.RemoteCongressMediaType,Avro.IO.Decoder)')
  - [EncodeAvro(encoder,mediaType,data)](#M-RemoteCongress-Common-Serialization-BillV1AvroCodec-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Bill- 'RemoteCongress.Common.Serialization.BillV1AvroCodec.EncodeAvro(Avro.IO.Encoder,RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.Bill)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-BillV1AvroCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.BillV1AvroCodec.GetPreferredMediaType')
- [BillV1JsonCodec](#T-RemoteCongress-Common-Serialization-BillV1JsonCodec 'RemoteCongress.Common.Serialization.BillV1JsonCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-BillV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-BillV1JsonCodec}- 'RemoteCongress.Common.Serialization.BillV1JsonCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.BillV1JsonCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-BillV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.BillV1JsonCodec.MediaType')
  - [DecodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-BillV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.BillV1JsonCodec.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-BillV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Bill- 'RemoteCongress.Common.Serialization.BillV1JsonCodec.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.Bill)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-BillV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.BillV1JsonCodec.GetPreferredMediaType')
- [BlockNotFoundException](#T-RemoteCongress-Common-Exceptions-BlockNotFoundException 'RemoteCongress.Common.Exceptions.BlockNotFoundException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Common-Exceptions-BlockNotFoundException-#ctor-System-String,System-Exception- 'RemoteCongress.Common.Exceptions.BlockNotFoundException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Common-Exceptions-BlockNotFoundException-#ctor-System-String- 'RemoteCongress.Common.Exceptions.BlockNotFoundException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Common-Exceptions-BlockNotFoundException-#ctor 'RemoteCongress.Common.Exceptions.BlockNotFoundException.#ctor')
- [BlockNotStorableException](#T-RemoteCongress-Common-Exceptions-BlockNotStorableException 'RemoteCongress.Common.Exceptions.BlockNotStorableException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Common-Exceptions-BlockNotStorableException-#ctor-System-String,System-Exception- 'RemoteCongress.Common.Exceptions.BlockNotStorableException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Common-Exceptions-BlockNotStorableException-#ctor-System-String- 'RemoteCongress.Common.Exceptions.BlockNotStorableException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Common-Exceptions-BlockNotStorableException-#ctor 'RemoteCongress.Common.Exceptions.BlockNotStorableException.#ctor')
- [BlockStorageException](#T-RemoteCongress-Common-Exceptions-BlockStorageException 'RemoteCongress.Common.Exceptions.BlockStorageException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Common-Exceptions-BlockStorageException-#ctor-System-String,System-Exception- 'RemoteCongress.Common.Exceptions.BlockStorageException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Common-Exceptions-BlockStorageException-#ctor-System-String- 'RemoteCongress.Common.Exceptions.BlockStorageException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Common-Exceptions-BlockStorageException-#ctor 'RemoteCongress.Common.Exceptions.BlockStorageException.#ctor')
- [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1')
  - [CanHandle(mediaType)](#M-RemoteCongress-Common-Serialization-ICodec`1-CanHandle-RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Common.Serialization.ICodec`1.CanHandle(RemoteCongress.Common.RemoteCongressMediaType)')
  - [Decode(mediaType,data)](#M-RemoteCongress-Common-Serialization-ICodec`1-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream- 'RemoteCongress.Common.Serialization.ICodec`1.Decode(RemoteCongress.Common.RemoteCongressMediaType,System.IO.Stream)')
  - [DecodeFromString(mediaType,data)](#M-RemoteCongress-Common-Serialization-ICodec`1-DecodeFromString-RemoteCongress-Common-RemoteCongressMediaType,System-String- 'RemoteCongress.Common.Serialization.ICodec`1.DecodeFromString(RemoteCongress.Common.RemoteCongressMediaType,System.String)')
  - [Encode(mediaType,data)](#M-RemoteCongress-Common-Serialization-ICodec`1-Encode-RemoteCongress-Common-RemoteCongressMediaType,`0- 'RemoteCongress.Common.Serialization.ICodec`1.Encode(RemoteCongress.Common.RemoteCongressMediaType,`0)')
  - [EncodeToString(mediaType,data)](#M-RemoteCongress-Common-Serialization-ICodec`1-EncodeToString-RemoteCongress-Common-RemoteCongressMediaType,`0- 'RemoteCongress.Common.Serialization.ICodec`1.EncodeToString(RemoteCongress.Common.RemoteCongressMediaType,`0)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-ICodec`1-GetPreferredMediaType 'RemoteCongress.Common.Serialization.ICodec`1.GetPreferredMediaType')
- [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient')
  - [AppendToChain(data,cancellationToken)](#M-RemoteCongress-Common-Repositories-IDataClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.IDataClient.AppendToChain(RemoteCongress.Common.ISignedData,System.Threading.CancellationToken)')
  - [FetchAllFromChain(query,cancellationToken)](#M-RemoteCongress-Common-Repositories-IDataClient-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.IDataClient.FetchAllFromChain(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
  - [FetchFromChain(id,cancellationToken)](#M-RemoteCongress-Common-Repositories-IDataClient-FetchFromChain-System-String,System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.IDataClient.FetchFromChain(System.String,System.Threading.CancellationToken)')
- [IIdentifiable](#T-RemoteCongress-Common-IIdentifiable 'RemoteCongress.Common.IIdentifiable')
  - [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id')
- [IImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1')
  - [Create(instance,cancellationToken)](#M-RemoteCongress-Common-Repositories-IImmutableDataRepository`1-Create-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1.Create(RemoteCongress.Common.VerifiedData{`0},System.Threading.CancellationToken)')
  - [Fetch(id,cancellationToken)](#M-RemoteCongress-Common-Repositories-IImmutableDataRepository`1-Fetch-System-String,System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1.Fetch(System.String,System.Threading.CancellationToken)')
  - [Fetch(query,cancellationToken)](#M-RemoteCongress-Common-Repositories-IImmutableDataRepository`1-Fetch-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.IImmutableDataRepository`1.Fetch(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [ILoggerExtensions](#T-RemoteCongress-Common-Logging-ILoggerExtensions 'RemoteCongress.Common.Logging.ILoggerExtensions')
  - [LogException\`\`1(logger,logLevel,exception)](#M-RemoteCongress-Common-Logging-ILoggerExtensions-LogException``1-Microsoft-Extensions-Logging-ILogger,``0,Microsoft-Extensions-Logging-LogLevel- 'RemoteCongress.Common.Logging.ILoggerExtensions.LogException``1(Microsoft.Extensions.Logging.ILogger,``0,Microsoft.Extensions.Logging.LogLevel)')
- [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')
- [IQueryProcessor\`1](#T-RemoteCongress-Common-Repositories-Queries-IQueryProcessor`1 'RemoteCongress.Common.Repositories.Queries.IQueryProcessor`1')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-IQueryProcessor`1-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,`0- 'RemoteCongress.Common.Repositories.Queries.IQueryProcessor`1.BlockMatchesQuery(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},RemoteCongress.Common.SignedData,`0)')
- [IQueryV1JsonCodec](#T-RemoteCongress-Common-Serialization-IQueryV1JsonCodec 'RemoteCongress.Common.Serialization.IQueryV1JsonCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-IQueryV1JsonCodec}- 'RemoteCongress.Common.Serialization.IQueryV1JsonCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.IQueryV1JsonCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.IQueryV1JsonCodec.MediaType')
  - [DecodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.IQueryV1JsonCodec.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Repositories-Queries-IQuery- 'RemoteCongress.Common.Serialization.IQueryV1JsonCodec.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.Repositories.Queries.IQuery)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.IQueryV1JsonCodec.GetPreferredMediaType')
- [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData')
  - [BlockContent](#P-RemoteCongress-Common-ISignedData-BlockContent 'RemoteCongress.Common.ISignedData.BlockContent')
  - [IsValid](#P-RemoteCongress-Common-ISignedData-IsValid 'RemoteCongress.Common.ISignedData.IsValid')
  - [MediaType](#P-RemoteCongress-Common-ISignedData-MediaType 'RemoteCongress.Common.ISignedData.MediaType')
  - [PublicKey](#P-RemoteCongress-Common-ISignedData-PublicKey 'RemoteCongress.Common.ISignedData.PublicKey')
  - [Signature](#P-RemoteCongress-Common-ISignedData-Signature 'RemoteCongress.Common.ISignedData.Signature')
- [ImmutableDataRepository\`1](#T-RemoteCongress-Common-Repositories-ImmutableDataRepository`1 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1')
  - [#ctor(logger,client,codecs,queryProcessor)](#M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}},RemoteCongress-Common-Repositories-IDataClient,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{`0}},RemoteCongress-Common-Repositories-Queries-IQueryProcessor{`0}- 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.IImmutableDataRepository{`0}},RemoteCongress.Common.Repositories.IDataClient,System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{`0}},RemoteCongress.Common.Repositories.Queries.IQueryProcessor{`0})')
  - [_client](#F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_client 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1._client')
  - [_codecs](#F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_codecs 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1._codecs')
  - [_logger](#F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_logger 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1._logger')
  - [_queryProcessor](#F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_queryProcessor 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1._queryProcessor')
  - [Create(model,cancellationToken)](#M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-Create-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1.Create(RemoteCongress.Common.VerifiedData{`0},System.Threading.CancellationToken)')
  - [Fetch(id,cancellationToken)](#M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-Fetch-System-String,System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1.Fetch(System.String,System.Threading.CancellationToken)')
  - [Fetch(query,cancellationToken)](#M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-Fetch-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken- 'RemoteCongress.Common.Repositories.ImmutableDataRepository`1.Fetch(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},System.Threading.CancellationToken)')
- [InvalidBlockSignatureException](#T-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException-#ctor-System-String,System-Exception- 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException-#ctor-System-String- 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException-#ctor 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException.#ctor')
- [JObjectBuilder](#T-RemoteCongress-Common-Serialization-JObjectBuilder 'RemoteCongress.Common.Serialization.JObjectBuilder')
  - [Build()](#M-RemoteCongress-Common-Serialization-JObjectBuilder-Build 'RemoteCongress.Common.Serialization.JObjectBuilder.Build')
  - [WithArray(key,jArray)](#M-RemoteCongress-Common-Serialization-JObjectBuilder-WithArray-System-String,Newtonsoft-Json-Linq-JArray- 'RemoteCongress.Common.Serialization.JObjectBuilder.WithArray(System.String,Newtonsoft.Json.Linq.JArray)')
  - [WithArray\`\`1(key,data,logic)](#M-RemoteCongress-Common-Serialization-JObjectBuilder-WithArray``1-System-String,System-Collections-Generic-IEnumerable{``0},System-Func{``0,Newtonsoft-Json-Linq-JToken}- 'RemoteCongress.Common.Serialization.JObjectBuilder.WithArray``1(System.String,System.Collections.Generic.IEnumerable{``0},System.Func{``0,Newtonsoft.Json.Linq.JToken})')
  - [WithData(key,jToken)](#M-RemoteCongress-Common-Serialization-JObjectBuilder-WithData-System-String,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.JObjectBuilder.WithData(System.String,Newtonsoft.Json.Linq.JToken)')
  - [WithObject(key,jObject)](#M-RemoteCongress-Common-Serialization-JObjectBuilder-WithObject-System-String,Newtonsoft-Json-Linq-JObject- 'RemoteCongress.Common.Serialization.JObjectBuilder.WithObject(System.String,Newtonsoft.Json.Linq.JObject)')
- [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member')
  - [FirstName](#P-RemoteCongress-Common-Member-FirstName 'RemoteCongress.Common.Member.FirstName')
  - [Id](#P-RemoteCongress-Common-Member-Id 'RemoteCongress.Common.Member.Id')
  - [LastName](#P-RemoteCongress-Common-Member-LastName 'RemoteCongress.Common.Member.LastName')
  - [Party](#P-RemoteCongress-Common-Member-Party 'RemoteCongress.Common.Member.Party')
  - [PublicKey](#P-RemoteCongress-Common-Member-PublicKey 'RemoteCongress.Common.Member.PublicKey')
  - [Seat](#P-RemoteCongress-Common-Member-Seat 'RemoteCongress.Common.Member.Seat')
- [MemberQueryProcessor](#T-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor 'RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor')
  - [#ctor(logger)](#M-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor}- 'RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor})')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,RemoteCongress-Common-Member- 'RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor.BlockMatchesQuery(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},RemoteCongress.Common.SignedData,RemoteCongress.Common.Member)')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor-BlockMatchesQuery-RemoteCongress-Common-Repositories-Queries-IQuery,RemoteCongress-Common-SignedData,RemoteCongress-Common-Member- 'RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor.BlockMatchesQuery(RemoteCongress.Common.Repositories.Queries.IQuery,RemoteCongress.Common.SignedData,RemoteCongress.Common.Member)')
- [MemberV1JsonCodec](#T-RemoteCongress-Common-Serialization-MemberV1JsonCodec 'RemoteCongress.Common.Serialization.MemberV1JsonCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-MemberV1JsonCodec}- 'RemoteCongress.Common.Serialization.MemberV1JsonCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.MemberV1JsonCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-MemberV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.MemberV1JsonCodec.MediaType')
  - [DecodeJson(mediaType,jToken)](#M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.MemberV1JsonCodec.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Member- 'RemoteCongress.Common.Serialization.MemberV1JsonCodec.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.Member)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.MemberV1JsonCodec.GetPreferredMediaType')
- [NullQuery](#T-RemoteCongress-Common-Repositories-Queries-NullQuery 'RemoteCongress.Common.Repositories.Queries.NullQuery')
- [OpinionQuery](#T-RemoteCongress-Common-Repositories-Queries-OpinionQuery 'RemoteCongress.Common.Repositories.Queries.OpinionQuery')
  - [#ctor(opinion)](#M-RemoteCongress-Common-Repositories-Queries-OpinionQuery-#ctor-System-Boolean- 'RemoteCongress.Common.Repositories.Queries.OpinionQuery.#ctor(System.Boolean)')
  - [Opinion](#P-RemoteCongress-Common-Repositories-Queries-OpinionQuery-Opinion 'RemoteCongress.Common.Repositories.Queries.OpinionQuery.Opinion')
- [PublicKeyQuery](#T-RemoteCongress-Common-Repositories-Queries-PublicKeyQuery 'RemoteCongress.Common.Repositories.Queries.PublicKeyQuery')
  - [#ctor(publicKey)](#M-RemoteCongress-Common-Repositories-Queries-PublicKeyQuery-#ctor-System-String- 'RemoteCongress.Common.Repositories.Queries.PublicKeyQuery.#ctor(System.String)')
  - [PublicKey](#P-RemoteCongress-Common-Repositories-Queries-PublicKeyQuery-PublicKey 'RemoteCongress.Common.Repositories.Queries.PublicKeyQuery.PublicKey')
- [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType')
  - [#ctor(type,subType,structure,version)](#M-RemoteCongress-Common-RemoteCongressMediaType-#ctor-System-String,System-String,System-String,System-Int32- 'RemoteCongress.Common.RemoteCongressMediaType.#ctor(System.String,System.String,System.String,System.Int32)')
  - [MinVersionValue](#F-RemoteCongress-Common-RemoteCongressMediaType-MinVersionValue 'RemoteCongress.Common.RemoteCongressMediaType.MinVersionValue')
  - [StructureKey](#F-RemoteCongress-Common-RemoteCongressMediaType-StructureKey 'RemoteCongress.Common.RemoteCongressMediaType.StructureKey')
  - [VersionKey](#F-RemoteCongress-Common-RemoteCongressMediaType-VersionKey 'RemoteCongress.Common.RemoteCongressMediaType.VersionKey')
  - [None](#P-RemoteCongress-Common-RemoteCongressMediaType-None 'RemoteCongress.Common.RemoteCongressMediaType.None')
  - [Structure](#P-RemoteCongress-Common-RemoteCongressMediaType-Structure 'RemoteCongress.Common.RemoteCongressMediaType.Structure')
  - [SubType](#P-RemoteCongress-Common-RemoteCongressMediaType-SubType 'RemoteCongress.Common.RemoteCongressMediaType.SubType')
  - [Type](#P-RemoteCongress-Common-RemoteCongressMediaType-Type 'RemoteCongress.Common.RemoteCongressMediaType.Type')
  - [Version](#P-RemoteCongress-Common-RemoteCongressMediaType-Version 'RemoteCongress.Common.RemoteCongressMediaType.Version')
  - [Equals(obj)](#M-RemoteCongress-Common-RemoteCongressMediaType-Equals-System-Object- 'RemoteCongress.Common.RemoteCongressMediaType.Equals(System.Object)')
  - [GetHashCode()](#M-RemoteCongress-Common-RemoteCongressMediaType-GetHashCode 'RemoteCongress.Common.RemoteCongressMediaType.GetHashCode')
  - [Parse(mediaType)](#M-RemoteCongress-Common-RemoteCongressMediaType-Parse-System-String- 'RemoteCongress.Common.RemoteCongressMediaType.Parse(System.String)')
  - [ToString()](#M-RemoteCongress-Common-RemoteCongressMediaType-ToString 'RemoteCongress.Common.RemoteCongressMediaType.ToString')
- [RsaUtils](#T-RemoteCongress-Common-Encryption-RsaUtils 'RemoteCongress.Common.Encryption.RsaUtils')
  - [GenerateSignature(privateKey,message)](#M-RemoteCongress-Common-Encryption-RsaUtils-GenerateSignature-System-String,System-String- 'RemoteCongress.Common.Encryption.RsaUtils.GenerateSignature(System.String,System.String)')
  - [GetAlgorithmName()](#M-RemoteCongress-Common-Encryption-RsaUtils-GetAlgorithmName 'RemoteCongress.Common.Encryption.RsaUtils.GetAlgorithmName')
  - [GetEncoding()](#M-RemoteCongress-Common-Encryption-RsaUtils-GetEncoding 'RemoteCongress.Common.Encryption.RsaUtils.GetEncoding')
  - [GetPadding()](#M-RemoteCongress-Common-Encryption-RsaUtils-GetPadding 'RemoteCongress.Common.Encryption.RsaUtils.GetPadding')
  - [VerifySignature(publicKey,message,signatureBytes)](#M-RemoteCongress-Common-Encryption-RsaUtils-VerifySignature-System-String,System-String,System-Byte[]- 'RemoteCongress.Common.Encryption.RsaUtils.VerifySignature(System.String,System.String,System.Byte[])')
- [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData')
  - [#ctor(publicKey,blockContent,signature,mediaType)](#M-RemoteCongress-Common-SignedData-#ctor-System-String,System-String,System-Byte[],RemoteCongress-Common-RemoteCongressMediaType- 'RemoteCongress.Common.SignedData.#ctor(System.String,System.String,System.Byte[],RemoteCongress.Common.RemoteCongressMediaType)')
  - [#ctor(data)](#M-RemoteCongress-Common-SignedData-#ctor-RemoteCongress-Common-ISignedData- 'RemoteCongress.Common.SignedData.#ctor(RemoteCongress.Common.ISignedData)')
  - [#ctor()](#M-RemoteCongress-Common-SignedData-#ctor 'RemoteCongress.Common.SignedData.#ctor')
  - [BlockContent](#P-RemoteCongress-Common-SignedData-BlockContent 'RemoteCongress.Common.SignedData.BlockContent')
  - [Id](#P-RemoteCongress-Common-SignedData-Id 'RemoteCongress.Common.SignedData.Id')
  - [MediaType](#P-RemoteCongress-Common-SignedData-MediaType 'RemoteCongress.Common.SignedData.MediaType')
  - [PublicKey](#P-RemoteCongress-Common-SignedData-PublicKey 'RemoteCongress.Common.SignedData.PublicKey')
  - [Signature](#P-RemoteCongress-Common-SignedData-Signature 'RemoteCongress.Common.SignedData.Signature')
- [SignedDataCollectionV1JsonCodec](#T-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec}- 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec.MediaType')
  - [DecodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}- 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData})')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec.GetPreferredMediaType')
- [SignedDataV1AvroCodec](#T-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec 'RemoteCongress.Common.Serialization.SignedDataV1AvroCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataV1AvroCodec}- 'RemoteCongress.Common.Serialization.SignedDataV1AvroCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataV1AvroCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataV1AvroCodec.MediaType')
  - [DecodeAvro(mediaType,decoder)](#M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder- 'RemoteCongress.Common.Serialization.SignedDataV1AvroCodec.DecodeAvro(RemoteCongress.Common.RemoteCongressMediaType,Avro.IO.Decoder)')
  - [EncodeAvro(encoder,mediaType,data)](#M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-SignedData- 'RemoteCongress.Common.Serialization.SignedDataV1AvroCodec.EncodeAvro(Avro.IO.Encoder,RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.SignedData)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.SignedDataV1AvroCodec.GetPreferredMediaType')
- [SignedDataV1JsonCodec](#T-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataV1JsonCodec}- 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataV1JsonCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.MediaType')
  - [DecodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-SignedData- 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.SignedData)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.SignedDataV1JsonCodec.GetPreferredMediaType')
- [UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException')
  - [#ctor(message,innerException)](#M-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException-#ctor-System-String,System-Exception- 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException.#ctor(System.String,System.Exception)')
  - [#ctor(message)](#M-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException-#ctor-System-String- 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException.#ctor(System.String)')
  - [#ctor()](#M-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException-#ctor 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException.#ctor')
- [VerifiedData\`1](#T-RemoteCongress-Common-VerifiedData`1 'RemoteCongress.Common.VerifiedData`1')
  - [#ctor(id,data,model)](#M-RemoteCongress-Common-VerifiedData`1-#ctor-System-String,RemoteCongress-Common-ISignedData,`0- 'RemoteCongress.Common.VerifiedData`1.#ctor(System.String,RemoteCongress.Common.ISignedData,`0)')
  - [#ctor(data,model)](#M-RemoteCongress-Common-VerifiedData`1-#ctor-RemoteCongress-Common-ISignedData,`0- 'RemoteCongress.Common.VerifiedData`1.#ctor(RemoteCongress.Common.ISignedData,`0)')
  - [BlockContent](#P-RemoteCongress-Common-VerifiedData`1-BlockContent 'RemoteCongress.Common.VerifiedData`1.BlockContent')
  - [Data](#P-RemoteCongress-Common-VerifiedData`1-Data 'RemoteCongress.Common.VerifiedData`1.Data')
  - [Id](#P-RemoteCongress-Common-VerifiedData`1-Id 'RemoteCongress.Common.VerifiedData`1.Id')
  - [MediaType](#P-RemoteCongress-Common-VerifiedData`1-MediaType 'RemoteCongress.Common.VerifiedData`1.MediaType')
  - [PublicKey](#P-RemoteCongress-Common-VerifiedData`1-PublicKey 'RemoteCongress.Common.VerifiedData`1.PublicKey')
  - [Signature](#P-RemoteCongress-Common-VerifiedData`1-Signature 'RemoteCongress.Common.VerifiedData`1.Signature')
- [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')
  - [BillId](#P-RemoteCongress-Common-Vote-BillId 'RemoteCongress.Common.Vote.BillId')
  - [Message](#P-RemoteCongress-Common-Vote-Message 'RemoteCongress.Common.Vote.Message')
  - [Opinion](#P-RemoteCongress-Common-Vote-Opinion 'RemoteCongress.Common.Vote.Opinion')
- [VoteQueryProcessor](#T-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor 'RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor')
  - [#ctor(logger)](#M-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor}- 'RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor})')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,RemoteCongress-Common-Vote- 'RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor.BlockMatchesQuery(System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery},RemoteCongress.Common.SignedData,RemoteCongress.Common.Vote)')
  - [BlockMatchesQuery(query,signedData,data)](#M-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor-BlockMatchesQuery-RemoteCongress-Common-Repositories-Queries-IQuery,RemoteCongress-Common-SignedData,RemoteCongress-Common-Vote- 'RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor.BlockMatchesQuery(RemoteCongress.Common.Repositories.Queries.IQuery,RemoteCongress.Common.SignedData,RemoteCongress.Common.Vote)')
- [VoteV1AvroCodec](#T-RemoteCongress-Common-Serialization-VoteV1AvroCodec 'RemoteCongress.Common.Serialization.VoteV1AvroCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-VoteV1AvroCodec}- 'RemoteCongress.Common.Serialization.VoteV1AvroCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.VoteV1AvroCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-VoteV1AvroCodec-MediaType 'RemoteCongress.Common.Serialization.VoteV1AvroCodec.MediaType')
  - [DecodeAvro(mediaType,decoder)](#M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder- 'RemoteCongress.Common.Serialization.VoteV1AvroCodec.DecodeAvro(RemoteCongress.Common.RemoteCongressMediaType,Avro.IO.Decoder)')
  - [EncodeAvro(encoder,mediaType,data)](#M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Vote- 'RemoteCongress.Common.Serialization.VoteV1AvroCodec.EncodeAvro(Avro.IO.Encoder,RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.Vote)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.VoteV1AvroCodec.GetPreferredMediaType')
- [VoteV1JsonCodec](#T-RemoteCongress-Common-Serialization-VoteV1JsonCodec 'RemoteCongress.Common.Serialization.VoteV1JsonCodec')
  - [#ctor(logger)](#M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-VoteV1JsonCodec}- 'RemoteCongress.Common.Serialization.VoteV1JsonCodec.#ctor(Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.VoteV1JsonCodec})')
  - [MediaType](#F-RemoteCongress-Common-Serialization-VoteV1JsonCodec-MediaType 'RemoteCongress.Common.Serialization.VoteV1JsonCodec.MediaType')
  - [DecodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken- 'RemoteCongress.Common.Serialization.VoteV1JsonCodec.DecodeJson(RemoteCongress.Common.RemoteCongressMediaType,Newtonsoft.Json.Linq.JToken)')
  - [EncodeJson(mediaType,data)](#M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Vote- 'RemoteCongress.Common.Serialization.VoteV1JsonCodec.EncodeJson(RemoteCongress.Common.RemoteCongressMediaType,RemoteCongress.Common.Vote)')
  - [GetPreferredMediaType()](#M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-GetPreferredMediaType 'RemoteCongress.Common.Serialization.VoteV1JsonCodec.GetPreferredMediaType')

<a name='T-RemoteCongress-Common-Serialization-BaseAvroCodec`1'></a>
## BaseAvroCodec\`1 `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

A base [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for implementing avro codecs.

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-#ctor-Microsoft-Extensions-Logging-ILogger-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-BaseAvroCodec`1-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against.

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-CanHandle-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### CanHandle(mediaType) `method`

##### Summary

Checks if `mediaType` can be handled by the codec.

##### Returns

True if `mediaType` can be handled.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to check if it can be handled. |

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream-'></a>
### Decode(mediaType,data) `method`

##### Summary

Decodes a `data` into a `T`.

##### Returns

The `T` from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [System.IO.Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') | The [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') to decode data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder-'></a>
### DecodeAvro(mediaType,decoder) `method`

##### Summary

Decodes a `decoder` into a `T`.

##### Returns

The `T` from `decoder`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| decoder | [Avro.IO.Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') | The [Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-Encode-RemoteCongress-Common-RemoteCongressMediaType,`0-'></a>
### Encode(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [\`0](#T-`0 '`0') | The data to encode. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,`0-'></a>
### EncodeAvro(encoder,mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encoder | [Avro.IO.Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') | The [Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') to encode data to. |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [\`0](#T-`0 '`0') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-BaseAvroCodec`1-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Serialization-BaseJsonCodec`1'></a>
## BaseJsonCodec\`1 `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

A base [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for implementing json codecs.

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-#ctor-Microsoft-Extensions-Logging-ILogger-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-BaseJsonCodec`1-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against.

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-CanHandle-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### CanHandle(mediaType) `method`

##### Summary

Checks if `mediaType` can be handled by the codec.

##### Returns

True if `mediaType` can be handled.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to check if it can be handled. |

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream-'></a>
### Decode(mediaType,data) `method`

##### Summary

Decodes a `data` into a `T`.

##### Returns

The `T` from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [System.IO.Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') | The [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') to decode data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,jToken) `method`

##### Summary

Decodes a `jToken` into a `T`.

##### Returns

The `T` from `jToken`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| jToken | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-Encode-RemoteCongress-Common-RemoteCongressMediaType,`0-'></a>
### Encode(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [\`0](#T-`0 '`0') | The data to encode. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,`0-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [\`0](#T-`0 '`0') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-BaseJsonCodec`1-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Exceptions-BaseRemoteCongressException'></a>
## BaseRemoteCongressException `type`

##### Namespace

RemoteCongress.Common.Exceptions

##### Summary



<a name='T-RemoteCongress-Common-Bill'></a>
## Bill `type`

##### Namespace

RemoteCongress.Common

##### Summary

A model representing a bill

<a name='P-RemoteCongress-Common-Bill-Content'></a>
### Content `property`

##### Summary

The content of the bill.

<a name='P-RemoteCongress-Common-Bill-Title'></a>
### Title `property`

##### Summary

The title of the bill.

<a name='T-RemoteCongress-Common-Repositories-Queries-BillIdQuery'></a>
## BillIdQuery `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

An [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') to filter on BillId.

<a name='M-RemoteCongress-Common-Repositories-Queries-BillIdQuery-#ctor-System-String-'></a>
### #ctor(billId) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| billId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The Id of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to filter on. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `billId` is null. |

<a name='P-RemoteCongress-Common-Repositories-Queries-BillIdQuery-BillId'></a>
### BillId `property`

##### Summary

The Id of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to filter on.

<a name='T-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor'></a>
## BillQueryProcessor `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

Query processing logic for [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='M-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-BillQueryProcessor}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.BillQueryProcessor}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-BillQueryProcessor} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.BillQueryProcessor}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to use for logging. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='M-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,RemoteCongress-Common-Bill-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches everything defined `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') | The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to test against `query` against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `query` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `signedData` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |

<a name='M-RemoteCongress-Common-Repositories-Queries-BillQueryProcessor-BlockMatchesQuery-RemoteCongress-Common-Repositories-Queries-IQuery,RemoteCongress-Common-SignedData,RemoteCongress-Common-Bill-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [RemoteCongress.Common.Repositories.Queries.IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') | An [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') | The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') to test against `query` against. |

<a name='T-RemoteCongress-Common-Serialization-BillV1AvroCodec'></a>
## BillV1AvroCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 avro representation of a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

<a name='M-RemoteCongress-Common-Serialization-BillV1AvroCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-BillV1AvroCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.BillV1AvroCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-BillV1AvroCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.BillV1AvroCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-BillV1AvroCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-BillV1AvroCodec-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder-'></a>
### DecodeAvro(mediaType,decoder) `method`

##### Summary

Decodes a `decoder` into a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Returns

The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') from `decoder`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| decoder | [Avro.IO.Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') | The [Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-BillV1AvroCodec-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Bill-'></a>
### EncodeAvro(encoder,mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encoder | [Avro.IO.Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') | The [Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') to encode data to. |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-BillV1AvroCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Serialization-BillV1JsonCodec'></a>
## BillV1JsonCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

<a name='M-RemoteCongress-Common-Serialization-BillV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-BillV1JsonCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.BillV1JsonCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-BillV1JsonCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.BillV1JsonCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-BillV1JsonCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-BillV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,data) `method`

##### Summary

Decodes a `data` into a [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill').

##### Returns

The [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-BillV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Bill-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-BillV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Exceptions-BlockNotFoundException'></a>
## BlockNotFoundException `type`

##### Namespace

RemoteCongress.Common.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a block is unexpected not found.

<a name='M-RemoteCongress-Common-Exceptions-BlockNotFoundException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Common-Exceptions-BlockNotFoundException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Common-Exceptions-BlockNotFoundException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Common-Exceptions-BlockNotStorableException'></a>
## BlockNotStorableException `type`

##### Namespace

RemoteCongress.Common.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a block is unexpected cannot be persisted.

<a name='M-RemoteCongress-Common-Exceptions-BlockNotStorableException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Common-Exceptions-BlockNotStorableException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Common-Exceptions-BlockNotStorableException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Common-Exceptions-BlockStorageException'></a>
## BlockStorageException `type`

##### Namespace

RemoteCongress.Common.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that all block storage related exceptions should inherit fromm.

<a name='M-RemoteCongress-Common-Exceptions-BlockStorageException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Common-Exceptions-BlockStorageException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Common-Exceptions-BlockStorageException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Common-Serialization-ICodec`1'></a>
## ICodec\`1 `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An interface around encoding and decoding data.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TData | The data type to encode or decode. |

<a name='M-RemoteCongress-Common-Serialization-ICodec`1-CanHandle-RemoteCongress-Common-RemoteCongressMediaType-'></a>
### CanHandle(mediaType) `method`

##### Summary

Checks if `mediaType` can be handled by the codec.

##### Returns

True if `mediaType` can be handled.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to check if it can be handled. |

<a name='M-RemoteCongress-Common-Serialization-ICodec`1-Decode-RemoteCongress-Common-RemoteCongressMediaType,System-IO-Stream-'></a>
### Decode(mediaType,data) `method`

##### Summary

Decodes a `data` into a `TData`.

##### Returns

The `TData` from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [System.IO.Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') | The [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-ICodec`1-DecodeFromString-RemoteCongress-Common-RemoteCongressMediaType,System-String-'></a>
### DecodeFromString(mediaType,data) `method`

##### Summary

Decodes a `data` into a `TData`.

##### Returns

The `TData` from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to decode data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Common-Serialization-ICodec`1-Encode-RemoteCongress-Common-RemoteCongressMediaType,`0-'></a>
### Encode(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [Stream](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.Stream 'System.IO.Stream') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [\`0](#T-`0 '`0') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-ICodec`1-EncodeToString-RemoteCongress-Common-RemoteCongressMediaType,`0-'></a>
### EncodeToString(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [\`0](#T-`0 '`0') | The data to encode. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the `mediaType` cannot be handled. |

<a name='M-RemoteCongress-Common-Serialization-ICodec`1-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Repositories-IDataClient'></a>
## IDataClient `type`

##### Namespace

RemoteCongress.Common.Repositories

##### Summary

An interface for interacting with an immutable data store.

<a name='M-RemoteCongress-Common-Repositories-IDataClient-AppendToChain-RemoteCongress-Common-ISignedData,System-Threading-CancellationToken-'></a>
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

<a name='M-RemoteCongress-Common-Repositories-IDataClient-FetchAllFromChain-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### FetchAllFromChain(query,cancellationToken) `method`

##### Summary

Fetches all matching verified data in the form of [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') from the blockchain.

##### Returns

An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance containing the block data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | The query to pull data by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Common-Repositories-IDataClient-FetchFromChain-System-String,System-Threading-CancellationToken-'></a>
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

<a name='T-RemoteCongress-Common-IIdentifiable'></a>
## IIdentifiable `type`

##### Namespace

RemoteCongress.Common

##### Summary

An interface describing an identifiable structure.

<a name='P-RemoteCongress-Common-IIdentifiable-Id'></a>
### Id `property`

##### Summary

The unique identifier of the implementing structure.

<a name='T-RemoteCongress-Common-Repositories-IImmutableDataRepository`1'></a>
## IImmutableDataRepository\`1 `type`

##### Namespace

RemoteCongress.Common.Repositories

##### Summary

An interface defining what operations can happen for persisted immutable data types.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TData | A type that defines the data being operated on. |

<a name='M-RemoteCongress-Common-Repositories-IImmutableDataRepository`1-Create-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken-'></a>
### Create(instance,cancellationToken) `method`

##### Summary

Creates and persist the signed and verified `instance`.

##### Returns

The persisted `instance` model.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [RemoteCongress.Common.VerifiedData{\`0}](#T-RemoteCongress-Common-VerifiedData{`0} 'RemoteCongress.Common.VerifiedData{`0}') | A signed and verified instance of type `TData` to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Common-Repositories-IImmutableDataRepository`1-Fetch-System-String,System-Threading-CancellationToken-'></a>
### Fetch(id,cancellationToken) `method`

##### Summary

Fetches a persisted instance of `TData` that has an [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') that
    matches `id`.

##### Returns

The immutable, and verified `TData` instance with an [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id')
    of `id`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of an `TData` instance to fetch. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='M-RemoteCongress-Common-Repositories-IImmutableDataRepository`1-Fetch-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### Fetch(query,cancellationToken) `method`

##### Summary

Fetches all matching verified data in the form of [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') from the blockchain.

##### Returns

An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance containing the block data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | The query to pull data by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

<a name='T-RemoteCongress-Common-Logging-ILoggerExtensions'></a>
## ILoggerExtensions `type`

##### Namespace

RemoteCongress.Common.Logging

##### Summary

[ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') extension methods.

<a name='M-RemoteCongress-Common-Logging-ILoggerExtensions-LogException``1-Microsoft-Extensions-Logging-ILogger,``0,Microsoft-Extensions-Logging-LogLevel-'></a>
### LogException\`\`1(logger,logLevel,exception) `method`

##### Summary

Logs an exception to an [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger').

##### Returns

The passed in `exception` reference.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | The [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to log to. |
| logLevel | [\`\`0](#T-``0 '``0') | The [LogLevel](#T-Microsoft-Extensions-Logging-LogLevel 'Microsoft.Extensions.Logging.LogLevel') to log the exception at. |
| exception | [Microsoft.Extensions.Logging.LogLevel](#T-Microsoft-Extensions-Logging-LogLevel 'Microsoft.Extensions.Logging.LogLevel') | an exception of `TException` to be logged. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TException | A type of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to be passed through the method. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `exception` is null. |

<a name='T-RemoteCongress-Common-Repositories-Queries-IQuery'></a>
## IQuery `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

A type to use for filtering.

<a name='T-RemoteCongress-Common-Repositories-Queries-IQueryProcessor`1'></a>
## IQueryProcessor\`1 `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

Query processing logic for .

<a name='M-RemoteCongress-Common-Repositories-Queries-IQueryProcessor`1-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,`0-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches everything defined `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [\`0](#T-`0 '`0') | The `TData` to test against `query` against. |

<a name='T-RemoteCongress-Common-Serialization-IQueryV1JsonCodec'></a>
## IQueryV1JsonCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery').

<a name='M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-IQueryV1JsonCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.IQueryV1JsonCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-IQueryV1JsonCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.IQueryV1JsonCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,data) `method`

##### Summary

Decodes a `data` into a [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery').

##### Returns

The [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Repositories-Queries-IQuery-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.Repositories.Queries.IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-IQueryV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-ISignedData'></a>
## ISignedData `type`

##### Namespace

RemoteCongress.Common

##### Summary

An interface defining structures that contain verifiable data.

<a name='P-RemoteCongress-Common-ISignedData-BlockContent'></a>
### BlockContent `property`

##### Summary

The content of the data.

<a name='P-RemoteCongress-Common-ISignedData-IsValid'></a>
### IsValid `property`

##### Summary

A flag to indicate that the contained signed data is valid, and untampered with.

##### Returns

True if the contained data is valid, and not tampered with.

<a name='P-RemoteCongress-Common-ISignedData-MediaType'></a>
### MediaType `property`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of [BlockContent](#P-RemoteCongress-Common-ISignedData-BlockContent 'RemoteCongress.Common.ISignedData.BlockContent')

<a name='P-RemoteCongress-Common-ISignedData-PublicKey'></a>
### PublicKey `property`

##### Summary

The string representation of the data producer's public key.

<a name='P-RemoteCongress-Common-ISignedData-Signature'></a>
### Signature `property`

##### Summary

The signature of the [BlockContent](#P-RemoteCongress-Common-ISignedData-BlockContent 'RemoteCongress.Common.ISignedData.BlockContent') that can be verified with [PublicKey](#P-RemoteCongress-Common-ISignedData-PublicKey 'RemoteCongress.Common.ISignedData.PublicKey').

<a name='T-RemoteCongress-Common-Repositories-ImmutableDataRepository`1'></a>
## ImmutableDataRepository\`1 `type`

##### Namespace

RemoteCongress.Common.Repositories

##### Summary

An immutable data repository for `TData`.

<a name='M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}},RemoteCongress-Common-Repositories-IDataClient,System-Collections-Generic-IEnumerable{RemoteCongress-Common-Serialization-ICodec{`0}},RemoteCongress-Common-Repositories-Queries-IQueryProcessor{`0}-'></a>
### #ctor(logger,client,codecs,queryProcessor) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.IImmutableDataRepository{\`0}}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-IImmutableDataRepository{`0}} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.IImmutableDataRepository{`0}}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |
| client | [RemoteCongress.Common.Repositories.IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient') | A [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient') instance to use to communicate with the data store. |
| codecs | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Serialization.ICodec{`0}}') | [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1')s for `TData` to process block content. |
| queryProcessor | [RemoteCongress.Common.Repositories.Queries.IQueryProcessor{\`0}](#T-RemoteCongress-Common-Repositories-Queries-IQueryProcessor{`0} 'RemoteCongress.Common.Repositories.Queries.IQueryProcessor{`0}') | [IQueryProcessor\`1](#T-RemoteCongress-Common-Repositories-Queries-IQueryProcessor`1 'RemoteCongress.Common.Repositories.Queries.IQueryProcessor`1') to filter `TData` on for queries. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `client` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `codecs` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `queryProcessor` is null. |

<a name='F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_client'></a>
### _client `constants`

##### Summary

An [IDataClient](#T-RemoteCongress-Common-Repositories-IDataClient 'RemoteCongress.Common.Repositories.IDataClient') to interact with data against.

<a name='F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_codecs'></a>
### _codecs `constants`

##### Summary

A collection of [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1')s to use to decode data.

<a name='F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_logger'></a>
### _logger `constants`

##### Summary

An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against.

<a name='F-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-_queryProcessor'></a>
### _queryProcessor `constants`

##### Summary

A [IQueryProcessor\`1](#T-RemoteCongress-Common-Repositories-Queries-IQueryProcessor`1 'RemoteCongress.Common.Repositories.Queries.IQueryProcessor`1') to process an [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s that need to be processed.

<a name='M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-Create-RemoteCongress-Common-VerifiedData{`0},System-Threading-CancellationToken-'></a>
### Create(model,cancellationToken) `method`

##### Summary

Creates and persist the signed and verified `model`.

##### Returns

The persisted `model` model.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [RemoteCongress.Common.VerifiedData{\`0}](#T-RemoteCongress-Common-VerifiedData{`0} 'RemoteCongress.Common.VerifiedData{`0}') | A signed and verified instance of type `TData` to persist. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [RemoteCongress.Common.Exceptions.BlockNotStorableException](#T-RemoteCongress-Common-Exceptions-BlockNotStorableException 'RemoteCongress.Common.Exceptions.BlockNotStorableException') | Thrown if the `model` cannot be stored. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if the `cancellationToken` is cancelled. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `model` is null. |

<a name='M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-Fetch-System-String,System-Threading-CancellationToken-'></a>
### Fetch(id,cancellationToken) `method`

##### Summary

Fetches a persisted instance of `TData` that has an [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') that
    matches `id`.

##### Returns

The immutable, and verified `TData` instance with an [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id')
    of `id`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of an `TData` instance to fetch. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [RemoteCongress.Common.Exceptions.BlockNotFoundException](#T-RemoteCongress-Common-Exceptions-BlockNotFoundException 'RemoteCongress.Common.Exceptions.BlockNotFoundException') | Thrown if a block with an id of `id` cannot be fetched. |
| [RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException](#T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException 'RemoteCongress.Common.Exceptions.UnknownBlockMediaTypeException') | Thrown if a block has a [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') cannot be decoded. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if the `cancellationToken` is cancelled. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `id` is null. |

<a name='M-RemoteCongress-Common-Repositories-ImmutableDataRepository`1-Fetch-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},System-Threading-CancellationToken-'></a>
### Fetch(query,cancellationToken) `method`

##### Summary

Fetches all matching verified data in the form of [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') from the blockchain.

##### Returns

An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance containing the block data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | The query to pull data by. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A [CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') to handle cancellation requests. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `query` is null. |
| [System.OperationCanceledException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.OperationCanceledException 'System.OperationCanceledException') | Thrown if the `cancellationToken` is cancelled. |

<a name='T-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException'></a>
## InvalidBlockSignatureException `type`

##### Namespace

RemoteCongress.Common.Exceptions

##### Summary



<a name='M-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Common-Serialization-JObjectBuilder'></a>
## JObjectBuilder `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary



<a name='M-RemoteCongress-Common-Serialization-JObjectBuilder-Build'></a>
### Build() `method`

##### Summary



##### Returns



##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Common-Serialization-JObjectBuilder-WithArray-System-String,Newtonsoft-Json-Linq-JArray-'></a>
### WithArray(key,jArray) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| jArray | [Newtonsoft.Json.Linq.JArray](#T-Newtonsoft-Json-Linq-JArray 'Newtonsoft.Json.Linq.JArray') |  |

<a name='M-RemoteCongress-Common-Serialization-JObjectBuilder-WithArray``1-System-String,System-Collections-Generic-IEnumerable{``0},System-Func{``0,Newtonsoft-Json-Linq-JToken}-'></a>
### WithArray\`\`1(key,data,logic) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| data | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |
| logic | [System.Func{\`\`0,Newtonsoft.Json.Linq.JToken}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,Newtonsoft.Json.Linq.JToken}') |  |

<a name='M-RemoteCongress-Common-Serialization-JObjectBuilder-WithData-System-String,Newtonsoft-Json-Linq-JToken-'></a>
### WithData(key,jToken) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| jToken | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') |  |

<a name='M-RemoteCongress-Common-Serialization-JObjectBuilder-WithObject-System-String,Newtonsoft-Json-Linq-JObject-'></a>
### WithObject(key,jObject) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| jObject | [Newtonsoft.Json.Linq.JObject](#T-Newtonsoft-Json-Linq-JObject 'Newtonsoft.Json.Linq.JObject') |  |

<a name='T-RemoteCongress-Common-Member'></a>
## Member `type`

##### Namespace

RemoteCongress.Common

##### Summary

A model representing a voting member

<a name='P-RemoteCongress-Common-Member-FirstName'></a>
### FirstName `property`

##### Summary

The member's first name

<a name='P-RemoteCongress-Common-Member-Id'></a>
### Id `property`

##### Summary

The member's identifier

<a name='P-RemoteCongress-Common-Member-LastName'></a>
### LastName `property`

##### Summary

The member's last name

<a name='P-RemoteCongress-Common-Member-Party'></a>
### Party `property`

##### Summary

The member's party

<a name='P-RemoteCongress-Common-Member-PublicKey'></a>
### PublicKey `property`

##### Summary

The member's public key

<a name='P-RemoteCongress-Common-Member-Seat'></a>
### Seat `property`

##### Summary

The member's seat

<a name='T-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor'></a>
## MemberQueryProcessor `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

Query processing logic for [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='M-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.MemberQueryProcessor}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to use for logging. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='M-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,RemoteCongress-Common-Member-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches everything defined `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [RemoteCongress.Common.Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') | The [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') to test against `query` against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `query` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `signedData` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |

<a name='M-RemoteCongress-Common-Repositories-Queries-MemberQueryProcessor-BlockMatchesQuery-RemoteCongress-Common-Repositories-Queries-IQuery,RemoteCongress-Common-SignedData,RemoteCongress-Common-Member-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [RemoteCongress.Common.Repositories.Queries.IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') | An [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [RemoteCongress.Common.Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') | The [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') to test against `query` against. |

<a name='T-RemoteCongress-Common-Serialization-MemberV1JsonCodec'></a>
## MemberV1JsonCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

<a name='M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-MemberV1JsonCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.MemberV1JsonCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-MemberV1JsonCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.MemberV1JsonCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-MemberV1JsonCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,jToken) `method`

##### Summary

Decodes a `jToken` into a [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member').

##### Returns

The [Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') from `jToken`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| jToken | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Member-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.Member](#T-RemoteCongress-Common-Member 'RemoteCongress.Common.Member') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-MemberV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Repositories-Queries-NullQuery'></a>
## NullQuery `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

A no-op [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery').

<a name='T-RemoteCongress-Common-Repositories-Queries-OpinionQuery'></a>
## OpinionQuery `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

An [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') to filter on Opinion.

<a name='M-RemoteCongress-Common-Repositories-Queries-OpinionQuery-#ctor-System-Boolean-'></a>
### #ctor(opinion) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| opinion | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | The opinion to filter on. |

<a name='P-RemoteCongress-Common-Repositories-Queries-OpinionQuery-Opinion'></a>
### Opinion `property`

##### Summary

The opinion to filter on.

<a name='T-RemoteCongress-Common-Repositories-Queries-PublicKeyQuery'></a>
## PublicKeyQuery `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

An [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') to filter on Public Key.

<a name='M-RemoteCongress-Common-Repositories-Queries-PublicKeyQuery-#ctor-System-String-'></a>
### #ctor(publicKey) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The Public Key to filter on. |

<a name='P-RemoteCongress-Common-Repositories-Queries-PublicKeyQuery-PublicKey'></a>
### PublicKey `property`

##### Summary

The Public Key to filter on.

<a name='T-RemoteCongress-Common-RemoteCongressMediaType'></a>
## RemoteCongressMediaType `type`

##### Namespace

RemoteCongress.Common

##### Summary

A class that defines a mime MediaType

<a name='M-RemoteCongress-Common-RemoteCongressMediaType-#ctor-System-String,System-String,System-String,System-Int32-'></a>
### #ctor(type,subType,structure,version) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The mediatype type |
| subType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The mediatype subtype |
| structure | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The mediatype structure |
| version | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The mediatype version |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `type` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `subType` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `structure` is null. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if `version` is less than [MinVersionValue](#F-RemoteCongress-Common-RemoteCongressMediaType-MinVersionValue 'RemoteCongress.Common.RemoteCongressMediaType.MinVersionValue'). |

<a name='F-RemoteCongress-Common-RemoteCongressMediaType-MinVersionValue'></a>
### MinVersionValue `constants`

##### Summary

The minimum version number a media type can represent

<a name='F-RemoteCongress-Common-RemoteCongressMediaType-StructureKey'></a>
### StructureKey `constants`

##### Summary

The key used for the structure parameterr in the media type.

<a name='F-RemoteCongress-Common-RemoteCongressMediaType-VersionKey'></a>
### VersionKey `constants`

##### Summary

The key used for the version parameterr in the media type.

<a name='P-RemoteCongress-Common-RemoteCongressMediaType-None'></a>
### None `property`

##### Summary

A [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') representing no value.

<a name='P-RemoteCongress-Common-RemoteCongressMediaType-Structure'></a>
### Structure `property`

##### Summary

The structure defined by the type

<a name='P-RemoteCongress-Common-RemoteCongressMediaType-SubType'></a>
### SubType `property`

##### Summary

The mediatype sub-type

<a name='P-RemoteCongress-Common-RemoteCongressMediaType-Type'></a>
### Type `property`

##### Summary

The mediatype type

<a name='P-RemoteCongress-Common-RemoteCongressMediaType-Version'></a>
### Version `property`

##### Summary

The version of the structure defined by the type.

<a name='M-RemoteCongress-Common-RemoteCongressMediaType-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Tests if an instance is equal to this instance.

##### Returns

If `obj` is equal true is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Instance to compare against |

<a name='M-RemoteCongress-Common-RemoteCongressMediaType-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Fetches a unique hash code for the value of this instance.

##### Parameters

This method has no parameters.

<a name='M-RemoteCongress-Common-RemoteCongressMediaType-Parse-System-String-'></a>
### Parse(mediaType) `method`

##### Summary

Fetches a [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to represent `mediaType`.

##### Returns

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') representation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A string mediatype |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if `mediaType` is invalid. |

<a name='M-RemoteCongress-Common-RemoteCongressMediaType-ToString'></a>
### ToString() `method`

##### Summary

Fetches a string representation of this instance.

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Encryption-RsaUtils'></a>
## RsaUtils `type`

##### Namespace

RemoteCongress.Common.Encryption

##### Summary

A simple utility class to handle RSA Signing and Verification

<a name='M-RemoteCongress-Common-Encryption-RsaUtils-GenerateSignature-System-String,System-String-'></a>
### GenerateSignature(privateKey,message) `method`

##### Summary

Generates an rsa signature hash with a private key that can be verified with the public key.

##### Returns

A [Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') array containing the signature.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A rsa private key to use to generate a signature hash. |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The message to generate the signature for. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw if `privateKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw if `message` is null. |

##### Remarks

We're using this signature hash to ensure the message that is signed is tied to who created it, and so we can make this message immutable. If any of the content of `message` changes later on, the signature verification will fail.

<a name='M-RemoteCongress-Common-Encryption-RsaUtils-GetAlgorithmName'></a>
### GetAlgorithmName() `method`

##### Summary

Fetches a common Hashing Algorithm to used throughout this class.

##### Returns

[SHA512](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Cryptography.HashAlgorithmName.SHA512 'System.Security.Cryptography.HashAlgorithmName.SHA512')

##### Parameters

This method has no parameters.

##### Remarks

In a production version of this platform this should be dynamic.

<a name='M-RemoteCongress-Common-Encryption-RsaUtils-GetEncoding'></a>
### GetEncoding() `method`

##### Summary

Fetches a common [Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') to use throughout this class.

##### Returns

[UTF8](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding.UTF8 'System.Text.Encoding.UTF8')

##### Parameters

This method has no parameters.

##### Remarks

In a production version of this platform this should be dynamic.

<a name='M-RemoteCongress-Common-Encryption-RsaUtils-GetPadding'></a>
### GetPadding() `method`

##### Summary

Fetches a common signature padding configuration to use through out this class.

##### Returns

[Pkcs1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Cryptography.RSASignaturePadding.Pkcs1 'System.Security.Cryptography.RSASignaturePadding.Pkcs1')

##### Parameters

This method has no parameters.

##### Remarks

In a production version of this platform this should be dynamic.

<a name='M-RemoteCongress-Common-Encryption-RsaUtils-VerifySignature-System-String,System-String,System-Byte[]-'></a>
### VerifySignature(publicKey,message,signatureBytes) `method`

##### Summary

Validates that a signature matches the passed message, and is sent from who is being claimed by the public key.

##### Returns

true, if `signatureBytes` is a valid signature for `publicKey` and `message`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A rsa public key to match the signature against. |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The message content to ensure is valid and unmutated since signed. |
| signatureBytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The signature to test against `publicKey` and `message`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw if `publicKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw if `message` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw if `signatureBytes` is null. |

##### Remarks

We're using this verification to know that our signed data content is coming from the individual who is represnted by `publicKey` and that their `message` isn't tampered with.

<a name='T-RemoteCongress-Common-SignedData'></a>
## SignedData `type`

##### Namespace

RemoteCongress.Common

##### Summary

A simple data transfer object that contains signed data.

<a name='M-RemoteCongress-Common-SignedData-#ctor-System-String,System-String,System-Byte[],RemoteCongress-Common-RemoteCongressMediaType-'></a>
### #ctor(publicKey,blockContent,signature,mediaType) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| publicKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string representation of the data producer's public key. |
| blockContent | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content of the data. |
| signature | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The signature of the [BlockContent](#P-RemoteCongress-Common-SignedData-BlockContent 'RemoteCongress.Common.SignedData.BlockContent') that can be verified with [PublicKey](#P-RemoteCongress-Common-SignedData-PublicKey 'RemoteCongress.Common.SignedData.PublicKey'). |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of [BlockContent](#P-RemoteCongress-Common-SignedData-BlockContent 'RemoteCongress.Common.SignedData.BlockContent'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `publicKey` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `blockContent` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `signature` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `mediaType` is null. |

##### Remarks

The data isn't validated, and could be in an invalid state.

<a name='M-RemoteCongress-Common-SignedData-#ctor-RemoteCongress-Common-ISignedData-'></a>
### #ctor(data) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [RemoteCongress.Common.ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') | An [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance to populate data from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [RemoteCongress.Common.Exceptions.InvalidBlockSignatureException](#T-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException') | Thrown if `data` contains non verifiable data. |

##### Remarks

Since `data` is a [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') instance we validate it before populating
    data from it. So the created [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') instance will be valid when created, but
    since it's mutable it may not stay that way.

<a name='M-RemoteCongress-Common-SignedData-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

##### Remarks

The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') is created in an invalid state, and must be populated with valid data.

<a name='P-RemoteCongress-Common-SignedData-BlockContent'></a>
### BlockContent `property`

##### Summary

The content of the data.

<a name='P-RemoteCongress-Common-SignedData-Id'></a>
### Id `property`

##### Summary

The unique identifier of the contained data.

<a name='P-RemoteCongress-Common-SignedData-MediaType'></a>
### MediaType `property`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of [BlockContent](#P-RemoteCongress-Common-SignedData-BlockContent 'RemoteCongress.Common.SignedData.BlockContent')

<a name='P-RemoteCongress-Common-SignedData-PublicKey'></a>
### PublicKey `property`

##### Summary

The string representation of the data producer's public key.

<a name='P-RemoteCongress-Common-SignedData-Signature'></a>
### Signature `property`

##### Summary

The signature of the [BlockContent](#P-RemoteCongress-Common-SignedData-BlockContent 'RemoteCongress.Common.SignedData.BlockContent') that can be verified with [PublicKey](#P-RemoteCongress-Common-SignedData-PublicKey 'RemoteCongress.Common.SignedData.PublicKey').

<a name='T-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec'></a>
## SignedDataCollectionV1JsonCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a collection of [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData').

<a name='M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataCollectionV1JsonCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,data) `method`

##### Summary

Decodes a `data` into a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') collection.

##### Returns

The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') collection from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,System-Collections-Generic-IEnumerable{RemoteCongress-Common-SignedData}-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.SignedData}') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-SignedDataCollectionV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec'></a>
## SignedDataV1AvroCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 avro representation of a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData').

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataV1AvroCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataV1AvroCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataV1AvroCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataV1AvroCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder-'></a>
### DecodeAvro(mediaType,decoder) `method`

##### Summary

Decodes a `decoder` into a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData').

##### Returns

The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') from `decoder`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| decoder | [Avro.IO.Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') | The [Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-SignedData-'></a>
### EncodeAvro(encoder,mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encoder | [Avro.IO.Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') | The [Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') to encode data to. |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1AvroCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec'></a>
## SignedDataV1JsonCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData').

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataV1JsonCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataV1JsonCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-SignedDataV1JsonCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.SignedDataV1JsonCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,data) `method`

##### Summary

Decodes a `data` into a [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData').

##### Returns

The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-SignedData-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-SignedDataV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException'></a>
## UnknownBlockMediaTypeException `type`

##### Namespace

RemoteCongress.Common.Exceptions

##### Summary

An [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to throw when a [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData')'s [MediaType](#P-RemoteCongress-Common-ISignedData-MediaType 'RemoteCongress.Common.ISignedData.MediaType') isn't
    supported by the configured codecs

<a name='M-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,innerException) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |
| innerException | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Another exception that brought this exception to light. |

<a name='M-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A message describing the exceptional situation in detail. |

<a name='M-RemoteCongress-Common-Exceptions-UnknownBlockMediaTypeException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='T-RemoteCongress-Common-VerifiedData`1'></a>
## VerifiedData\`1 `type`

##### Namespace

RemoteCongress.Common

##### Summary

A class that contains the base logic for generating immutable and verified data models.

<a name='M-RemoteCongress-Common-VerifiedData`1-#ctor-System-String,RemoteCongress-Common-ISignedData,`0-'></a>
### #ctor(id,data,model) `constructor`

##### Summary

Constructor for a persisted version of the data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [Id](#P-RemoteCongress-Common-VerifiedData`1-Id 'RemoteCongress.Common.VerifiedData`1.Id') of the persisted data. |
| data | [RemoteCongress.Common.ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') | The [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') data to use to construct the [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData'). |
| model | [\`0](#T-`0 '`0') | The `TModel` that contains the [BlockContent](#P-RemoteCongress-Common-ISignedData-BlockContent 'RemoteCongress.Common.ISignedData.BlockContent'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `id` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `model` is null. |
| [RemoteCongress.Common.Exceptions.InvalidBlockSignatureException](#T-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException') | Thrown if [Signature](#P-RemoteCongress-Common-VerifiedData`1-Signature 'RemoteCongress.Common.VerifiedData`1.Signature') is invalid, and we can't ensure the data hasn't been tampered with. |

<a name='M-RemoteCongress-Common-VerifiedData`1-#ctor-RemoteCongress-Common-ISignedData,`0-'></a>
### #ctor(data,model) `constructor`

##### Summary

Constructor for a non-persisted version of the data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [RemoteCongress.Common.ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') | The [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData') data to use to construct the [ISignedData](#T-RemoteCongress-Common-ISignedData 'RemoteCongress.Common.ISignedData'). |
| model | [\`0](#T-`0 '`0') | The `TModel` that contains the [BlockContent](#P-RemoteCongress-Common-ISignedData-BlockContent 'RemoteCongress.Common.ISignedData.BlockContent'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `model` is null. |
| [RemoteCongress.Common.Exceptions.InvalidBlockSignatureException](#T-RemoteCongress-Common-Exceptions-InvalidBlockSignatureException 'RemoteCongress.Common.Exceptions.InvalidBlockSignatureException') | Thrown if [Signature](#P-RemoteCongress-Common-VerifiedData`1-Signature 'RemoteCongress.Common.VerifiedData`1.Signature') is invalid, and we can't ensure the data hasn't been tampered with. |

<a name='P-RemoteCongress-Common-VerifiedData`1-BlockContent'></a>
### BlockContent `property`

##### Summary

The content of the model.

##### Remarks

Currently in this proof of concept this needs to be json, but in a more built out version
 I'd expect this to be any number of formats, and we'd have a way to handle different
 formats.

<a name='P-RemoteCongress-Common-VerifiedData`1-Data'></a>
### Data `property`

##### Summary



<a name='P-RemoteCongress-Common-VerifiedData`1-Id'></a>
### Id `property`

##### Summary

The unique Identifier of the persisted version.

##### Remarks

If this data isn't persisted this will be [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty').

<a name='P-RemoteCongress-Common-VerifiedData`1-MediaType'></a>
### MediaType `property`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') of [BlockContent](#P-RemoteCongress-Common-VerifiedData`1-BlockContent 'RemoteCongress.Common.VerifiedData`1.BlockContent')

<a name='P-RemoteCongress-Common-VerifiedData`1-PublicKey'></a>
### PublicKey `property`

##### Summary

The string representation of the data producer's public key.

<a name='P-RemoteCongress-Common-VerifiedData`1-Signature'></a>
### Signature `property`

##### Summary

The signature of the [BlockContent](#P-RemoteCongress-Common-VerifiedData`1-BlockContent 'RemoteCongress.Common.VerifiedData`1.BlockContent') that can be verified with [PublicKey](#P-RemoteCongress-Common-VerifiedData`1-PublicKey 'RemoteCongress.Common.VerifiedData`1.PublicKey').

<a name='T-RemoteCongress-Common-Vote'></a>
## Vote `type`

##### Namespace

RemoteCongress.Common

##### Summary

A model representing a vote

<a name='P-RemoteCongress-Common-Vote-BillId'></a>
### BillId `property`

##### Summary

The [Id](#P-RemoteCongress-Common-IIdentifiable-Id 'RemoteCongress.Common.IIdentifiable.Id') of the [Bill](#T-RemoteCongress-Common-Bill 'RemoteCongress.Common.Bill') being voted on.

<a name='P-RemoteCongress-Common-Vote-Message'></a>
### Message `property`

##### Summary

A short optional message explaining the [Opinion](#P-RemoteCongress-Common-Vote-Opinion 'RemoteCongress.Common.Vote.Opinion').

<a name='P-RemoteCongress-Common-Vote-Opinion'></a>
### Opinion `property`

##### Summary

The opinion of the [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote'). True if voting yes, False if voting no, and null if present.

<a name='T-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor'></a>
## VoteQueryProcessor `type`

##### Namespace

RemoteCongress.Common.Repositories.Queries

##### Summary

Query processing logic for [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote')s.

<a name='M-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Repositories.Queries.VoteQueryProcessor}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') to use for logging. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='M-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor-BlockMatchesQuery-System-Collections-Generic-IEnumerable{RemoteCongress-Common-Repositories-Queries-IQuery},RemoteCongress-Common-SignedData,RemoteCongress-Common-Vote-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches everything defined `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{RemoteCongress.Common.Repositories.Queries.IQuery}') | A collection of [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery')s to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [RemoteCongress.Common.Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') | The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') to test against `query` against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `query` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `signedData` is null. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `data` is null. |

<a name='M-RemoteCongress-Common-Repositories-Queries-VoteQueryProcessor-BlockMatchesQuery-RemoteCongress-Common-Repositories-Queries-IQuery,RemoteCongress-Common-SignedData,RemoteCongress-Common-Vote-'></a>
### BlockMatchesQuery(query,signedData,data) `method`

##### Summary

Tests if a block defined by `data` and `signedData` mataches `query`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [RemoteCongress.Common.Repositories.Queries.IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') | An [IQuery](#T-RemoteCongress-Common-Repositories-Queries-IQuery 'RemoteCongress.Common.Repositories.Queries.IQuery') to filter on. |
| signedData | [RemoteCongress.Common.SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') | The [SignedData](#T-RemoteCongress-Common-SignedData 'RemoteCongress.Common.SignedData') to test against `query` against. |
| data | [RemoteCongress.Common.Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') | The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') to test against `query` against. |

<a name='T-RemoteCongress-Common-Serialization-VoteV1AvroCodec'></a>
## VoteV1AvroCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 avro representation of a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

<a name='M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-VoteV1AvroCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.VoteV1AvroCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-VoteV1AvroCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.VoteV1AvroCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-VoteV1AvroCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-DecodeAvro-RemoteCongress-Common-RemoteCongressMediaType,Avro-IO-Decoder-'></a>
### DecodeAvro(mediaType,decoder) `method`

##### Summary

Decodes a `decoder` into a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Returns

The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') from `decoder`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| decoder | [Avro.IO.Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') | The [Decoder](#T-Avro-IO-Decoder 'Avro.IO.Decoder') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-EncodeAvro-Avro-IO-Encoder,RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Vote-'></a>
### EncodeAvro(encoder,mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encoder | [Avro.IO.Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') | The [Encoder](#T-Avro-IO-Encoder 'Avro.IO.Encoder') to encode data to. |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-VoteV1AvroCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.

<a name='T-RemoteCongress-Common-Serialization-VoteV1JsonCodec'></a>
## VoteV1JsonCodec `type`

##### Namespace

RemoteCongress.Common.Serialization

##### Summary

An [ICodec\`1](#T-RemoteCongress-Common-Serialization-ICodec`1 'RemoteCongress.Common.Serialization.ICodec`1') for a version 1 json representation of a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

<a name='M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-#ctor-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-VoteV1JsonCodec}-'></a>
### #ctor(logger) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.VoteV1JsonCodec}](#T-Microsoft-Extensions-Logging-ILogger{RemoteCongress-Common-Serialization-VoteV1JsonCodec} 'Microsoft.Extensions.Logging.ILogger{RemoteCongress.Common.Serialization.VoteV1JsonCodec}') | An [ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') instance to log against. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `logger` is null. |

<a name='F-RemoteCongress-Common-Serialization-VoteV1JsonCodec-MediaType'></a>
### MediaType `constants`

##### Summary

The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') handled by this codec.

<a name='M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-DecodeJson-RemoteCongress-Common-RemoteCongressMediaType,Newtonsoft-Json-Linq-JToken-'></a>
### DecodeJson(mediaType,data) `method`

##### Summary

Decodes a `data` into a [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote').

##### Returns

The [Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') from `data`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to decode the data from. |
| data | [Newtonsoft.Json.Linq.JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') | The [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') to decode data from. |

<a name='M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-EncodeJson-RemoteCongress-Common-RemoteCongressMediaType,RemoteCongress-Common-Vote-'></a>
### EncodeJson(mediaType,data) `method`

##### Summary

Encodes `data` into `mediaType`.

##### Returns

A [JToken](#T-Newtonsoft-Json-Linq-JToken 'Newtonsoft.Json.Linq.JToken') containing the encoded data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediaType | [RemoteCongress.Common.RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') | The [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') to encode the data to. |
| data | [RemoteCongress.Common.Vote](#T-RemoteCongress-Common-Vote 'RemoteCongress.Common.Vote') | The data to encode. |

<a name='M-RemoteCongress-Common-Serialization-VoteV1JsonCodec-GetPreferredMediaType'></a>
### GetPreferredMediaType() `method`

##### Summary

Gets the preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType') for the codec.

##### Returns

The preferred [RemoteCongressMediaType](#T-RemoteCongress-Common-RemoteCongressMediaType 'RemoteCongress.Common.RemoteCongressMediaType').

##### Parameters

This method has no parameters.
