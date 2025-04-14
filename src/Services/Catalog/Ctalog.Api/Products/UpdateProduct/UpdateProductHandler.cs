
namespace Ctalog.Api.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name,List<string> Category ,string Description, decimal Price, string ImageUrl)
        :ICommand<UpdateproductResult>;

    public record UpdateproductResult(bool IsSuccess);

    internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
        : ICommandHandler<UpdateProductCommand, UpdateproductResult>
    {
        public async Task<UpdateproductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id,cancellationToken);
            if (product is null)
            {
                logger.LogError("Product with id {Id} not found", command.Id);
                throw new ProductNotFoundException(); 
            }
            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageUrl;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateproductResult(true);
        }
    }
}
