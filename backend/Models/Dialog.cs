using System.Runtime.InteropServices.ObjectiveC;

namespace backend.Models;

public class Dialog
{
    public List<Message> messages { get; init; }

    public Guid DialogID = Guid.NewGuid();


}