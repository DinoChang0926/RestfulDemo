using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestfulDemo.Data;
using RestfulDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulDemo.Services
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MemberRepository> _logger;
        public  MemberRepository(AppDbContext context,ILogger<MemberRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task CreateMemberAsync(Member member)
        {           
            try
            {
                member.CreateTime = DateTime.Now;
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("{0} Create Member {1}  Error : {2}",DateTime.Now,ex.ToString(),member.Email);
         
            }
            _logger.LogInformation("{0} Create Member {1}", DateTime.Now, member.Email);
           
        }

        public async Task DeleteMemberAsync(int Id)
        {            
            string MemberMail = null;
            try
            {
                Member member = await _context.Members.FindAsync(Id);
                MemberMail = member.Email;
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0} Delete Member Id:{1}  Error : {2}", DateTime.Now, ex.ToString(),Id);            
            }
            _logger.LogInformation("{0} Delete Member {1} ", DateTime.Now, MemberMail);        
        }

        public async Task EditMemberAsync(Member req)
        {
            try
            {
                Member member = _context.Members.Find(req.Id);
                member.Name = req.Name;
                member.Email = req.Email;
                member.Editor = req.Editor;
                member.Status = req.Status;
                member.Skills = req.Skills;
                member.Area = req.Area;
                member.CellPhone = req.CellPhone;
                member.Phone = req.Phone;
                member.ReportTo = req.ReportTo;
                member.Sex = req.Sex;
                member.EditTime = DateTime.Now;
                _context.Members.Update(member);
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0} Edit Member {1}  Error : {2}", DateTime.Now, ex.ToString(), req.Email);
             }
            _logger.LogInformation("{0} Update Member {1} ", DateTime.Now, req.Email);
        }

        public async Task<Member>GetMemberAsync(int Id)
        {
            Member m = null;
            try
            {
               m = await _context.Members.FindAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0} Member {1} Get Member Error : {2}", DateTime.Now, Id, ex.ToString());
            
            }                   
            return m;
        }

        public async Task<IEnumerable<Member>> GetMembersAsync()
        {       
            try
            {
                IQueryable<Member> m =  _context.Members;
                return await m.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0} Get Members Error : {2}", DateTime.Now, ex.ToString());
                return null;
            }
           
        }
    }
}
