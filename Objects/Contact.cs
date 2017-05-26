using System.Collections.Generic;

namespace AddressBook
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<Task> _tasks;

    public Contact (string contactName)
    {
      _name = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _tasks = new List<Task>{};
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public List<Task> GetTasks()
    {
      return _tasks;
    }
    public void AddTask(Task task)
    {
      _tasks.Add(task);
    }
    public void DeleteTask(int idToDelete)
    {
      Task.Find(idToDelete).SetExistence(false);
    }
  }
}
