namespace SingletStore.Api.Contracts
{
    public record SingletsResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price);
 
}
