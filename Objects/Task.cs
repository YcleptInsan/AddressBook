using System.Collections.Generic;

namespace AddressBook
{
  public class Task
  {
    private string _description;
    private string _address;
    private string _phoneNumber;
    private int _id;
    private bool _doesExist;
    private static List<Task> _instances = new List<Task> {};

    public Task(string newDescription, string newAddress, string newPhoneNumber)
    {
      _description = newDescription;
      _address = newAddress;
      _phoneNumber = newPhoneNumber;
      _id = _instances.Count;
      _instances.Add(this);
      _doesExist = true;
    }
    public string GetDescription()
    {
      return _description;
    }
    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
    public string GetPhonenumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Task> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Task Find(int searchId)
    {
      return _instances[searchId];
    }
    public void SetExistence(bool newExistence)
    {
      _doesExist = newExistence;
    }
    public bool GetExistence()
    {
      return _doesExist;
    }
  }
}
