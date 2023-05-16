using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SocialNetworkServer.DTO
{
    public abstract class Response
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public List<object> Errors { get; set; } = null;
    }

    public class ResponseDTO : Response
    {
        public object Data { get;} = null;
    }

    public class ResponseDTO<T> : Response
    {
        public T Data { get; set; }
    }
}
