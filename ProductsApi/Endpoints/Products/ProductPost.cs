using Microsoft.AspNetCore.Mvc;
using ProductsApi.Infra.Data;
using ProductsApi.Entities;

namespace ProductsApi.Endpoints.Products
{
    public class ProductPost
    {
        public static string Template => "/products";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromBody] ProductRequest productRequest, ApplicationDbContext context)
        {
            Category category = new Category
            {
                Name = productRequest.Category
            };

            var newProduct = new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Model = productRequest.Model,
                Category = category
            };

            context.Products.Add(newProduct);
            context.SaveChanges();

            return Results.Created($"/products/{newProduct.Id}", newProduct.Id);
        }
    }
}
