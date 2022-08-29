namespace Jwt.Api.Domain.Uow
{
    public interface IUow
    {
        Task ComplateAsync();
    }
}
