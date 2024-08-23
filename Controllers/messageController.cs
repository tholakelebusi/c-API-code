using ContosoMessage.Models;
using ContosoMessage.Services;
using Microsoft.AspNetCore.Mvc;


namespace ContosoMessage.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    public MessageController()
    {
    }


    [HttpGet]
    public ActionResult<List<Message>> GetAll()
    {
        return MessageService.GetAll();
    }

    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Message> Get(int id)
    {
        var message = MessageService.Get(id);

        if(message == null)
            return NotFound();

        return message;
    }

    // POST action

    [HttpPost]
    public IActionResult Create(Message message)
    {            
        // This code will save the pizza and return a result
        MessageService.Add(message);
        return CreatedAtAction(nameof(Get), new { id = message.Id }, message);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Message message)
    {
        if (id != message.Id)
            return BadRequest();
            
        var existingPizza = MessageService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        MessageService.Update(message);           
    
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var message = MessageService.Get(id);
   
    if (message is null)
        return NotFound();
       
    MessageService.Delete(id);
   
    return NoContent();
    }
}

public class Message
{
}