namespace Contact.UseCases.Interfaces
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(int contactId, CoreBusiness.Contact contact);
    }
}