using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pruebaTecnica.Models;
using pruebaTecnica.Services;
using System.Runtime.CompilerServices;
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
    public IActionResult Index()
    {
        var getClients = clientService.Get();
        return View(getClients);
    }

    //public IActionResult Get() //Get() //Index
    //{
    //       return Ok(clientService.Get());
    //}

    //public IActionResult Create()
    //{
    //    return View();
    //}

    [HttpPost]

    public async Task <IActionResult> Post([FromBody] Client client)
    {

        await clientService.Save(client);
       
        return Ok();
    }

    //! VISTA FORMULARIO //

    


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Client client)
    {
        await clientService.Update(id, client);
        return Ok();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await clientService.Delete(id);
        return Ok();
    }

    
}