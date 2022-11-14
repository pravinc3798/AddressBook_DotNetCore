using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        private readonly IAddressBookRL addressBook;

        public AddressBookBL(IAddressBookRL addressBook)
        {
            this.addressBook = addressBook;
        }

        public AddressBookEntity Add(AddressBookModel bookModel)
        {
            try
            {
                return addressBook.Add(bookModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
