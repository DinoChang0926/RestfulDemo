using RestfulDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestfulDemo.Services
{
    public interface IMemberRepository
    {
        public Task CreateMemberAsync(Member member);
        public Task EditMemberAsync(Member member);
        public Task DeleteMemberAsync(int Id);
        public Task<Member> GetMemberAsync(int Id);
        public Task<IEnumerable<Member>> GetMembersAsync();
    }
}
