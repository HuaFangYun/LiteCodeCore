using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Data;
using LiteCode.Core.Utility;
using LiteCode.Core.Utility.Sequence;
using LiteCode.Data;
using LiteCode.Entity.OauthBase;
using LiteCode.IService;
using LiteCode.ViewModels.Mapper;
using LiteCode.ViewModels.SiteManager;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace LiteCode.Service
{
    public class SysDepartmentService : ISysDepartmentService
    {
        private IRepository<SysDepartment> _repository;
        private ILiteCodeContext _context;
        public SysDepartmentService(IRepository<SysDepartment> repository, ILiteCodeContext context)
        {
            _repository = repository;
        }

        public async Task DeleteDepartment(string id)
        {
            _repository.Delete(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ListItemEntity>> GetDepartmentTree()
        {
            var restree = new List<ListItemEntity>();
            var list =await _repository.Query().ProjectTo<SysDepartmentViewModel>(AutoMapperConfiguration.MapperConfiguration).ToListAsync();
            BuildDepartmentTree(list, "0", restree);
            return restree;
        }

        private void BuildDepartmentTree(List<SysDepartmentViewModel> list, string parntid, List<ListItemEntity> resList)
        {
            var _temlist = list.Where(a => a.ParentId == parntid);
            foreach (var model in _temlist)
            {
                resList.Add(new ListItemEntity() { ID = model.Id, ParentID = model.ParentId, Title = model.DepartmentName });
                BuildDepartmentTree(list, model.Id, resList);
            }

        }
        public async Task<PagedList<SysDepartmentViewModel>> GetPagedList(int pageIndex, int pageSize)
        {
            return await _repository.Query().ProjectTo<SysDepartmentViewModel>(AutoMapperConfiguration.MapperConfiguration).OrderByDescending(a => a.Sort).ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<SysDepartmentViewModel> GetSysDepartmentViewModel(string id)
        {
            var entity = await _repository.SingleAsync(a => a.DepartmentId == id);
            return entity.ToModel();
        }

        public async Task<SysDepartmentViewModel> SaveSysDepartment(SysDepartmentViewModel model)
        {
            var entity = model.ToEntity();
            entity.DepartmentId = SequenceQueue.NewIdString("");
            entity.State = 0;
            entity.ParentId = model.ParentId;
            entity.DepartmentName = model.DepartmentName;
            model.Id = entity.DepartmentId;
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<SysDepartmentViewModel> UpdateSysDeparment(SysDepartmentViewModel model)
        {
            var entity = model.ToEntity();
            entity.DepartmentId = model.Id;
            _repository.Update(entity);
            await _context.SaveChangesAsync();
            return model;
        }


    }
}
