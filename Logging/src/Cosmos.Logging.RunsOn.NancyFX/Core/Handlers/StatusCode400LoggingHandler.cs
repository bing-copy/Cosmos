﻿using System;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.RunsOn.NancyFX.Core.Abstractions;
using Nancy;
using Nancy.ErrorHandling;

namespace Cosmos.Logging.RunsOn.NancyFX.Core.Handlers {
    public class StatusCode400LoggingHandler : IStatusCodeHandler, IErrorHandler {
        private readonly ILogger _logger = Core.HandlerLoggerContainer.ErrorHandlerLogger<StatusCode500LoggingHandler>();

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context) {
            return statusCode >= HttpStatusCode.BadRequest && statusCode < HttpStatusCode.InternalServerError;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context) {
            if (context.Items.TryGetValue(NancyEngine.ERROR_EXCEPTION, out var errorObject) && errorObject is Exception exception) {
                _logger.LogError(exception, $"{(int) statusCode} - {exception.ToUwrapedString()}");
            }
        }
    }
}