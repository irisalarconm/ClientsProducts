using System.Data.Common;
using pruebaTecnica.Models;

namespace pruebaTecnica.Services;

public class HomeService : IHomeService
{
    public string GetHelloWorld()
    {
        return "Hello World";
    }
}

public interface IHomeService
{
    string GetHelloWorld();
}