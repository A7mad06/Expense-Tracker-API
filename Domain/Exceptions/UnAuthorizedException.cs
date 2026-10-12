using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class UnAuthorizedException(string message):Exception(message)
    {

    }
}
