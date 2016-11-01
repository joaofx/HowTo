namespace HowShop.Core.Concerns
{
    public interface IAuthorization<T>
    {
        Feature Feature { get; }
    }
}