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
using RemoteCongress.Server.Web.ExceptionFilters;
using RemoteCongress.Server.Web.Formatters;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web
{
    [ExcludeFromCodeCoverage]
    public class ConfigureMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly ILogger<ConfigureMvcOptions> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ICodec<SignedData> _signedDataCodec;
        private readonly ICodec<Bill> _billDataCodec;
        private readonly ICodec<Vote> _voteDataCodec;

        public ConfigureMvcOptions(
            ILogger<ConfigureMvcOptions> logger,
            ILoggerFactory loggerFactory,
            ICodec<SignedData> signedDataCodec,
            ICodec<Bill> billDataCodec,
            ICodec<Vote> voteDataCodec
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _loggerFactory = loggerFactory ??
                throw logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(loggerFactory))
                );

            _signedDataCodec = signedDataCodec ??
                throw logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(signedDataCodec))
                );

            _billDataCodec = billDataCodec ??
                throw logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(billDataCodec))
                );

            _voteDataCodec = voteDataCodec ??
                throw logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(voteDataCodec))
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
                    _signedDataCodec,
                    _billDataCodec
                )
            );
            SetupFormatter(
                options.InputFormatters,
                new VerifiedDataInputFormatter<Vote>(
                    _loggerFactory.CreateLogger<VerifiedDataInputFormatter<Vote>>(),
                    _signedDataCodec,
                    _voteDataCodec
                )
            );

            _logger.LogTrace("Setting up output formatters.");

            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataOutputFormatter<Bill>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Bill>>(),
                    _signedDataCodec
                )
            );
            SetupFormatter(
                options.OutputFormatters,
                new VerifiedDataOutputFormatter<Vote>(
                    _loggerFactory.CreateLogger<VerifiedDataOutputFormatter<Vote>>(),
                    _signedDataCodec
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
        }

        private void SetupFormatter<T>(FormatterCollection<T> collection, T formatter) =>
            collection.Insert(0, formatter);

        private void SetupExceptionHandler(FilterCollection filters, IFilterMetadata filter) =>
            filters.Insert(0, filter);
    }
}