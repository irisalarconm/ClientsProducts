using System.Data.Common;
using pruebaTecnica.Models;

namespace pruebaTecnica.Services;

public class ProductService : IProductService
{
    ProductClientContext context;

    public ProductService(ProductClientContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Product> Get()
    {
        return context.Products;
    }

    public async Task Save(Product product)
    {
        context.Add(product);

        await context.SaveChangesAsync();
    }

    public async Task Update(int id, Product product)
    {
        var ActualProduct = context.Products.Find(id);

        if(ActualProduct != null){

            ActualProduct.NameProduct = product.NameProduct;
            ActualProduct.ClientId = product.ClientId;
            ActualProduct.Description = product.Description;
            ActualProduct.Price = product.Price;

            await context.SaveChangesAsync();

        }
    }

    public async Task Delete(int id)
    {
        var ActualProduct = context.Products.Find(id);

        if(ActualProduct != null)
        {
            context.Remove(ActualProduct);

            await context.SaveChangesAsync();

        }
    }

}

public interface IProductService
{
    IEnumerable<Product> Get();

    Task Save(Product product);

    Task Update(int id, Product product);

    Task Delete(int id);
}