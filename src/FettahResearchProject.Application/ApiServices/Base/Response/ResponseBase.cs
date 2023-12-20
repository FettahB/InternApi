using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Base.Response
{
    public class ResponseBase
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;


        public string ErrorMessage { get; set; }

        public ResponseBase()
        {

        }
        public ResponseBase(HttpStatusCode statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
