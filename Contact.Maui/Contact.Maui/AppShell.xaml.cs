using Contact.Maui.Views;
using Contact.Maui.Views_MVM;

namespace Contact.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ContactPage),typeof(ContactPage));
        Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
        Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
        Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
        Routing.RegisterRoute(nameof(Contacts_MVVM_Page),typeof(Contacts_MVVM_Page));
        Routing.RegisterRoute(nameof(EditContactPage_MVVM), typeof(EditContactPage_MVVM));
        Routing.RegisterRoute(nameof(AddContactPage_MVVM), typeof(AddContactPage_MVVM));
    }
}
