using Contact.UseCases.Interfaces;
using Contact.UseCases.PluginInterfaces;

namespace Contact.UseCases
{
    using Contact = Contact.CoreBusiness.Contact;
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public ViewContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<Contact> ExecuteAsync(int contactId)
        {
            return await this.contactRepository.GetContactByIdAsync(contactId);
        }
    }
}
