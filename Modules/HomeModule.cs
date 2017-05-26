using Nancy;
using AddressBook;
using System.Collections.Generic;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/contacts"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/contacts"] = _ => {
        Contact newContact = new Contact(Request.Form["contact-name"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contacts/{id}"]= parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Task> contactTasks = selectedContact.GetTasks();
        model.Add("contact", selectedContact);
        model.Add("tasks", contactTasks);
        return View["contact.cshtml", model];
      };
      Get["/contacts/{id}/tasks/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Task> allTasks = selectedContact.GetTasks();
        model.Add("contact", selectedContact);
        model.Add("tasks", allTasks);
        return View["contact_tasks_form.cshtml", model];
      };
      Post["/tasks"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
        List<Task> contactTasks = selectedContact.GetTasks();
        string taskDescription = Request.Form["task-description"];
        string address = Request.Form["Address"];
        string phoneNumber = Request.Form["Phone-Number"];
        Task newTask = new Task(taskDescription, address, phoneNumber);
        contactTasks.Add(newTask);
        model.Add("tasks", contactTasks);
        model.Add("contact", selectedContact);
        return View["contact.cshtml", model];
      };
      Post["/tasks/update"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
        int toDelete = Request.Form["task-id"];
        selectedContact.DeleteTask(toDelete);
        List<Task> contactTasks = selectedContact.GetTasks();
        model.Add("tasks", contactTasks);
        model.Add("contact", selectedContact);
        return View["contact.cshtml", model];
      };
    }
  }
}
