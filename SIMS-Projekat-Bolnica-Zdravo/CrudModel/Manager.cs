// File:    Manager.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:06 PM
// Purpose: Definition of Class Manager

using System;

namespace CrudModel
{
   public class Manager : User
   {
        public String position
        {
            get;
            set;
        }
        public Manager(int id,String name, String surname, String email, String password, Address address,String phone,String position)
        {
            this.name = name;
            this.surname = surname;
            this.mail = email;
            this.password = password;
            this.address = address;
            this.mobilePhone = phone;
            this.position = position;

        }
   }
}