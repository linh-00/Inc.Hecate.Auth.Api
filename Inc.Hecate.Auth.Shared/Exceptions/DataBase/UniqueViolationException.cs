using Inc.Hecate.Auth.Shared.Exceptions.Exceptions;
using Inc.Hecate.Auth.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Exceptions.DataBase
{
    public class UniqueViolationException : BaseException
    {
        public UniqueViolationException(ErrorMessage error)
           : base(error)
        {
        }
        public UniqueViolationException(ErrorMessage error, Exception exception)
            : base(error, exception)
        {
        }
        public UniqueViolationException(IEnumerable<ErrorMessage> errors, Exception exception)
            : base(errors, exception)
        {
        }
        public UniqueViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
