namespace HowShop.Core.Domain
{
    public interface IIntegratableByName
    {
        string IntegrationName { get; set; }

        string Name { get; set; }
    }
}