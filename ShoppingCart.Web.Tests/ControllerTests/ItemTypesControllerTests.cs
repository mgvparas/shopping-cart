using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Web.Controllers;
using ShoppingCart.Web.Domain;
using ShoppingCart.Web.Dtos;
using ShoppingCart.Web.Repositories;
using System.Collections;
using System.Net;
using Xunit;

namespace ShoppingCart.Web.Tests
{
    public class ItemTypesControllerTests
    {
        [Fact]
        public void SaveItemType()
        {
            var itemTypeRepository = new ItemTypeRepository();
            var api = new ItemTypesController(itemTypeRepository);

            var postResponse = api.PostItemType(new ItemTypeDto { Code = "fruit" });
            var postResponseStatusCode = (postResponse as ObjectResult).StatusCode;

            Assert.Equal((int)HttpStatusCode.Created, postResponseStatusCode);
        }

        [Fact]
        public void GetItemTypeAllItemTypes()
        {
            var itemTypeRepository = new ItemTypeRepository();
            var api = new ItemTypesController(itemTypeRepository);

            var postResponse = api.PostItemType(new ItemTypeDto { Code = "fruit" });
            var postResponseStatusCode = (postResponse as ObjectResult).StatusCode;

            Assert.Equal((int)HttpStatusCode.Created, postResponseStatusCode);

            var getResponse = api.GetAll();
            var statusCode = (getResponse as ObjectResult).StatusCode;

            Assert.Equal((int)HttpStatusCode.OK, statusCode);
            Assert.Single((IEnumerable)(getResponse as ObjectResult).Value);
        }

        [Fact]
        public void GetItemType()
        {
            var itemTypeRepository = new ItemTypeRepository();
            var api = new ItemTypesController(itemTypeRepository);

            var postResponse = api.PostItemType(new ItemTypeDto { Code = "fruit" });
            var postResponseStatusCode = (postResponse as ObjectResult).StatusCode;

            Assert.Equal((int)HttpStatusCode.Created, postResponseStatusCode);

            var getResponse = api.GetItemType("fruit");
            var statusCode = (getResponse as ObjectResult).StatusCode;

            Assert.Equal((int)HttpStatusCode.OK, statusCode);
            Assert.Equal("fruit", ((getResponse as ObjectResult).Value as ItemType).Code);
        }
    }
}