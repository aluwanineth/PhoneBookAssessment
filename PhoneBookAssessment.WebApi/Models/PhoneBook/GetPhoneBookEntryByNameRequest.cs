using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAssessment.WebApi.Models.PhoneBook
{
    public class GetPhoneBookEntryByNameRequest
    {
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
    }
}
