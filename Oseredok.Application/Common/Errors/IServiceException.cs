using System.Net;

namespace Oseredok.Application.Common.Errors
{
    public interface IServiceException
    {
        public string ErrorMessage { get; }
        public HttpStatusCode StatusCode { get; }
    }
}