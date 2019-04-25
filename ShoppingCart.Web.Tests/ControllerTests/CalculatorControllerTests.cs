//using ShoppingCart.Web.Controllers;
//using ShoppingCart.Web.Domain;
//using ShoppingCart.Web.Dtos;
//using ShoppingCart.Web.Repositories;
//using System.Collections.Generic;
//using System.Net;
//using Xunit;

//namespace ShoppingCart.Web.Tests
//{
//    public class CalculatorControllerTests
//    {
//        [Fact]
//        public void GetTotalCost()
//        {
//            var itemTypeRepository = new ItemTypeRepository();
//            var itemTypesController = new ItemTypesController(itemTypeRepository);
//            var itemsController = new ItemsController(itemTypeRepository, new ItemRepository());
//            var calculatorController = new CalculatorController();

//            var itemTypeCode = "fruit";
//            itemTypesController.Post(new ItemTypeDto { Code = itemTypeCode });
//            var getItemTypeResult = itemTypesController.Get(itemTypeCode);

//            Assert.NotNull(getItemTypeResult.Value);
//            var itemType = (ItemType)getItemTypeResult.Value;

//            const string itemCode = "banana";
//            itemsController.Post(
//                new ItemDto
//                {
//                    Code = itemCode,
//                    Price = 50,
//                    ItemTypeCode = itemType.Code
//                }
//            );
//            var getItemResult = itemsController.Get(itemCode);

//            Assert.NotNull(getItemResult.Value);
//            var item = (Item)getItemResult.Value;

//            var response = calculatorController.GetTotalCost(
//                new List<ShoppingItem>
//                {
//                    new ShoppingItem { Item = item, Quantity = 5 }
//                }
//            );

//            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
//        }
//    }
//}
