namespace Contact.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        Task<CoreBusiness.Contact> ExecuteAsync(int contactId);
    }
}