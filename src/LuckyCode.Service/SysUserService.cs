using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Data;
using LiteCode.Entity;
using LiteCode.IService;
using LiteCode.ViewModels;
using LiteCode.ViewModels.Mapper;


namespace LiteCode.Service
{
    public class SysUserService:ISysUserService
    {
        private IRepository<SysUsers> _repository;
        public SysUserService(IRepository<SysUsers> repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<SysUsersCreateViewModel>> GetPagedList(int pageIndex, int pageSize)
        {
            return await _repository.Query().Select(a => new SysUsersCreateViewModel()
            {
                Username = a.UserName,
                FullName = a.FullName,
                CreateTime = a.CreateTime,
                Email = a.Email,
                Id = a.Id,
                IsLock = a.IsLock,
                
                Tel = a.PhoneNumber

            }).OrderByDescending(a => a.CreateTime).ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<SysUsersCreateViewModel> GetSysUsersViewModel(string id)
        {
            var entity =await _repository.SingleAsync(a => a.Id == id);
            return entity?.ToModel();
        }

        public async Task<bool> Exits(string id, string userName)
        {
            return await _repository.ExistsAsync(a => a.Id != id && a.UserName == userName);
        }
    }
}
