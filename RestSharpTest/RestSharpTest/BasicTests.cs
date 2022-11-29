using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
using RestSharpTest.Base;
using System.Net;
using Xunit;

namespace RestSharpTest
{
    public class BasicTests
    {
        private readonly IRestFactory _restFactory;
        private readonly string _token;

        public BasicTests(IRestFactory restFactory)
        {
            _restFactory = restFactory;
            _token = GetToken();
        }

        [Fact]
        public async Task GetProductByIdTest()
        {
            var response = await _restFactory.Create()
                .WithRequest("Product/GetProductById/1")
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithGet<Product>();

            response.Should().NotBeNull();
            response?.Name.Should().Be("Keyboard");
        }

        [Fact]
        public async Task GetProductByIdWithQuerySegmentTest()
        {
            var response = await _restFactory.Create()
                .WithRequest("Product/GetProductById/{id}")
                .WithUrlSegment("id", "2")
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithGet<Product>();

            response.Should().NotBeNull();
            response?.Price.Should().Be(400);
        }

        [Fact]
        public async Task GetProductByIdAndNameWithQueryParameterTest()
        {
            var response = await _restFactory.Create()
                .WithRequest("Product/GetProductByIdAndName")
                .WithQueryParameter("id", "3")
                .WithQueryParameter("name", "Mouse")
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithGet<Product>();

            response.Should().NotBeNull();
            response?.ProductType.Should().Be(ProductType.PERIPHARALS);
        }

        [Fact]
        public async Task PostProductTest()
        {
            var response = await _restFactory.Create()
                .WithRequest("Product/Create")
                .WithBody(new Product
                {
                    Name = "Printer",
                    Description = "Color Printer",
                    Price = 300,
                    ProductType = ProductType.PERIPHARALS
                })
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithPost<Product>();

            response.Should().NotBeNull();
            response?.Description.Should().Be("Color Printer");
            response?.ProductType.Should().Be(ProductType.PERIPHARALS);
        }

        [Fact]
        public async Task FileUploadTest()
        {
            var response = await _restFactory.Create()
                .WithRequest("Product")
                .WithFile("myFile",
                @"C:\Users\tkovalova-old\WORK\CSharp\GraphQL.NET-main\RestSharpTest\RestSharpTest\TestData\Map_of_Ukraine.png", 
                "multipart/form-data")
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithPost();

            response.Should().NotBeNull();
            response?.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        private string GetToken()
        {
            var response = _restFactory.Create()
                .WithRequest("api/Authenticate/Login")
                .WithBody(new LoginModel
                {
                    UserName = "tanya",
                    Password = "321"
                })
                .WithPost().Result.Content;

            response.Should().NotBeNullOrEmpty();

            var token = JObject.Parse(response!)["token"]?.ToString();
            token.Should().NotBeNullOrEmpty();

            return token!;
        }
    }
}