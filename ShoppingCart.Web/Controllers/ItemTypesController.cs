using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Web.Domain;
using ShoppingCart.Web.Dtos;
using ShoppingCart.Web.Repositories;

namespace ShoppingCart.Web.Controllers
{
    [Route("itemTypes")]
    [ApiController]
    public class ItemTypesController : ControllerBase
    {
        private readonly ItemTypeRepository _itemTypeRepository;

        public ItemTypesController(ItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        // GET itemTypes
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_itemTypeRepository.GetAll());
        }

        // GET itemTypes/fruit
        [HttpGet("{itemTypeCode}")]
        public ActionResult GetItemType(string itemTypeCode)
        {
            var itemType = _itemTypeRepository.Get(itemTypeCode);

            if (itemType == null) return NotFound();

            return Ok(itemType);
        }

        // POST itemTypes
        [HttpPost]
        public ActionResult PostItemType([FromBody] ItemTypeDto itemTypeDto)
        {
            var itemType = new ItemType(itemTypeDto.Code);

            _itemTypeRepository.Save(itemType);

            return CreatedAtAction(nameof(GetItemType), new { itemTypeCode = itemType.Code }, itemType);
        }
    }
}
