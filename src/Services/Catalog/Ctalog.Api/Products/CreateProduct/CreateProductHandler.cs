﻿using BuildingLocks.CQRS;
using Ctalog.Api.Models;

namespace Ctalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category, string Description, string ImageFile, decimal Price):ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
