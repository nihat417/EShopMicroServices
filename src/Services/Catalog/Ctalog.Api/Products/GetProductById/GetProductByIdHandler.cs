namespace Ctalog.Api.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);

    internal class GetProductByIdHandler(IDocumentSession session,ILogger<GetProductByIdHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdHandler");
            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
            if (product is null) throw new ProductNotFoundException();
            return new GetProductByIdResult(product);
        }
    }
}