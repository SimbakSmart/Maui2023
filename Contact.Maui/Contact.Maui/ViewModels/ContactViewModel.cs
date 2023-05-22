using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact.Maui.Models;
using Contact.UseCases.Interfaces;
using System;

namespace Contact.Maui.ViewModels
{
    using Contact = Contact.CoreBusiness.Contact;
    public partial class ContactViewModel:ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase viewContactUseCase;

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel(IViewContactUseCase viewContactUseCase)
        {

            this.Contact =new Contact();
            this.viewContactUseCase = viewContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }
        //[RelayCommand]
        //public void SaveContact()
        //{
        //    ContactRepository.UpdateContact(this.Contact.ContactId,this.Contact);
        //}
    }
}
