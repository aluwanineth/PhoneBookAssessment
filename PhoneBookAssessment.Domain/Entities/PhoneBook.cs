using PhoneBookAssessment.Domain.Commons;
using System.Collections.Generic;

namespace PhoneBookAssessment.Domain.Entities

{
    public class PhoneBook : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Entry> Entries { get; set; }
        internal PhoneBook() { }
        internal PhoneBook(string name)
        {
            Name = name;
        }
    }
}
