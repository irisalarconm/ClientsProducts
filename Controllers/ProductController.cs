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

    public async Task<IActionResult> Post([FromBody] Product product)
    {
        await productService.Save(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product product)
    {
        await productService.Update(id, product);
        return Ok();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await productService.Delete(id);
        return Ok();
    }

}