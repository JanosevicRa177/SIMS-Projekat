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
      
      public String name
        {
            set;
            get;
        }
        public String surname
        {
            set;
            get;
        }
        public Address address
        {
            set;
            get;
        }
        public String password
        {
            set;
            get;
        }
        public String mobilePhone
        {
            set;
            get;
        }
        public String mail
        {
            set;
            get;
        }
        public int userID
        {
            set;
            get;
        }

    }
}