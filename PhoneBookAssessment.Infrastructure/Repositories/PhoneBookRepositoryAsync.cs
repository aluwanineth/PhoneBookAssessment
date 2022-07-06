using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.Application.Dtos;
using PhoneBookAssessment.Application.Interfaces.Repositories;
using PhoneBookAssessment.Application.Wrappers;
using PhoneBookAssessment.Domain.Entities;
using PhoneBookAssessment.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAssessment.Infrastructure.Repositories
{
    public class PhoneBookRepositoryAsync : GenericRepositoryAsync<PhoneBook>, IPhoneBookRepositoryAsync
    {
        public PhoneBookRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext) {}

        public async Task<Response<string>> CreatePhone(string name)
        {
            var _phoneBook = new PhoneBook(name);
            await AddAsync(_phoneBook);
            return new Response<string>(_phoneBook.Id.ToString(),string.Format("Phone book created successfully Id: {0}",_phoneBook.Id));
        }

        public async Task<IEnumerable<PhoneBookViewModel>> GetPhoneBooks()
        {
            var phoneBooks = from p in _dbContext.PhoneBooks
                             select new PhoneBookViewModel
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Entries = p.Entries.ToList()
                             };
            return await phoneBooks.ToListAsync();
        }

        public async Task<IEnumerable<PhoneBookViewModel>> SearchPhoneBookEntry(string name, int phoneBookId)
        {
            var phoneBooks = from p in _dbContext.PhoneBooks
                             where p.Id == phoneBookId
                             select new PhoneBookViewModel
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Entries = p.Entries.Where(x => x.Name == name).ToList()
                             };
            return await phoneBooks.ToListAsync();
        }
    }
}
