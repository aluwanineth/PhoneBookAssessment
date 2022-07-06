using PhoneBookAssessment.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookAssessment.Domain.Entities

{
    public class Entry : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int PhoneBookId { get; set; }
        public PhoneBook PhoneBook { get; set; }

        internal Entry() { }
        internal Entry(string name, string phoneNumber, int phoneBookId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            PhoneBookId = phoneBookId;
        }
    }
}

