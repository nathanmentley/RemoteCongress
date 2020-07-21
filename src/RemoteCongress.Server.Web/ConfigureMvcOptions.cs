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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RemoteCongress.Common.Logging;
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

        public ConfigureMvcOptions(ILogger<ConfigureMvcOptions> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _loggerFactory = loggerFactory ??
                throw logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(loggerFactory))
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

            options.InputFormatters.Insert(
                0,
                new BillInputFormatter(_loggerFactory.CreateLogger<BillInputFormatter>())
            );
            options.InputFormatters.Insert(
                0,
                new VoteInputFormatter(_loggerFactory.CreateLogger<VoteInputFormatter>())
            );

            _logger.LogTrace("Setting up output formatters.");

            options.OutputFormatters.Insert(
                0,
                new BillOutputFormatter(_loggerFactory.CreateLogger<BillOutputFormatter>())
            );
            options.OutputFormatters.Insert(
                0,
                new VoteOutputFormatter(_loggerFactory.CreateLogger<VoteOutputFormatter>())
            );
        }

        private void SetupExceptionHandlers(MvcOptions options)
        {
            _logger.LogTrace("Setting up exception handlers.");

            options.Filters.Insert(
                0,
                new BlockNotFoundExceptionFilter(
                    _loggerFactory.CreateLogger<BlockNotFoundExceptionFilter>()
                )
            );
            options.Filters.Insert(
                0,
                new BlockNotStorableExceptionFilter(
                    _loggerFactory.CreateLogger<BlockNotStorableExceptionFilter>()
                )
            );
            options.Filters.Insert(
                0,
                new InvalidBlockSignatureExceptionFilter(
                    _loggerFactory.CreateLogger<InvalidBlockSignatureExceptionFilter>()
                )
            );
            options.Filters.Insert(
                0,
                new MissingBodyExceptionFilter(
                    _loggerFactory.CreateLogger<MissingBodyExceptionFilter>()
                )
            );
            options.Filters.Insert(
                0,
                new MissingPathParameterExceptionFilter(
                    _loggerFactory.CreateLogger<MissingPathParameterExceptionFilter>()
                )
            );
        }
    }
}