using Microsoft.EntityFrameworkCore; 

namespace pruebaTecnica.Models;

public class ProductClientContext: DbContext
{
    //set del modelo de datos :: tabla
    public DbSet<Client> Clients {get; set;}
    public DbSet<Product> Products {get; set;}

    public ProductClientContext(DbContextOptions<ProductClientContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //List<Client> clientsInit = new List<Client>();
        //clientsInit.Add(new Client() { NameClient = "Adrian", LastnameClient = "Hernandez", DNIClient = 1030692511, AdressClient = "Calle Falsa 123",
        //Phone = 151657489, status = Status.Activo });


        modelBuilder.Entity<Client>(client=>
        {
            client.ToTable("Client");
            client.HasKey(p=>p.ClientId);
            client.Property(p => p.ClientId).ValueGeneratedOnAdd();
            client.Property(p=>p.NameClient).IsRequired().HasMaxLength(150);
            client.Property(p=>p.LastnameClient).IsRequired().HasMaxLength(150);
            //client.HasIndex(p=>p.DNIClient).IsUnique();
            client.Property(p=>p.AdressClient).IsRequired();
            client.Property(p=>p.Phone).IsRequired();
            client.Property(p=>p.status).IsRequired();
            //client.HasData(clientsInit);
            
        });

        //List<Product> productsInit = new List<Product>();
        //productsInit.Add(new Product(){ProductId = 0, 
        //ClientId = 0,
        //NameProduct = "Pesa Rusa", Price = 120000});


        modelBuilder.Entity<Product>(product=>
        {
            product.ToTable("Product");
            product.HasKey(p=>p.ProductId);
            product.Property(p => p.ProductId).ValueGeneratedOnAdd();
            product.HasOne(p=>p.Client).WithMany(p=> p.Product).HasForeignKey(p=> p.ClientId);
            product.Property(p=>p.NameProduct).IsRequired().HasMaxLength(150);
            product.Property(p=>p.Description).IsRequired(false);
            product.Property(p=>p.Price).IsRequired();
            //product.HasData(productsInit);

        });

    }
}
