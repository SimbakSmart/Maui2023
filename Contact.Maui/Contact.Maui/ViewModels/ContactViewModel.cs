﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact.Maui.Models;
using Contact.Maui.Views_MVM;
using Contact.UseCases.Interfaces;
using System;

namespace Contact.Maui.ViewModels
{
    using Contact = Contact.CoreBusiness.Contact;
    public partial class ContactViewModel:ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase viewContactUseCase;
        private readonly IEditContactUseCase editContactUseCase;
        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        private bool isContactValid;

        public bool IsContactValid
        {
            get { return isContactValid; }
            set
            {
                if (value == false)
                {
                    isContactValid = value;
                }
            }
        }

        public ContactViewModel(IViewContactUseCase viewContactUseCase,
            IEditContactUseCase editContactUseCase)
        {

            this.Contact =new Contact();
            this.viewContactUseCase = viewContactUseCase;
            this.editContactUseCase = editContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }


        [RelayCommand]
        public async Task EditContact()
        {
            await this.editContactUseCase.ExecuteAsync(this.contact.ContactId, this.contact);
            await Shell.Current.GoToAsync($"{nameof(Contacts_MVVM_Page)}");
        }

        [RelayCommand]
        public async Task BackToContacts()
        {
            await Shell.Current.GoToAsync($"{nameof(Contacts_MVVM_Page)}");
        }
    }
}
