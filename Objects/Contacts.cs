using System.Collections.Generic;

namespace Contact.Objects
{
  public class Contact
  {
    private string _contactName;
    private string _phoneNumber;
    private string _email;
    private string _address;
    private int _id;

    private List<Contacts> _instances = new List<Contacts>{};

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

    public List<Contact> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instance[searchId - 1];
    }
  }
}
