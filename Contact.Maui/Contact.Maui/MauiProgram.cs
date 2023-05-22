using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Contact.Maui;
using CommunityToolkit.Maui;
using Contac.Plugins.DataStore.InMemory;
using Contact.Maui.ViewModels;
using Contact.Maui.Views;
using Contact.Maui.Views_MVM;
using Contact.UseCases;
using Contact.UseCases.Interfaces;
using Contact.UseCases.PluginInterfaces;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
        builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
        builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
        builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
        builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
        builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();
        builder.Services.AddSingleton<ContactsViewModels>();
        builder.Services.AddSingleton<ContactViewModel>();

        builder.Services.AddSingleton<ContactPage>();
        builder.Services.AddSingleton<EditContactPage>();
        builder.Services.AddSingleton<AddContactPage>();
        builder.Services.AddSingleton<Contacts_MVVM_Page>();
        builder.Services.AddSingleton<EditContactPage_MVVM>();
        return builder.Build();
    }
}