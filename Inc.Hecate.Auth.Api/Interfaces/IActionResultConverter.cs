using Inc.Hecate.Auth.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inc.Hecate.Auth.Api.Interfaces
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response, bool noContentIfSuccess = false);
    }
}
