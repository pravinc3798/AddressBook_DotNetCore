using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressBookRL
    {
        public AddressBookEntity Add(AddressBookModel bookModel);
    }
}
