using PhoneBookAssessment.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAssessment.WebApi.Models.PhoneBook

{
    public class GetPhoneBookResponse
    {
         public IEnumerable<PhoneBookViewModel> PhoneBooks { get; }

        public GetPhoneBookResponse(IEnumerable<PhoneBookViewModel> phoneBooks)
        {
            PhoneBooks = phoneBooks;
        }
    }
}
