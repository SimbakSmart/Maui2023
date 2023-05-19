namespace Contact.UseCases.Interfaces
{
    public interface IViewContactsUseCase
    {
        Task<List<CoreBusiness.Contact>> ExecuteAsync(string filterText);
    }
}