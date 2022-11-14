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

        public AddressBookController(IAddressBookBL addressBook)
        {
            this.addressBook = addressBook;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AddressBookModel bookModel)
        {
            try
            {
                var result = addressBook.Add(bookModel);

                if (result != null)
                    return Ok(new { success = true, message = "Contact Has Been Added", data = result });
                else
                    return BadRequest(new { success = false, message = "Something went wrong" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
