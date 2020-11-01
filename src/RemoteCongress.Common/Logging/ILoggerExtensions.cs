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
using Microsoft.Extensions.Logging;
using System;

namespace RemoteCongress.Common.Logging
{
    /// <summary>
    /// <see cref="ILogger"/> extension methods.
    /// </summary>
    public static class ILoggerExtensions
    {
        /// <summary>
        /// Logs an exception to an <see cref="ILogger"/>.
        /// </summary>
        /// <param name="logger">
        /// The <see cref="ILogger"/> to log to.
        /// </param>
        /// <param name="logLevel">
        /// The <see cref="LogLevel"/> to log the exception at.
        /// </param>
        /// <param name="exception">
        /// an exception of <typeparamref name="TException"/> to be logged.
        /// </param>
        /// <typeparam name="TException">
        /// A type of <see cref="Exception"/> to be passed through the method.
        /// </typeparam>
        /// <returns>
        /// The passed in <paramref name="exception"/> reference.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="exception"/> is null.
        /// </exception>
        public static TException LogException<TException>(
            this ILogger logger,
            TException exception,
            LogLevel logLevel = LogLevel.Debug
        )
            where TException: Exception
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (exception is null)
            {
                throw logger.LogException(
                    new ArgumentNullException(nameof(exception))
                );
            }

            logger.Log(logLevel, exception, exception.Message);

            return exception;
        }
    }
}