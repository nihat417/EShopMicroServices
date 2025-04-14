﻿
namespace Ctalog.Api.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id,string Name, List<string> Category, string Description, decimal Price, string ImageUrl);
    public record UpdateProductResponse(bool IsSuccess);

    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();
                return result.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
            }).WithName("UpdateProduct")
              .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
              .Produces<UpdateProductResponse>(StatusCodes.Status400BadRequest)
              .Produces<UpdateProductResponse>(StatusCodes.Status404NotFound)
              .WithSummary("Update a product")
              .WithDescription("Update a product");
        }
    }
}
