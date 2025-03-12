using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using ModelLayer.Model;
using Microsoft.EntityFrameworkCore;
namespace AddressBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressBookController : ControllerBase
{
    private readonly AddressBookContext _context;
    public AddressBookController(AddressBookContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
    {
        return await _context.Contacts.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactId(int id)
    {
        var result = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<Contact>> AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContactId), new { id = contact.Id }, contact);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, Contact contact)
    {
        var existingContact = await _context.Contacts.FindAsync(id);
        if (existingContact == null) 
        { 
            return NotFound(); 
        }
        if (id != contact.Id) 
        {
            return BadRequest(); 
        }
        _context.Entry(contact).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var result = await _context.Contacts.FindAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _context.Contacts.Remove(result);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}