using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Levelup.WebService.Results
{
    public class Response
    {
        //public enum ResponseStatus { Success, Error }

        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }


        public Response(HttpStatusCode status, string message, dynamic data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }

    //public class Response : IHttpActionResult
    //{
    //    public enum ResponseStatus { Success, Error }

    //    public string Status { get; set; }
    //    public string Message { get; set; }
    //    public dynamic Data { get; set; }
    //    public HttpRequestMessage Request { get; set; }

    //    public Response(ResponseStatus status, string message, dynamic data, ApiController controller)
    //    {
    //        Status = status == 0 ? "Success" : "Error";
    //        Message = message;
    //        Data = data;
    //        Request = controller.Request;
    //    }

    //    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    //    {
    //        HttpResponseMessage response = new HttpResponseMessage();
    //        response.RequestMessage = Request;
    //        response.Content = new StringContent(JsonConvert.SerializeObject(new { Message, Status, Data  }));
    //        return Task.FromResult(response);
    //    }
    //}
}