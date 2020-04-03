using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class ContactRepo : IContactRepo
    {
        GuildCarsEntities context;

        public ContactRepo()
        {
            context = new GuildCarsEntities();
        }

        public void CreateContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}
