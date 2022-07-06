using PhoneBookAssessment.Domain.Entities;
using System.Collections.Generic;

namespace PhoneBookAssessment.Application.Dtos
{
    public class PhoneBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
