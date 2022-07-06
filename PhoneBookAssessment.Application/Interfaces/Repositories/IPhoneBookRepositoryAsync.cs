using PhoneBookAssessment.Application.Dtos;
using PhoneBookAssessment.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookAssessment.Application.Interfaces.Repositories
{
    public interface IPhoneBookRepositoryAsync
    {
        Task<Response<string>> CreatePhone(string name);
        Task<IEnumerable<PhoneBookViewModel>> GetPhoneBooks();
        Task<IEnumerable<PhoneBookViewModel>> SearchPhoneBookEntry(string name, int phoneBookId);
    }
}
