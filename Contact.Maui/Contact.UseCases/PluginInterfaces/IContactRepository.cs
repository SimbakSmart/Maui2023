

namespace Contact.UseCases.PluginInterfaces
{
    using Contact = Contact.CoreBusiness.Contact;
    public interface IContactRepository
    {
       Task<Contact> GetContactByIdAsync(int contactId);
        Task<List<Contact>> GetContactsAsync(string filterText);
        Task UpdateContactAsync(int contactId, Contact contact);
    }
}
