using LoanManagementSystem.Domain.Entities;
using LoanManagementSystemApplication.Dtos;
using LoanManagementSystemApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApplication.Services
{
    public class MemberService
    {
        private readonly IMemberService _memberRepo;

        public MemberService(IMemberService memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<int> CreateMemberAsync(MemberDto dto)
        {
            var member = new Member
            {
                FullName = dto.FullName,
                NationalCode = dto.NationalCode,
                PhoneNumber = dto.PhoneNumber,
                RegisterDate = DateTime.UtcNow
            };
            return await _memberRepo.CreateAsync(member);
        }

        public async Task<int> UpdateMemberAsync(MemberDto dto)
        {
            var member = new Member
            {
                Id = dto.Id,
                FullName = dto.FullName,
                NationalCode = dto.NationalCode,
                PhoneNumber = dto.PhoneNumber
            };
            return await _memberRepo.UpdateAsync(member);
        }

        public async Task<int> DeleteMemberAsync(int memberId)
        {
            return await _memberRepo.DeleteAsync(memberId);
        }

        public async Task<MemberDto?> GetMemberByIdAsync(int id)
        {
            var member = await _memberRepo.GetByIdAsync(id);
            if (member == null) return null;

            return new MemberDto
            {
                Id = member.Id,
                FullName = member.FullName,
                NationalCode = member.NationalCode,
                PhoneNumber = member.PhoneNumber,
                RegisterDate = member.RegisterDate
            };
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            var members = await _memberRepo.GetAllAsync();
            return members.Select(m => new MemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                NationalCode = m.NationalCode,
                PhoneNumber = m.PhoneNumber,
                RegisterDate = m.RegisterDate
            });
        }
        public async Task<IEnumerable<MemberDto>> SearchMembersAsync(string? nationalCode, string? fullName)
        {
            var members = await _memberRepo.SearchByAsync(nationalCode, fullName);

            return members.Select(m => new MemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                NationalCode = m.NationalCode,
                PhoneNumber = m.PhoneNumber,
                RegisterDate = m.RegisterDate
            });
        }
    }
}
