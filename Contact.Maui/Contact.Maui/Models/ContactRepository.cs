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

        public static Contact GetContactById(int id) => _contact.FirstOrDefault(x=>x.ContactId == id);     
        
    }
}
