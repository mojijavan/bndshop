

using System;

namespace _0_Framework.Application
{
    public class CustomException: Exception
    {
        public CustomException(string message) : base(message)
        {
        }

    }
}
