using Microsoft.AspNetCore.Mvc;
using SimplePay.DTOs;
using SimplePay.Mappings;
using SimplePay.Service;

namespace SimplePay.Controllers

{
    [ApiController]
    [Route("/shopkeepers")]
    public class ShopkeeperController(IShopkeeperService shopkeeperService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetShopkeeper(Guid id)
        {
            var shopkeeper = await shopkeeperService.GetShopkeeperAsync(id);
            if (shopkeeper == null) return NotFound();
            return Ok(shopkeeper.ToShopkeeperDetailResponseDto());
        }
        
        [HttpGet]
        public async Task<IActionResult> GetShopkeepers()
        {
            var shopkeepers = await shopkeeperService.GetAllShopkeeperAsync();
            var shopkeeperDtos = await shopkeepers.ToShopkeeperResponseDtoListAsync();
            return Ok(shopkeeperDtos);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateShopkeeper([FromBody] ShopkeeperDto shopkeeperDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdShopkeeper = await shopkeeperService.CreateShopkeeperAsync(shopkeeperDto);
            return CreatedAtAction(
                nameof(GetShopkeeper),
                new { id = createdShopkeeper.Id },
                createdShopkeeper.ToShopkeeperResponseDto()
            );
        }
        
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateShopkeeper(Guid id, [FromBody] ShopkeeperUpdateDto shopkeeperUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await shopkeeperService.PartiallyUpdateShopkeeperAsync(id, shopkeeperUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteShopkeeper(Guid id)
        {
            await shopkeeperService.DeleteShopkeeperAsync(id);
            return NoContent();
        }
    }
}