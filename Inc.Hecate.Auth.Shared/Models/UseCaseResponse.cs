
using FluentValidation;
using Inc.Hecate.Auth.Shared.Constants;
using Inc.Hecate.Auth.Shared.Enuns;
using Inc.Hecate.Auth.Shared.Exceptions.DataBase;
using Inc.Hecate.Auth.Shared.Interface;

namespace Inc.Hecate.Auth.Shared.Models
{
    public class UseCaseResponse <T> : IResponse
    {
        public UseCaseResponsekind Status { get; private set; }
        public string? ErrorMessage { get; private set; }
        public IEnumerable<ErrorMessage>? Errors { get; private set; }
        public T? Result { get; private set; }
        public string? ResultId { get; private set; }
        public UseCaseResponse<T> SetSuccess(T result)
        {
            Result = result;

            return SetStatus(UseCaseResponsekind.Success);
        }
        public UseCaseResponse<T> SetPersisted(T result, string resultId)
        {
            Result = result;
            ResultId = resultId;

            return SetStatus(UseCaseResponsekind.DataPersisted);
        }
        public UseCaseResponse<T> SetProcessed(T result, string resultId)
        {
            Result = result;
            ResultId = resultId;

            return SetStatus(UseCaseResponsekind.DataAccepted);
        }
        public UseCaseResponse<T> SetInternalServerError(string errorMessage, IEnumerable<ErrorMessage> errors = null)
        {
            return SetStatus(UseCaseResponsekind.InternalServerError, errorMessage, errors);
        }
        public UseCaseResponse<T> SetUnavailable(T result)
        {
            Result = result;
            Status = UseCaseResponsekind.Unavailable;
            ErrorMessage = ApiErrorConstants.SERVICE_UNAVAILABLE;
            return this;
        }
        public UseCaseResponse<T> SetRequestValidationError(string errorMessage, IEnumerable<ErrorMessage> errors = null)
        {
            return SetStatus(UseCaseResponsekind.RequestValidationError, errorMessage, errors);
        }
        public UseCaseResponse<T> SetRequestValidationError(ValidationException ex)
        {
            return SetRequestValidationError(ApiErrorConstants.VALIDATION_EXCEPTION, ex.Errors.Select(error => new ErrorMessage(error.ErrorCode, error.ErrorMessage)));
        }
        public UseCaseResponse<T> SetForeignKeyViolationError(ForeignKeyViolationException ex)
        {
            return SetStatus(UseCaseResponsekind.ForeingKeyViolationError, ApiErrorConstants.FK_VIOLATION_EXCEPTION, ex.Errors);
        }
        public UseCaseResponse<T> SetUniqueViolationError(UniqueViolationException ex)
        {
            return SetStatus(UseCaseResponsekind.UniqueViolationError, ApiErrorConstants.UNIQUE_VIOLATION_EXCEPTION, ex.Errors);
        }
        public UseCaseResponse<T> SetRequiredResourceNotFound(ErrorMessage error)
        {
            return SetStatus(UseCaseResponsekind.RequiredResourceNotFound, ApiErrorConstants.REQUIRED_RESOURCE_NOT_FOUND, new ErrorMessage[] { error });
        }
        public UseCaseResponse<T> SetNotFound(ErrorMessage error)
        {
            return SetStatus(UseCaseResponsekind.NotFound, ApiErrorConstants.DATA_NOT_FOUND, new ErrorMessage[] { error });
        }
        public UseCaseResponse<T> SetNotAuthorized(ErrorMessage error)
        {
            return SetStatus(UseCaseResponsekind.Unauthorized, ApiErrorConstants.NOT_AUTHORIZED, new ErrorMessage[] { error });
        }
        public UseCaseResponse<T> SetStatus(UseCaseResponsekind status, string errorMessage = null, IEnumerable<ErrorMessage> errors = null)
        {
            Status = status;
            ErrorMessage = errorMessage;
            Errors = errors;
            return this;
        }

        public bool Success()
        {
            return ErrorMessage is null;
        }
    }
}
