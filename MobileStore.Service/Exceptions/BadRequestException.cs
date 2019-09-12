using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Service.Exceptions
{
    class BadRequestException : Exception
    {
        public BadRequestException(string error): base(message: error)
        {

        }
    }
}
