


namespace Contact.Maui.Views;

using CommunityToolkit.Maui.Converters;
using Contact.Maui.Models;
using Contact.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Contact = Contact.Maui.Models.Contact;
public partial class ContactPage : ContentPage
{
    private readonly IViewContactsUseCase viewContactUseCase;

    public ContactPage(IViewContactsUseCase viewContactUseCase)
    {
        InitializeComponent();
        this.viewContactUseCase = viewContactUseCase;
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

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact =  menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();


    }
    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<CoreBusiness.Contact>(await this.viewContactUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void contactSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        // var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        var contacts = new ObservableCollection<CoreBusiness.Contact>(await this.viewContactUseCase.ExecuteAsync(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}
