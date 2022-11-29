using FluentAssertions;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQLTest.Models;
using Xunit;

namespace GraphQLTest
{
    public class BasicGraphQLTests
    {
        private readonly IGraphQLClient _client;

        public BasicGraphQLTests(IGraphQLClient graphQLClient)
        {
            _client = graphQLClient;
        }

        [Fact]
        public async Task ProductsTest()
        {
            var query = new GraphQLRequest
            {
                Query = @"{
                      products {
                        name,
                        price,
                        component {
                          id,
                          name
                        }
                      }
                    }"
            };

            var response = await _client.SendQueryAsync<ProductQueryResponse>(query);
            response.Data.Products.Should().Contain(product => product.Name == "Keyboard");
        }
    }
}
