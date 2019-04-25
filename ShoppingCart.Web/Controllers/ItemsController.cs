using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Web.Domain;
using ShoppingCart.Web.Dtos;
using ShoppingCart.Web.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.Web.Controllers
{
    [Route("items")]
    public class ItemsController : Controller
    {
        private readonly ItemTypeRepository _itemTypeRepository;

        private readonly ItemRepository _itemRepository;

        public ItemsController(ItemTypeRepository itemTypeRepository, ItemRepository itemRepository)
        {
            _itemTypeRepository = itemTypeRepository;
            _itemRepository = itemRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public ObjectResult Get(string itemCode)
        {
            try
            {
                var item = _itemRepository.Get(itemCode);
                return new OkObjectResult(item);
            }
            catch (Exception)
            {
                return new ObjectResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public StatusCodeResult Post([FromBody]ItemDto itemDto)
        {
            try
            {
                var itemType = _itemTypeRepository.Get(itemDto.ItemTypeCode);

                if (itemType != null)
                {
                    var item = new Item(
                        code: itemDto.Code,
                        price: new Money(itemDto.Price),
                        itemType: itemType
                    );

                    _itemRepository.Save(item);

                    return new OkResult();
                }

                return new NotFoundResult();
            }
            catch (Exception)
            {
               return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
