

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact.Maui.Views_MVM;
using Contact.UseCases.Interfaces;
using System.Collections.ObjectModel;

namespace Contact.Maui.ViewModels
{
    using Contact = Contact.CoreBusiness.Contact;
    public partial class ContactsViewModels: ObservableObject
    {
        private readonly IViewContactsUseCase viewContactsUseCase;
        private readonly IDeleteContactUseCase deleteContactUseCase;

        public ObservableCollection<Contact> Contacts {get;set;}

        public ContactsViewModels(IViewContactsUseCase viewContactsUseCase,
             IDeleteContactUseCase deleteContactUseCase)
        {
            this.viewContactsUseCase = viewContactsUseCase;
            this.deleteContactUseCase = deleteContactUseCase;
            this.Contacts = new ObservableCollection<Contact>();
           

        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                LoadContactAsync(filterText);
            }
        }

        public async Task LoadContactAsync(string filterText = null)
        {
           this.Contacts.Clear();
            var contacts = await viewContactsUseCase.ExecuteAsync(filterText);

            if(contacts != null && contacts.Count >0)
            {
                foreach(var contact in contacts)
                {
                    this.Contacts.Add(contact);
                }
            }

        }

        [RelayCommand]
        public async Task DeleteContact(int contactId)
        {
            await deleteContactUseCase.ExecuteAsync(contactId);
            await LoadContactAsync();
        }

        [RelayCommand]
        public async Task GotoEditContact(int contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_MVVM)}?Id={contactId}");
        }

        [RelayCommand]
        public async Task GotoAddContact()
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage_MVVM));
        }
    }
}
