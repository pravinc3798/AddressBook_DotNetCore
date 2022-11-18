namespace AddressBook.RabbitMQ
{
    public interface IMessage
    {
        public void SendMessage<AddressBookEntity>(AddressBookEntity entity);
    }
}
