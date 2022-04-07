// File:    User.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:08:04 PM
// Purpose: Definition of Class User

using System;

namespace CrudModel
{
   public class User
   {


        public User(string name, string surname, Address address, string password, string mobilePhone, string mail)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.password = password;
            this.mobilePhone = mobilePhone;
            this.mail = mail;
        }


        public static int userIDS = -1;

        public static int generateID()
        {
            return ++userIDS;
        }

        public bool ChangePassword(String newPassword)
      {
         throw new NotImplementedException();
      }
      
      public bool InformationChange(String newName, String newSurname, Address newAddress, String newPassword)
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