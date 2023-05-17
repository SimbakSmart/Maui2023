namespace Contact.Maui.Models
{
    public class ContactRepository
    {
        public static List<Contact> _contact = new List<Contact>()
        {
              new Contact
            {
             ContactId = 1,
             Name="John Doe",
             Email="jondoe@gmail.co"
            },
            new Contact
            {
                ContactId = 2,
             Name="Jane Doe",
             Email="JaneDoe@gmail.co"
            },
            new Contact
            {
                ContactId = 3,
             Name="Tom Hanks",
             Email="tomhanks@gmail.co"
            },
            new Contact
            {
                ContactId = 4,
             Name="Frank Liu",
             Email="franliu@gmail.co"
            },
        };
        
        public static List<Contact>  GetContacts() => _contact;

        public static Contact GetContactById(int id)
        {
          var contact = _contact.FirstOrDefault(x => x.ContactId == id);
            
            if (contact != null)
            {
                return new Contact
                {
                    ContactId= contact.ContactId,
                    Name= contact.Name,
                    Email= contact.Email,
                    Address= contact.Address,
                    Phone= contact.Phone,
                    
                };
            }
            return null;
        }  
        
        public static void UpdateContact(int  contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;
            

            var contactToUpdate = _contact.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
               
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address=contact.Address;
            }
        }
        
    }
}
