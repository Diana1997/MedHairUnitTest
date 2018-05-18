using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreateContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return contact.ContactID;
        }
        public void EditContact(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }
        public Contact GetContact(int id)
        {
            return db.Contacts.AsNoTracking().FirstOrDefault(x => x.ContactID == id);
        }
        public IList<Contact> GetContact()
        {
            return db.Contacts.AsNoTracking().ToList();
        }
    }
}
