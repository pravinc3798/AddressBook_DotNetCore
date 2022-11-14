using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AddressBookRL : IAddressBookRL
    {
        private readonly AddressBookContext bookContext;

        public AddressBookRL(AddressBookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public AddressBookEntity Add(AddressBookModel bookModel)
        {
            try
            {
                AddressBookEntity addressBook = new AddressBookEntity()
                {
                    FullName = bookModel.FullName,
                    ContactNumber = bookModel.ContactNumber,
                    Email = bookModel.Email,
                    City = bookModel.City,
                    State = bookModel.State,
                    ZipCode = bookModel.ZipCode,
                    CreatedDate = DateTime.Now
                };

                bookContext.Add(addressBook);
                int result = bookContext.SaveChanges();
                
                if (result != 0)
                    return addressBook;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
