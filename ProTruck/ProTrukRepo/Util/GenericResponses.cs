using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Util
{
    public static class GenericResponses<T>
    {
        public static Response ResponseStatus(bool isException)
        {
            Response response = new Response();
            response.Code = 500;
            response.IsError = true;
            response.Message = "something went wrong";
            response.Value = null;
            return response;
        }
        public static Response ResponseStatus(bool isError, string message, int Code, T value)
        {
            Response response = new Response();
            if (isError)
            {
                response.Code = Code;
                response.IsError = true;
                response.Message = message;
                response.Value = value;
            }
            else
            {
                response.Code = Code;
                response.IsError = false;
                response.Message = message;
                response.Value = value;
            }
            return response;
        }
    }
}
