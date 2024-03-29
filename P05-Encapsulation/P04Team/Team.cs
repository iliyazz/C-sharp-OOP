﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get 
            {
                return this.firstTeam.AsReadOnly(); 
            }
        }
        public IReadOnlyCollection<Person> ReserveTeam 
        {
            get 
            {
                return this.reserveTeam.AsReadOnly();
            } 
        }
        //public string Name { get => name; set => name = value; }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
