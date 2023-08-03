namespace TestApp.Models.Exception.Abstracts;

public abstract class NotFoundException : System.Exception
{
    protected NotFoundException(string message) : base(message) { }
}