using ContosoMessage.Models;

namespace ContosoMessage.Services;

public static class MessageService
{
    static List<Message> Messages { get; }
    static int nextId = 3;
    static MessageService()
    {
        Messages = new List<Message>
        {
            new Message { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Message { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Message> GetAll() => Messages;

    public static Message? Get(int id) => Messages.FirstOrDefault(p => p.Id == id);

    public static void Add(Message message)
    {
        message.Id = nextId++;
        Messages.Add(message);
    }

    public static void Delete(int id)
    {
        var message = Get(id);
        if(message is null)
            return;

        Messages.Remove(message);
    }

    public static void Update(Message message)
    {
        var index = Messages.FindIndex(p => p.Id == message.Id);
        if(index == -1)
            return;

        Messages[index] = message;
    }

    internal static void Add(Controllers.Message message)
    {
        throw new NotImplementedException();
    }
}