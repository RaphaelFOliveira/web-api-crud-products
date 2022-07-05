using ProductsApi.Endpoints.Products;
using ProductsApi.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionSQL:SqlString"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(ProductPost.Template, ProductPost.Method, ProductPost.Handle);
app.MapMethods(ProductGetAll.Template, ProductGetAll.Method, ProductGetAll.Handle);
app.MapMethods(ProductPut.Template, ProductPut.Method, ProductPut.Handle);
app.MapMethods(ProductDelete.Template, ProductDelete.Method, ProductDelete.Handle);

app.Run();