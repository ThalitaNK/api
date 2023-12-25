using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapPost("/saveproduct", (Product product) =>
        {
            ProductRepository.Add(product);

        });

        app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
        {
            var product = ProductRepository.GetBy(code);
            return product;
        });

        ///para editar o produto
        app.MapPut("/editproduct", (Product product) =>
        {
            var productSaved = ProductRepository.GetBy(product.Code);
            productSaved.Name = product.Name;
            return productSaved;
        });

        app.MapDelete("/deleteproduct/{code}", ([FromRoute] string code) =>
        {
            var productSaved = ProductRepository.GetBy(code);
            ProductRepository.Remove(productSaved);
            
            if (productSaved != null)
            {
                ProductRepository.Remove(productSaved);
                string message = $"Product with code {code} deleted";
                return Results.Ok(message);
            }
            else
            {
                string errorMessage = $"Product with code {code} not found";
                return Results.NotFound(errorMessage);
            }
        });

        app.Run();
    }
}

/// <summary>
/// o static faz com que essa classe continue funcionando na memória mesmo que a gente faça requisição após requisição. 
/// Sempre que usamos static em uma classe, significa que vai ficar na memória do servidor e vai ser disponibilizado
/// entre qualquer requisição. Ela se torna global. Se uma classe é static, todos os métodos dentro dela tbm precisam ser.
/// </summary>
public static class ProductRepository
{
    public static List<Product> Products { get; set; }

    public static void Add(Product product)
    {
        if (Products == null)
            Products = new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code)
    {
        return Products.FirstOrDefault(p => p.Code == code);
    }

    public static void Remove(Product product)
    {
        Products.Remove(product);
    }

}

public class Product
{
    public string Code { get; set; }
    public string Name { get; set; }
}