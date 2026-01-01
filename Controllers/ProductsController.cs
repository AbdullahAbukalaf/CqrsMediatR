using CqrsMediatR.Commands;
using CqrsMediatR.Notifications;
using CqrsMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatR.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _Publisher;
        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _Publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductByID(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            //await _sender.Send(new AddProductCommand(product));
            //return StatusCode(201);
            try
            {
                var productToReturn = await _sender.Send(new AddProductCommand(product));

                
                await _Publisher.Publish(new ProductAddedNotification(productToReturn));

                return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        // this is not best practice but I used it just as a simple test
        // in real project I should use DTOs in order to not show the Id in the body request
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                var productToBeUpdated = await _sender.Send(new UpdateProductCommand(product));
                return AcceptedAtRoute("GetProductById", new { id = productToBeUpdated.Id }, productToBeUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _sender.Send(new DeleteProductCommand(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
