using ProductsApi.Entities;

namespace ProductsApi.Endpoints.Products
{
    public record ProductResponse(int Id, string Name, string Model, double Price, Category Category);
}
