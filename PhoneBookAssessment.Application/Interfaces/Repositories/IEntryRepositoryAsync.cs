using PhoneBookAssessment.Application.Wrappers;
using System.Threading.Tasks;

namespace PhoneBookAssessment.Application.Interfaces.Repositories
{
    public interface IEntryRepositoryAsync
    {
        Task<Response<string>> CreateEntry(string name, string phoneNumber, int phoneBookId);

    }
}
