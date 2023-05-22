

using Contact.UseCases.Interfaces;
using System.Collections.ObjectModel;

namespace Contact.Maui.ViewModels
{
    using Contact = Contact.CoreBusiness.Contact;
    public class ContactsViewModels
    {
        private readonly IViewContactsUseCase viewContactsUseCase;

        public ObservableCollection<Contact> Contacts {get;set;}

        public ContactsViewModels(IViewContactsUseCase viewContactsUseCase)
        {
            this.viewContactsUseCase = viewContactsUseCase;
            this.Contacts = new ObservableCollection<Contact>();
        }

        public async Task LoadContactAsync()
        {
           this.Contacts.Clear();
            var contacts = await viewContactsUseCase.ExecuteAsync(null);

            if(contacts != null && contacts.Count >0)
            {
                foreach(var contact in contacts)
                {
                    this.Contacts.Add(contact);
                }
            }

        }
    }
}
