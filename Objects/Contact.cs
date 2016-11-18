using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _contactName;
    private string _phoneNumber;
    private string _email;
    private string _address;
    private int _id;

    private static List<Contact> _instances = new List<Contact>{};

    public Contact(string ContactName, string PhoneNumber, string Email, string Address)
    {
      _contactName = ContactName;
      _phoneNumber = PhoneNumber;
      _email = Email;
      _address = Address;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public void SetContactName(string ContactName)
    {
      _contactName = ContactName;
    }
    public string GetContactName()
    {
      return _contactName;
    }

    public void SetPhoneNumber(string PhoneNumber)
    {
      _phoneNumber = PhoneNumber;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public void SetEmail(string Email)
    {
      _email = Email;
    }
    public string GetEmail()
    {
      return _email;
    }

    public void SetAddress(string Address)
    {
      _address = Address;
    }
    public string GetAddress()
    {
      return _address;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<int> ContactExists(string SearchContact)
    {
      List<int> result = new List<int>{};
      foreach(Contact contact in _instances)
      {
        if(contact.GetContactName().Contains(SearchContact))
        {
          result.Add(contact._id);
        }
      }
      return result;
    }
    public static List<Contact> SearchContacts(string SearchContact)
    {
      SearchContact = SearchContact.ToLower();
      
      List<Contact> foundContact = new List<Contact>{};
      foreach(Contact contact in _instances)
      {
        string contactName = contact.GetContactName();
        contactName = contactName.ToLower();
        if(contactName.Contains(SearchContact))
        {
          foundContact.Add(contact);
        }
      }
      return foundContact;
    }
    public static void DeleteContact(Contact contact)
    {
      _instances.Remove(contact);
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
