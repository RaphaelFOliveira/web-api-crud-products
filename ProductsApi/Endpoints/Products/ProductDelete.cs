using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;
using ProductsApi.Infra.Data;

namespace ProductsApi.Endpoints.Products
{
    public class ProductDelete
    {
        public static string Template => "/products/{id}";
        public static string[] Method => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context)
        {
            Product product = context.Products.Include(p => p.Category)
                .Where(p => p.Id.Equals(id)).FirstOrDefault();

            if (product != null)
            {
                context.Products.Remove(product);
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
