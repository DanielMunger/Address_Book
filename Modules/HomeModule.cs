using Nancy;
using System.Collections.Generic;
using Contact.Objects;

namespace AddressBookS //replace with your desired namespace
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        View["index.cshtml", allContacts];
      };

      Get["contact/new"] = _ => View["/contact_new_form.cshtml"];

      Post["/contact"] = _ => {
        string newName = Request.Form["new_contact_name"];
        string newPhoneNumber = Request.Form["new_phone_number"];
        string newEmail = Request.Form["new_email"];
        string newAddress = Request.Form["new_address"];
        Contact newContact = new Contact(newName, newPhoneNumber, newEmail, newAddress);

        return View["new_contact.cshtml"];
      }
    }
  }
}
