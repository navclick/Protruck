using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Model
{
  public class Response
    {

        public int Code { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }   
    }
}
