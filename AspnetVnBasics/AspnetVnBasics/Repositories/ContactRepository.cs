using AspnetVnBasics.Data;
using AspnetVnBasics.Entities;
using AspnetVnBasics.Repositories.Interfaces;
using System.Threading.Tasks;

namespace AspnetVnBasics.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly DatabaseContext _dbContext;

        public ContactRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> SendMessage(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Subscribe(string address, string Phone, string Name, string Message)
        {
            // implement your business logic
            var newContact = new Contact
            {
                Email = address,
                Message = Message,
                Name = Name,
                Phone = Phone
            };

            _dbContext.Contacts.Add(newContact);

            await _dbContext.SaveChangesAsync();

            return newContact;
        }
    }
}
