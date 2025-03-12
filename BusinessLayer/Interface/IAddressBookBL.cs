using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;
namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        Task<IEnumerable<ContactDTO>> GetAllContacts();
        Task<ContactDTO?> GetContactById(int id);
        Task<ContactDTO> AddContact(CreateContactDTO contactDto);
        Task<bool> UpdateContact(int id, UpdateContactDTO contactDto);
        Task<bool> DeleteContact(int id);
    }
}
