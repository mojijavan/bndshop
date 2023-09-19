using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool IsSucceddes { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSucceddes = false;
        }

        public OperationResult Succeded(string message="عملیات با موفقیت انجما شد")
        {
            IsSucceddes = true;
            Message = message;
            return this;

        }
        public OperationResult Failed(string message)
        {
            IsSucceddes = false;
            Message = message;
            return this;

        }
    }
}
