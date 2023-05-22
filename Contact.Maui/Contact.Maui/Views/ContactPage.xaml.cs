


namespace Contact.Maui.Views;

using CommunityToolkit.Maui.Converters;
using Contact.Maui.Models;
using Contact.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Contact = Contact.CoreBusiness.Contact;
public partial class ContactPage : ContentPage
{
    private readonly IViewContactsUseCase viewContactUseCase;
    private readonly IDeleteContactUseCase deleteContactUseCase;

    public ContactPage(IViewContactsUseCase viewContactUseCase, IDeleteContactUseCase deleteContactUseCase)
    {
        InitializeComponent();
        this.viewContactUseCase = viewContactUseCase;
        this.deleteContactUseCase = deleteContactUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        contactSearch.Text = string.Empty;
        LoadContacts();


    }



    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       if(listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((CoreBusiness.Contact)listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact =  menuItem.CommandParameter as Contact;
        // ContactRepository.DeleteContact(contact.ContactId);
       await deleteContactUseCase.ExecuteAsync(contact.ContactId);
        LoadContacts();


    }
    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(await this.viewContactUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void contactSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
   
        var contacts = new ObservableCollection<Contact>(await this.viewContactUseCase.ExecuteAsync(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    private void btnTest_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(TestPage));
    }
}
