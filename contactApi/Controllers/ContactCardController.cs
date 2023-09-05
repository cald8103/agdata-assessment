using ContactApi.Models;
using ContactApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactCardController : ControllerBase
{
    private IContactCardService _contactCardService;

    public ContactCardController(IContactCardService contactCard)
    {
        _contactCardService = contactCard;
    }

    [HttpGet]
    public IEnumerable<ContactCard> Get()
    {
        return _contactCardService.GetAllContactCards();
    }

    [HttpGet("{id}")]
    public ContactCard Get(string id)
    {
        return _contactCardService.GetContactCard(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ContactCard contactCard)
    {
        if (string.IsNullOrEmpty(contactCard.Name) || string.IsNullOrEmpty(contactCard.Address))
        {
            return StatusCode(400, "Missing required fields in request body. Please review request and try again.");
        }

        if (_contactCardService.AddContactCard(contactCard)) return Ok();
        else return StatusCode(409, "Conflict: Contact name duplicated");
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] ContactCard contactCard)
    {
        if (string.IsNullOrEmpty(contactCard.Name) || string.IsNullOrEmpty(contactCard.Address))
        {
            return StatusCode(400, "Missing required fields in request body. Please review request and try again.");
        }

        if (_contactCardService.UpdateContactCard(id, contactCard)) return Ok();
        else return StatusCode(409, "Conflict: Contact name duplicated");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _contactCardService.DeleteContactCard(id);
        return Ok();
    }
}