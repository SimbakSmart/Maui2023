using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Contact.Maui;
using CommunityToolkit.Maui;
using Contac.Plugins.DataStore.InMemory;
using Contact.Maui.Views;
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

        builder.Services.AddSingleton<ContactPage>();
        builder.Services.AddSingleton<EditContactPage>();
        return builder.Build();
    }
}