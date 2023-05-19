
namespace Contact.Maui.Views;

using Contact.Maui.Models;
using Contact.UseCases;
using Contact.UseCases.Interfaces;
using Contact = Contact.Maui.Models.Contact;
[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
    private CoreBusiness.Contact contact;
    //private Contact contact;
    private readonly IViewContactUseCase viewContactUseCase;
    private readonly IEditContactUseCase editContactUseCase;

    public EditContactPage(IViewContactUseCase viewContactUseCase, IEditContactUseCase editContactUseCase )
	{
		InitializeComponent();
        this.viewContactUseCase = viewContactUseCase;
        this.editContactUseCase = editContactUseCase;
    }

  
    public string ContactId 
    {

        set 
        {  
           // contact = ContactRepository.GetContactById(int.Parse(value));
            contact = this.viewContactUseCase.ExecuteAsync(int.Parse(value)).GetAwaiter().GetResult();
            if(contact != null)
            {
                contactCtrl.Name= contact.Name;
                contactCtrl.Address = contact.Address;
                contactCtrl.Email = contact.Email;
                contactCtrl.Phone = contact.Phone;
            }
        }
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {


        contact.Name = contactCtrl.Name;
        contact.Address = contactCtrl.Address;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;


        // ContactRepository.UpdateContact(contact.ContactId, contact);
        await this.editContactUseCase.ExecuteAsync(contact.ContactId, contact);
        //await Shell.Current.GoToAsync("..");
       await Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


   
}