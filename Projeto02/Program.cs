using Microsoft.OpenApi.Models;
using Projeto02;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => {
        c.SwaggerDoc("v1", new OpenApiInfo
            {Title="TDS API", Description="", Version=""}
        );
    }
);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(
    c=> {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TDS API V1");
    }
);


var products = new List<Product>();
products.Add(
    new Product(){Product=1, Name="Apple", Category="Hortifruti", Price=2.50,  Supplier="Joao" }
);
products.Add(
    new Product(){Product=2, Name="Pear", Category="Hortifruti", Price=3.50,  Supplier="Jose" }
);

// app.MapGet("/", () => "Hello World!");
app.MapGet("/products", () => products);
app.MapGet("/products/{id}", (int id) =>
{
    return products.SingleOrDefault(
        product => product.ProductID == id);
});

app.MapDelete("/products/{id}", (int id)=>
{
    products.Remove(new Product(){
        ProductID = id
    });
});

app.MapPost("/products", (Product product) => {
    products.Add(product);
});

app.MapPut("/product", (Product product)=> {
    Product? productToUpdate = products.Find(p => p.ProductID.Equals(product.ProductID));
    productToUpdate!.Name = product.Name;
    productToUpdate!.Category = product.Category;
    productToUpdate!.Price = product.Price;
    productToUpdate!.Supplier = product.Supplier;
});

app.Run();
