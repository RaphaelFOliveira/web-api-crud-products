using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;
using ProductsApi.Infra.Data;

namespace ProductsApi.Endpoints.Products
{
    public class ProductPut
    {
        public static string Template => "/products/{id}";
        public static string[] Method => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, [FromBody] ProductRequest productRequest, ApplicationDbContext context)
        {
            Product product = context.Products.Include(p => p.Category)
                .Where(p => p.Id.Equals(id)).FirstOrDefault();

            if (product != null)
            {
                product.Name = productRequest.Name;
                product.Price = productRequest.Price;
                product.Model = productRequest.Model;

                Category category = new Category
                {
                    Name = productRequest.Category
                };

                product.Category = category;

                context.SaveChanges();
                return Results.Ok();

            }
            else
            {
               return Results.NotFound();
            }
        }
    }
}
