namespace Ctalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryQueryHandler(IDocumentSession session,ILogger<GetProductByCategoryQuery> logger)
        :IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                .Where(x => x.Category.Contains(request.Category))
                .ToListAsync();
            if (products is null || !products.Any())
            {
                logger.LogWarning("No products found for category {Category}", request.Category);
                return new GetProductByCategoryResult(products);
            }
            return new GetProductByCategoryResult(products);
        }
    }
}
