using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! Apocalipse is near");
app.MapGet("/user", () => new {Name = "Thalita Meira", Age = 30 });
// app.MapGet("/AddHeader",(HttpResponse response) => {
//     response.Headers.Add("Teste", "Thalita Meira");
//     return new {Name = "Thalita Meira", Age = 30};
// });

// app.MapPost("/saveproduct", (Product product) => {
//     return product.Code + " - " + product.Name;

// });

// app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
//     return dateStart + " - " + dateEnd;
// });

// app.MapGet("/getproduct/{code}", (string code) => {
//     return code;
// });

app.Run();
 
// public class Product {
//     public string Code { get; set;}
//     public string Name { get; set;}
// }