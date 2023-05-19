namespace Contact.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        Task<List<CoreBusiness.Contact>> ExecuteAsync(string filterText);
    }
}