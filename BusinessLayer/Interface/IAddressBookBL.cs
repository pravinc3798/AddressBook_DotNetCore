using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        public AddressBookEntity Add(AddressBookModel bookModel);
        public IEnumerable<AddressBookEntity> ViewAll();
    }
}
