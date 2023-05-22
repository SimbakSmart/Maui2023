using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact.Maui.Models;
using System;

namespace Contact.Maui.ViewModels
{
    using Contac = Contact.Maui.Models.Contact;
    public partial class ContactViewModel:ObservableObject
    {
        private Contac contact;
        public Contac Contact
        {
            get=>contact;
            set 
            { 
             SetProperty(ref contact, value);
            }
        }

        public ContactViewModel()
        {

            this.Contact =new Contac();
        }

        public void LoadContact(int contactId)
        {
            this.Contact = ContactRepository.GetContactById(contactId);
        }

       [RelayCommand]
        public void SaveContact()
        {
            ContactRepository.UpdateContact(this.Contact.ContactId,this.Contact);
        }
    }
}
