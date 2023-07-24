using Microsoft.EntityFrameworkCore;
using pruebaTecnica.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaTecnica.Services;

public class ClientService : IClientService
{
    ProductClientContext context;

    public ClientService(ProductClientContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Client> Get()
    {
        return context.Clients;
    }

    public async Task Save(Client client)
    {
        try{
           
            context.Add(client);

            await context.SaveChangesAsync();
        } catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.ToString());
        } 
        
    }

    public async Task Update(int id, Client client)
    {
        var actualClient = context.Clients.Find(id);

        if(actualClient != null){
            actualClient.NameClient = client.NameClient;
            actualClient.LastnameClient = client.LastnameClient;
            //actualClient.DNIClient = client.DNIClient;
            actualClient.AdressClient = client.AdressClient;
            actualClient.Phone = client.Phone;
            actualClient.status = client.status;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var actualClient = context.Clients.Find(id);
        
        if(actualClient != null){
            
            context.Remove(actualClient);

            await context.SaveChangesAsync();
        }
    }



}

public interface IClientService
{
    IEnumerable<Client> Get();
    
    Task Save(Client client);

    Task Update(int id, Client client);

    Task Delete(int id);
}