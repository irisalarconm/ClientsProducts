using Microsoft.AspNetCore.Mvc;
using pruebaTecnica.Models;
using pruebaTecnica.Services;

namespace pruebaTecnica.Controllers;

[Route("prueba/[controller]")]

public class ProductController : ControllerBase
{
    IProductService productService;

    public ProductController(IProductService service)
    {
        productService = service;
    }

    [HttpGet]

    public IActionResult Get()
    {
        return Ok(productService.Get());
    }

    [HttpPost]

    public IActionResult Post([FromBody] Product product)
    {
        productService.Save(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        productService.Update(id, product);
        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        productService.Delete(id);
        return Ok();
    }

}