using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulDemo.Dto;
using RestfulDemo.Models;
using RestfulDemo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestfulDemo.Controllers
{
    [Route("~/Api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberController(IMemberRepository memberRepository,
                                IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetMembersAsync()
        {
            var members = await _memberRepository.GetMembersAsync();
            var membersDto = _mapper.Map<IEnumerable<MemberDto>>(members);
            return Ok(membersDto);
        }
        [HttpGet("{Id}",Name = "GetMemberAync")]                   
        public async Task<IActionResult> GetMemberAync(int Id)
        {
            var member = await _memberRepository.GetMemberAsync(Id);
            var memberDto = _mapper.Map<MemberDto>(member);
            return Ok(memberDto);
        }
        [HttpPost]
        public IActionResult CreateMembers([FromForm] MemberCreateDto member)
        {
            var Member = _mapper.Map<Member>(member);
            _memberRepository.CreateMemberAsync(Member);
            var MemberReturn = _mapper.Map<MemberCreateDto>(Member);
            return CreatedAtRoute("GetMemberAync",new { Member.Id }, MemberReturn);
        }
        [HttpPut]
        public IActionResult EditMembers([FromForm] Member member)
        {
            _memberRepository.EditMemberAsync(member);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteMembers([FromRoute] int Id)
        {
            _memberRepository.DeleteMemberAsync(Id);
            return NoContent();
        }
    }
}
