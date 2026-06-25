using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public static Result Success()
        {
            return new Result()
            {
                IsSuccess = true,

            };


        }

        public static Result Failure(string Error)
        {



            return new Result()
            {
                IsSuccess = false,
                Message = Error
            };

        }
    }
}
