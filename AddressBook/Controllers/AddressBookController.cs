using AddressBook.RabbitMQ;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookBL addressBook;
        private readonly IMessage rabbitMessage;

        public AddressBookController(IAddressBookBL addressBook, IMessage rabbitMessage)
        {
            this.addressBook = addressBook;
            this.rabbitMessage = rabbitMessage;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AddressBookModel bookModel)
        {
            try
            {
                var result = addressBook.Add(bookModel);

                if (result != null)
                {
                    rabbitMessage.SendMessage(result);
                    return Ok(new { success = true, message = "Contact Has Been Added", data = result });
                }
                else
                    return BadRequest(new { success = false, message = "Something went wrong" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("ViewAll")]
        public IActionResult ViewAll()
        {
            try
            {
                var result = addressBook.ViewAll();

                if (result != null)
                    return Ok(new { success = true, data = result });
                else
                    return BadRequest(new { success = false, message = "Nothing Found in the book" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
