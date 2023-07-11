using System.Runtime.InteropServices.ObjectiveC;

namespace backend.Models;

public class Dialog
{
    public List<Message> messages = new();

    public Guid DialogID { get; init; }
}