using Contact.Maui.ViewModels;

namespace Contact.Maui.Views_MVM;

public partial class Contacts_MVVM_Page : ContentPage
{
    private readonly ContactsViewModels contactsViewModels;

    public Contacts_MVVM_Page(ContactsViewModels contactsViewModels)
	{
		InitializeComponent();
        this.contactsViewModels = contactsViewModels;
        this.BindingContext = this.contactsViewModels;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await this.contactsViewModels.LoadContactAsync();
    }
}