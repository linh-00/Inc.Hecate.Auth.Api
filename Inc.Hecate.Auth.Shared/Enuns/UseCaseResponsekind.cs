using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Enuns
{
    public enum UseCaseResponsekind
    {
        Success,
        DataPersisted,
        DataAccepted,
        InternalServerError,
        RequestValidationError,
        ForeingKeyViolationError,
        UniqueViolationError,
        RequiredResourceNotFound,
        NotFound,
        Unauthorized,
        Forbidden,
        Unavailable
    }
}
