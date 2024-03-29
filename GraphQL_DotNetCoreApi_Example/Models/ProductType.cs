﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Entities;
using GraphQL.Types;

namespace GraphQL_DotNetCoreApi_Example.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository)
        {
            Field(x => x.Id).Description("Product id.");
            Field(x => x.Name).Description("Product name.");
            Field(x => x.Description, nullable: true).Description("Product description.");
            Field(x => x.Price).Description("Product price.");

            Field<CategoryType>(
                "category",
                resolve: context => categoryRepository.GetCategoryAsync(context.Source.CategoryId).Result
             );
        }
    }
}
