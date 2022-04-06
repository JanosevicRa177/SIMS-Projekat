using System;

namespace CrudModel
{
   public class User
   {
      public bool ChangePassword(String newPassword)
      {
         throw new NotImplementedException();
      }
      
      public bool InformationChange(String newName, String newSurname, String newAddress, String newPassword)
      {
         throw new NotImplementedException();
      }
      
      public String name;
      public String surname;
      public Address address;
      public String password;
      public String mobilePhone;
      public String mail;
      public int userID;
   
   }
}