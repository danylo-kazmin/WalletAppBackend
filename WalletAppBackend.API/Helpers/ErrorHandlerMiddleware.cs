﻿using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using WalletAppBackend.Service.Helpers;

namespace WalletAppBackend.API.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Service.Helpers.KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
