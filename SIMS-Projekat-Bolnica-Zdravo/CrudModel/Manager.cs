
using System;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class Manager : User
   {
        public Manager(string name, string surname, Address address, string password, string mobilePhone, string mail) : base(name, surname, address, password, mobilePhone, mail)
        {
            this.userID = User.generateID();
        }

        public ObservableCollection<Room> room
        {
            set;
            get;
        }

        public ObservableCollection<Room> Room
        {
            get
            {
                if (room == null)
                    room = new ObservableCollection<Room>();
                return room;
            }
            set
            {
                RemoveAllRoom();
                if (value != null)
                {
                    foreach (Room oRoom in value)
                        AddRoom(oRoom);
                }
            }
        }

        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (this.room == null)
                this.room = new ObservableCollection<Room>();
            if (!this.room.Contains(newRoom))
            {
                this.room.Add(newRoom);
            }
        }

        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (this.room != null)
                if (this.room.Contains(oldRoom))
                    this.room.Remove(oldRoom);
        }
        public void RemoveAllRoom()
        {
            if (room != null)
                room.Clear();
        }
    }
}