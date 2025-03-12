using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTO;
using ModelLayer.Model;
using RepositoryLayer.Context;

namespace BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        private readonly AddressBookContext _context;
        private readonly IMapper _mapper;
        public AddressBookBL(AddressBookContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ContactDTO>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(contacts);
        }
        public async Task<ContactDTO?> GetContactById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            return contact == null ? null : _mapper.Map<ContactDTO>(contact);
        }
        public async Task<ContactDTO> AddContact(CreateContactDTO contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContactDTO>(contact);
        }

        public async Task<bool> UpdateContact(int id, UpdateContactDTO contactDto)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return false;

            _mapper.Map(contactDto, contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
