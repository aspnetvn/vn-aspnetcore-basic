using AspnetVnBasics.Entities;
using System.Threading.Tasks;

namespace AspnetVnBasics.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address, string Phone, string Name, string Message);
    }
}
