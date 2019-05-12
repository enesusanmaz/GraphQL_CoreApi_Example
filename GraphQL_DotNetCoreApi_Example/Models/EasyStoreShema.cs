using GraphQL.Types;
using System;

namespace GraphQL_DotNetCoreApi_Example.Models
{
    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery));
        }
    }
}
