using PhoneBookAssessment.Domain.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookAssessment.Domain.Entities

{
    public class PhoneBook : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public ICollection<Entry> Entries { get; set; }
        internal PhoneBook() { }
        internal PhoneBook(string name)
        {
            Name = name;
        }
    }
}
