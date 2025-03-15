using Inc.Hecate.Auth.Api.Interfaces;
using Inc.Hecate.Auth.Shared.Enuns;
using Inc.Hecate.Auth.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace Inc.Hecate.Auth.Api.Models
{
    public class ActionResultConverter : IActionResultConverter
    {
        private readonly string path;

        public ActionResultConverter(IHttpContextAccessor accessor)
        {
            path = accessor.HttpContext.Request.Path.Value;
        }

        public IActionResult Convert<T>(UseCaseResponse<T> response, bool noContentIfSuccess = false)
        {
            if (response == null)
                return BuildError(new[] { new ErrorMessage("000", "ActionResultCOnverter Error") }, UseCaseResponsekind.InternalServerError);

            if (response.Success())
            {
                if(noContentIfSuccess)
                {
                    return new NoContentResult();
                }
                else
                {
                    return BuildSuccessResult(response.Result, response.ResultId, response.Status);
                }
            }

            else if (response.Result != null && response.Errors == null)
            {
                return BuildError(response.Result, response.Status);
            }
            else
            {
                var hasErrors = response.Errors == null || !response.Errors.Any();
                var errorResult = hasErrors
                    ? new[] { new ErrorMessage("000", response.ErrorMessage ?? "Unknown error") }
                    : response.Errors;


                return BuildError(errorResult, response.Status);
            }

        }

        private IActionResult BuildSuccessResult(object data, string id, UseCaseResponsekind status)
        {
            switch (status)
            {
                case UseCaseResponsekind.DataPersisted:
                    return new CreatedResult($"{path}/{id}", data);

                case UseCaseResponsekind.DataAccepted:
                    return new AcceptedResult($"{path}/{id}", data);

                default:
                    return new OkObjectResult(data);
            }
        }

        private ObjectResult BuildError(object data, UseCaseResponsekind status)
        {
            var httpStatus = GetErrorHttpStatusCode(status);
            if(httpStatus == HttpStatusCode.InternalServerError)
            {
                Log.Error($"[ERROR] {path} ({{@data}})", data);
            }

            return new ObjectResult(data)
            {
                StatusCode = (int)httpStatus
            };
        }

        private HttpStatusCode GetErrorHttpStatusCode(UseCaseResponsekind status)
        {
            switch(status)
            {
                case UseCaseResponsekind.RequestValidationError:
                case UseCaseResponsekind.RequiredResourceNotFound:
                    return HttpStatusCode.BadRequest;
                case UseCaseResponsekind.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case UseCaseResponsekind.Forbidden:
                    return HttpStatusCode.Forbidden;
                case UseCaseResponsekind.NotFound:
                    return HttpStatusCode.NotFound;
                case UseCaseResponsekind.UniqueViolationError:
                    return HttpStatusCode.Conflict;
                case UseCaseResponsekind.Unavailable:
                    return HttpStatusCode.ServiceUnavailable;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
