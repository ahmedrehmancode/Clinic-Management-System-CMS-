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

        public static Result Success(string? message = null)
        {
            return new Result()
            {
                IsSuccess = true,
                Message = message ?? "Operation completed successfully."

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
