using Contact.Maui.ViewModels;

namespace Contact.Maui.Views;

public partial class TestPage : ContentPage
{
	private ContactViewModel viewModel;
	public TestPage()
	{
		InitializeComponent();
		viewModel = new ContactViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		this.viewModel.LoadContact(1);
    }
}