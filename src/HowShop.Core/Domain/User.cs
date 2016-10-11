using System;
using SolidR.Domain;

namespace HowShop.Core.Domain
{
    public class User : Entity, ISoftDeletable
    {
        public string Name { get; private set; }
        public virtual int YearOfBirth { get; private set; }
        public bool IsDeleted { get; set; }

        private User()
        {
        }

        public User(string name, int actualAge)
        {
            Name = name;
            YearOfBirth = DateTime.Now.AddYears(-actualAge).Year;
        }
    }
}