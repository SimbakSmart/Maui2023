using Contact.Maui.Models;
using Contact.UseCases.Interfaces;

namespace Contact.Maui.Views;

public partial class AddContactPage : ContentPage
{
    private readonly IAddContactUseCase addContactUseCase;

    public AddContactPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        this.addContactUseCase = addContactUseCase;
    }

    

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {

      await  this.addContactUseCase.ExecuteAsync(new CoreBusiness.Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Address = contactCtrl.Address,
            Phone = contactCtrl.Phone,
        });

      await  Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }

    private void btnCanelContact_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("..");
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }


}