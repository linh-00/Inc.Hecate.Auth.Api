using Inc.Hecate.Auth.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Exceptions.Exceptions
{
    public class IntegracaoException : BaseException
    {
        public IntegracaoException(ErrorMessage error)
          : base(error)
        {
        }
        public IntegracaoException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }
        public IntegracaoException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }
        public IntegracaoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
