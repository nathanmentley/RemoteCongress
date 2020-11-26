/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2020  Nathan Mentley

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RemoteCongress.Common;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Serialization;
using RemoteCongress.Server.Api.ExceptionFilters;
using RemoteCongress.Server.Api.Formatters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Api
{
    [ExcludeFromCodeCoverage]
    public class ConfigureMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly ILogger<ConfigureMvcOptions> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IEnumerable<ICodec<SignedData>> _signedDataCodecs;
        private readonly IEnumerable<ICodec<IEnumerable<SignedData>>> _signedDataCollectionCodecs;
        private readonly IEnumerable<ICodec<Bill>> _billDataCodecs;
        private readonly IEnumerable<ICodec<Member>> _memberDataCodecs;
        private readonly IEnumerable<ICodec<Vote>> _voteDataCodecs;

        public ConfigureMvcOptions(
            ILogger<ConfigureMvcOptions> logger,
            ILoggerFactory loggerFactory,
            IEnumerable<ICodec<SignedData>> signedDataCodecs,
            IEnumerable<ICodec<IEnumerable<SignedData>>> signedDataCollectionCodecs,
            IEnumerable<ICodec<Bill>> billDataCodecs,
            IEnumerable<ICodec<Member>> memberDataCodecs,
            IEnumerable<ICodec<Vote>> voteDataCodecs
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _loggerFactory = loggerFactory ??
                throw logger.LogException(
                    new ArgumentNullException(nameof(loggerFactory))
                );

            _signedDataCodecs = signedDataCodecs ??
                throw logger.LogException(
                    new ArgumentNullException(nameof(signedDataCodecs))
                );

            _signedDataCollectionCodecs = signedDataCollectionCodecs ??
                throw logger.LogException(
                    new ArgumentNullException(nameof(signedDataCollectionCodecs))
                );

            _billDataCodecs = billDataCodecs ??
                throw logger.LogException(
                    new ArgumentNullException(nameof(billDataCodecs))
                );

            _memberDataCodecs = memberDataCodecs ??
                throw logger.LogException(
                    new ArgumentNullException(nameof(memberDataCodecs))
                );

            _voteDataCodecs = voteDataCodecs ??
                throw logger.LogException(
                    new ArgumentNullException(nameof(voteDataCodecs))
                );
        }
    
        public void Configure(MvcOptions options)
        {
            SetupFormatters(options);

            SetupExceptionHandlers(options);
        }

        private void SetupFormatters(MvcOptions options)
        {
            _logger.LogTrace("Setting up input formatters.");

            SetupFormatter(
                options.InputFormatters,
                new VerifiedDataInputFormatter<Bill>(
                    _loggerFactory.CreateLogger<VerifiedDataInputFormatter<Bill>>(),
                    _signedDataCodecs,
                    _billDataCodecs
                )
            );
            SetupFormatter(
                options.InputFormatters,
                new VerifiedDataInputFormatter<Member>(
                    _loggerFactory.CreateLogger<VerifiedDataInputFormatter<Member>>(),
                    _signedDataCodecs,
                    _memberDataCodecs
                )
            );
            SetupFormatter(
                options.InputFormatters,
                new VerifiedDataInputFormatter<Vote>(
                    _loggerFactory.CreateLogger<VerifiedDataInputFormatter<Vote>>(),
                    _signedDataCodecs,
                    _voteDataCodecs
                )
            );

            _logger.LogTrace("Setting up output formatters.");

            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataCollectionOutputFormatter<Bill>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Bill>>(),
                    _signedDataCollectionCodecs
                )
            );
            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataCollectionOutputFormatter<Member>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Member>>(),
                    _signedDataCollectionCodecs
                )
            );
            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataCollectionOutputFormatter<Vote>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Vote>>(),
                    _signedDataCollectionCodecs
                )
            );

            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataOutputFormatter<Bill>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Bill>>(),
                    _signedDataCodecs
                )
            );
            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataOutputFormatter<Member>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Member>>(),
                    _signedDataCodecs
                )
            );
            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataOutputFormatter<Vote>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Vote>>(),
                    _signedDataCodecs
                )
            );
        }

        private void SetupExceptionHandlers(MvcOptions options)
        {
            _logger.LogTrace("Setting up exception handlers.");

            SetupExceptionHandler(
                options.Filters,
                new BlockNotFoundExceptionFilter(
                    _loggerFactory.CreateLogger<BlockNotFoundExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new BlockNotStorableExceptionFilter(
                    _loggerFactory.CreateLogger<BlockNotStorableExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new InvalidBlockSignatureExceptionFilter(
                    _loggerFactory.CreateLogger<InvalidBlockSignatureExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new UnknownBlockMediaTypeExceptionFilter(
                    _loggerFactory.CreateLogger<UnknownBlockMediaTypeExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new MissingBodyExceptionFilter(
                    _loggerFactory.CreateLogger<MissingBodyExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new MissingPathParameterExceptionFilter(
                    _loggerFactory.CreateLogger<MissingPathParameterExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new UnacceptableMediaTypeExceptionFilter(
                    _loggerFactory.CreateLogger<UnacceptableMediaTypeExceptionFilter>()
                )
            );
            SetupExceptionHandler(
                options.Filters,
                new UnparsableMediaTypeExceptionFilter(
                    _loggerFactory.CreateLogger<UnparsableMediaTypeExceptionFilter>()
                )
            );
        }

        private void SetupFormatter<T>(FormatterCollection<T> collection, T formatter) =>
            collection.Insert(0, formatter);

        private void SetupExceptionHandler(FilterCollection filters, IFilterMetadata filter) =>
            filters.Insert(0, filter);
    }
}