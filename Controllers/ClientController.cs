using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaTecnica.Models;
using pruebaTecnica.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaTecnica.Controllers;

[Route("prueba/[controller]")]

public class ClientController : Controller
{
    IClientService clientService;
    ProductClientContext dbcontext;
    private readonly ILogger<ClientController> _logger;
    

    public ClientController(ILogger<ClientController> logger,IClientService service, ProductClientContext db)
    {
        clientService = service;
        dbcontext = db;
        _logger = logger;
    
    }

    [HttpGet]
    [Route("created")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }

    [HttpGet]
    // public IActionResult Index()
    // {
    //     var getClients = clientService.Get();
    //     return View(getClients);
    // }

    public IActionResult Get() //Get() //Index
    {
        try{
            return Ok(clientService.Get());
        } catch (DbUpdateException ex)
        {
            string excep = ex.ToString();
            return Ok(excep);
        } 
        
    }

    [HttpPost]

    public IActionResult Post([FromBody] Client client)
    {
        clientService.Save(client);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Client client)
    {
        clientService.Update(id, client);
        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        clientService.Delete(id);
        return Ok();
    }

    
}