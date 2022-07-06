using PhoneBookAssessment.Application.Interfaces.Repositories;
using PhoneBookAssessment.Application.Wrappers;
using PhoneBookAssessment.Domain.Entities;
using PhoneBookAssessment.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace PhoneBookAssessment.Infrastructure.Repositories
{
    public class EntryRepositoryAsync : GenericRepositoryAsync<Entry>, IEntryRepositoryAsync
    {

        public EntryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext) { }
        public async Task<Response<string>> CreateEntry(string name, string phoneNumber, int phoneBookId)
        {
            var entry = new Entry(name, phoneNumber, phoneBookId);
            await AddAsync(entry);
            return new Response<string>(entry.Id.ToString(),string.Format("Phone entry created successfully Id: {0}", entry.Id));
        }
    }
}
