using System;
using Mango.Web.Models;
namespace Mango.Web.Services.IServices
{
    public interface IBaseService: IDisposable
    {
        //interface can have methods,properties,indexers,events as its members but only contains the definitions of these.
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest); 
    }
}

