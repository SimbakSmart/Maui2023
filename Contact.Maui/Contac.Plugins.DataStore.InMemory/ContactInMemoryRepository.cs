using Contact.UseCases.PluginInterfaces;

namespace Contac.Plugins.DataStore.InMemory
{
    using Contact = Contact.CoreBusiness.Contact;
    public class ContactInMemoryRepository : IContactRepository
    {

        public static List<Contact> _contact;

        public ContactInMemoryRepository()
        {
            _contact = new List<Contact>()
        {
              new Contact
            {
             ContactId = 1,
             Name="John Doe",
             Email="jondoe@gmail.co"
            },
            new Contact
            {
                ContactId = 2,
             Name="Jane Doe",
             Email="JaneDoe@gmail.co"
            },
            new Contact
            {
                ContactId = 3,
             Name="Tom Hanks",
             Email="tomhanks@gmail.co"
            },
            new Contact
            {
                ContactId = 4,
             Name="Frank Liu",
             Email="franliu@gmail.co"
            },
        };
        }
        public  Task<List<Contact>> GetContactsAsync(string filterText)
        {
            var contacts = _contact.Where(x => !string.IsNullOrWhiteSpace(x.Name)
           && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts == null || contacts.Count <= 0)
                _contact.Where(x => !string.IsNullOrWhiteSpace(x.Email)
                && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts);

            if (contacts == null || contacts.Count <= 0)
                _contact.Where(x => !string.IsNullOrWhiteSpace(x.Phone)
                && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts);

            if (contacts == null || contacts.Count <= 0)
                _contact.Where(x => !string.IsNullOrWhiteSpace(x.Address)
                && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts);


            return Task.FromResult(contacts);
        }
    }
}