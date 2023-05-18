

namespace Contact.UseCases.PluginInterfaces
{
    using Contact = Contact.CoreBusiness.Contact;
    public interface IContactRepository
    {
       Task<List<Contact>> GetContactsAsync(string filterText);
    }
}
