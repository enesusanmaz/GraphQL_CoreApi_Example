using DataAccessLayer.Abstract;
using DataAccessLayer.Entities;
using GraphQL.Types;
using System.Linq;

namespace GraphQL_DotNetCoreApi_Example.Models
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category id.");
            Field(x => x.Name, nullable: true).Description("Category name.");

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result.ToList()
            );
        }
    }
}
