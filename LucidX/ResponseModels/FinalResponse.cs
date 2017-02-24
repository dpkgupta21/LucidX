using System;
using System.Collections.Generic;
using System.Text;

namespace LucidX.ResponseModels
{
    public class FinalResponse
    {

        public bool ISFailed { get; set; }

        public string StatusCode { get; set; }

        public ResultDoc ResultDoc { get; set; }
    }
}
