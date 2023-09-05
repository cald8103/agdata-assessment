using ContactApi.Models;
using ContactApi.Raven;

namespace ContactApi.Services;

public class ContactCardService : IContactCardService
{
    public ContactCardService()
    {
    }

    public IEnumerable<ContactCard> GetAllContactCards()
    {
        using (var session = DocumentStoreHolder.Store.OpenSession())
        {
            return session.Query<ContactCard>().ToList();
        }
    }

    public ContactCard GetContactCard(string id)
    {
        using (var session = DocumentStoreHolder.Store.OpenSession())
        {
            return session.Load<ContactCard>(id);
        }
    }

    public bool AddContactCard(ContactCard contactCard)
    {
        using (var session = DocumentStoreHolder.Store.OpenSession())
        {
            if (!session.Query<ContactCard>().ToList().Any(x => x.Name == contactCard.Name))
            {
                session.Store(contactCard);
                session.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool UpdateContactCard(string id, ContactCard contactCard)
    {
        using (var session = DocumentStoreHolder.Store.OpenSession())
        {
            if (!session.Query<ContactCard>().ToList().Any(x => x.Name == contactCard.Name && x.Id != id))
            {
                ContactCard actualContactCard = session.Load<ContactCard>(id);
                actualContactCard.Name = contactCard.Name;
                actualContactCard.Address = contactCard.Address;
                session.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void DeleteContactCard(string id)
    {
        using (var session = DocumentStoreHolder.Store.OpenSession())
        {
            ContactCard contactCard = session.Load<ContactCard>(id);
            session.Delete(contactCard);
            session.SaveChanges();
        }
    }
}

public interface IContactCardService
{
    IEnumerable<ContactCard> GetAllContactCards();
    ContactCard GetContactCard(string id);
    bool AddContactCard(ContactCard contactCard);
    bool UpdateContactCard(string id, ContactCard contactCard);
    void DeleteContactCard(string id);
}