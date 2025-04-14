﻿
namespace Ctalog.Api.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                var response = result.Adapt<DeleteProductResponse>();
                return result.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
            }).WithName("DeleteProduct")
              .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
              .Produces<DeleteProductResponse>(StatusCodes.Status400BadRequest)
              .Produces<DeleteProductResponse>(StatusCodes.Status404NotFound)
              .WithSummary("Delete a product")
              .WithDescription("Delete a product");
        }
    }
}
