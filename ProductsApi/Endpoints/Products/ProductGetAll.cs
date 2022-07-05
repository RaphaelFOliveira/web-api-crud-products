using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;
using ProductsApi.Infra.Data;
using System.Linq;

namespace ProductsApi.Endpoints.Products
{
    public class ProductGetAll
    {
        public static string Template => "/products/{id}";
        public static string[] Method => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context)
        {
            Product product = context.Products.Include(p => p.Category)
                .Where(p => p.Id.Equals(id)).FirstOrDefault();

            if(product != null)
            {
                ProductResponse productResponse = new ProductResponse(product.Id, product.Name, product.Model, product.Price, product.Category);

                return Results.Ok(productResponse);
            }
            else
            {
                return Results.NotFound();
            }
         
        }
    }
}
