using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class ErrorDetails: System.Exception
    {
        public int statusCode { get; set; }
        
        public string message { get; set; }

        public ErrorDetails(int _statusCode, string _message) : base(_message)
        {
            statusCode = _statusCode;
            message = _message;
        }
        public ErrorDetails() : base() { }

        public ErrorDetails(string message) : base(message) { }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
