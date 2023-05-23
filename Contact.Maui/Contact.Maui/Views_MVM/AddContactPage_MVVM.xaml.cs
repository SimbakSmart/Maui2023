using Contact.Maui.ViewModels;

namespace Contact.Maui.Views_MVM;

public partial class AddContactPage_MVVM : ContentPage
{
    private readonly ContactViewModel contactViewModel;

    public AddContactPage_MVVM(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        this.contactViewModel = contactViewModel;
        this.BindingContext = this.contactViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.contactViewModel.Contact = new CoreBusiness.Contact();
    }
}