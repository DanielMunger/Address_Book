using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["contact.cshtml", allContacts];
      };
      Get["/contact/new"] = _ => {
        return View["contact_new_form.cshtml"];
      };
      Get["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["contact.cshtml", contact];
      };
      Get["/contact/contact_search"] = _ => {
        return View["contact_search.cshtml"];
      };
      Post["/contact/contact_search_form"] = _ => {
        string searchContact = Request.Form["searched_contact"];
        List<Contact> allContacts = Contact.GetAll();
        List<int> returnedContacts = Contact.ContactExists(searchContact);
        if(returnedContacts.Count > 0)
        {
          List<Contact> foundContact = Contact.SearchContacts(searchContact);
          return View["contact_search_result.cshtml", foundContact];
        }
        else
        {
          return View["no_contacts.cshtml"];
        }
      };
        Get["/contact/clear"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        Contact.ClearAll();
        return View["index.cshtml", allContacts];
      };
      Get["/deletecontact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        Contact.DeleteContact(contact);
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Post["/contact"] = _ => {
        string newName = Request.Form["new_contact_name"];
        string newPhone = Request.Form["new_phone_number"];
        string newEmail = Request.Form["new_email"];
        string newAddress = Request.Form["new_address"];
        Contact newContact = new Contact(newName, newPhone, newEmail, newAddress);
        return View["contact.cshtml", newContact];
      };
    }
  }
}
