using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LucidX.ResponseModels
{
    public class FinalResponse
    {

        public string ErrrorMessageFromDal { get; set; }
        public bool ISFailed { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Object ResultDoc { get; set; }
        

    }
}
