using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact.Maui.Models;
using System;

namespace Contact.Maui.ViewModels
{
    using Contac = Contact.Maui.Models.Contact;
    public partial class ContactViewModel:ObservableObject
    {
        public Contac Contact { get; set; }

        public ContactViewModel()
        {

            this.Contact = ContactRepository.GetContactById(1);
        }

       [RelayCommand]
        public void SaveContact()
        {
            ContactRepository.UpdateContact(this.Contact.ContactId,this.Contact);
        }
    }
}
