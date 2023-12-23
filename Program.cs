using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! Apocalipse is near");
app.MapGet("/user", () => new {Name = "Thalita Meira", Age = 30 });
app.MapGet("/AddHeader",(HttpResponse response) => {
     response.Headers.Add("Teste", "Thalita Meira");
     return new {Name = "Thalita Meira", Age = 30};
 });

 app.MapPost("/saveproduct", (Product product) => {
     return product.Code + " - " + product.Name;

 });

 app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
     return dateStart + " - " + dateEnd;
 });

 app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
     return code;
 });

 app.MapGet("/getproductbyheader", (HttpRequest request)=> {
    return request.Headers["product-code"].ToString();
 });

app.Run();

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
        if(Products == null)
            Products = new List<Product>();

            Products.Add(product);
    }

    public static Product GetBy(string code) {
         return Products.First(p => p.Code == code);
    }

}
 
 public class Product {
     public string Code { get; set;}
     public string Name { get; set;}
 }