namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName, long id) : base($"{entityName} with Id: {id} not found")
    {
        EntityName = entityName;
        Id = id;
    }

    public long Id { get; }
    public string EntityName { get; }
}