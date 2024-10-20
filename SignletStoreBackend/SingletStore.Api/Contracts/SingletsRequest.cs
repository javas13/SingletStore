namespace SingletStore.Api.Contracts
{
    public record SingletsRequest(
        string Title,
        string Description,
        decimal Price);

}

