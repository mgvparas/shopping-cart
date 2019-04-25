//using ShoppingCart.Web.Controllers;
//using ShoppingCart.Web.Dtos;
//using ShoppingCart.Web.Repositories;
//using System.Net;
//using Xunit;

//namespace ShoppingCart.Web.Tests
//{
//    public class ItemsControllerTests
//    {
//        [Fact]
//        public void SaveItem()
//        {
//            var itemTypeRepository = new ItemTypeRepository();
//            var itemTypesController = new ItemTypesController(itemTypeRepository);
//            var itemRepository = new ItemRepository();
//            var itemsController = new ItemsController(itemTypeRepository, itemRepository);

//            itemTypesController.Post(new ItemTypeDto { Code = "fruit" });

//            var result = itemsController.Post(new ItemDto
//            {
//                Code = "banana",
//                Price = 10,
//                ItemTypeCode = "fruit"
//            });

//            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
//        }
//    }
//}
