// File:    Address.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:51:51 PM
// Purpose: Definition of Class Address

using System;

namespace CrudModel
{
   public class Address { 
      public Address(String country,String city,String address,String number)
        {
            this.country = country;
            this.city = city;
            this.street = address;
            this.number = number;
        }
      public String country
    {
        set;
        get;
    }

      public String city
        {
            set;
            get;
        }
        public String street
        {
            set;
            get;
        }
        public String number
        {
            set;
            get;
        }

    }
}