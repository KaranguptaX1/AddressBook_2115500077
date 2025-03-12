using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using ModelLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BusinessLayer.Interface;
using ModelLayer.DTO;
namespace AddressBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressBookController : ControllerBase
{
    //private readonly AddressBookContext _context;
    private readonly IAddressBookBL _addressBookBL;
    public AddressBookController(IAddressBookBL addressBookBL)
    {
        _addressBookBL = addressBookBL;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDTO>>> GetContacts()
    {
        return Ok(await _addressBookBL.GetAllContacts());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDTO>> GetContactId(int id)
    {
        var contact = await _addressBookBL.GetContactById(id);
        return contact == null ? NotFound() : Ok(contact);
    }
    [HttpPost]
    public async Task<ActionResult<ContactDTO>> AddContact(CreateContactDTO dto)
    {
        var createdContact = await _addressBookBL.AddContact(dto);
        return CreatedAtAction(nameof(GetContactId), new { id = createdContact.Id }, createdContact);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, UpdateContactDTO dto)
    {
        return await _addressBookBL.UpdateContact(id, dto) ? NoContent() : NotFound();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        return await _addressBookBL.DeleteContact(id) ? NoContent() : NotFound();
    }
}