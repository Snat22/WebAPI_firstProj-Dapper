using System.Net;

namespace WebApp.Responses;

public class Responses<T>
{
    public int StatusCode { get; set; }
    public List<string> Description { get; set; } = new List<string>();
    public T Data { get; set; }

    public Responses(HttpStatusCode statusCode,string message,T data)
    {
        StatusCode = (int)statusCode;
        Description.Add(message);
        Data = data; 
    }

    public Responses(HttpStatusCode statusCode,List<string> message,T data)
    {
        StatusCode = (int)statusCode;
        Description = message;
        Data = data;
    }


     public Responses(HttpStatusCode statusCode,List<string> message)
     {
        StatusCode = (int)statusCode;
        Description = message;
     }
        public Responses(HttpStatusCode statusCode,string message)
    {
        StatusCode = (int)statusCode;
        Description.Add(message);
    }

     public Responses(T data)
     {
        StatusCode = 200;
        Data = data;
     }

}
