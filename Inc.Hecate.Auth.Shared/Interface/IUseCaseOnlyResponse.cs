using Inc.Hecate.Auth.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Interface
{
        public interface IUseCaseOnlyResponse<TResponse>
        {
            Task<UseCaseResponse<TResponse>> Execute();
        }
}
