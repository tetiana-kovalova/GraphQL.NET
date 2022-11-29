using GraphQLProductApp.Data;

namespace GraphQLTest.Models
{
    public class ProductQueryResponse
    {
        public IEnumerable<Product>? Products { get; set; }
    }
}
