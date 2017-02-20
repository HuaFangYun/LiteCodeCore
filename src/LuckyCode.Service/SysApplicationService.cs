using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Data;
using LiteCode.Core.Utility;
using LiteCode.Core.Utility.Sequence;
using LiteCode.Data;
using LiteCode.Entity;
using LiteCode.IService;
using LiteCode.ViewModels.Mapper;
using LiteCode.ViewModels.SiteManager;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
namespace LiteCode.Service
{
    public class SysApplicationService:ISysApplicationService
    {
        private IRepository<SysApplication> _repository;
        private ILiteCodeContext _context;
        public SysApplicationService(IRepository<SysApplication> repository,ILiteCodeContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<List<ListItemEntity>> AppItemEntities()
        {
            return await _repository.Query().Select(a => new ListItemEntity() { ID = a.Id, ParentID = "0", Title = a.ApplicationName }).ToListAsync();
        }

        public async Task DeleteSysApplication(string id)
        {
            _repository.Delete( id);
            await _context.SaveChangesAsync();
        }

        public async Task<SysApplicationViewModel> GetApplicationViewModel(string id)
        {
            var entity =await _repository.SingleAsync(a => a.Id == id);
            SysApplicationViewModel model = new SysApplicationViewModel();
            model.Id = entity.Id;
            model.ApplicationName = entity.ApplicationName;
            model.ApplicationUrl = entity.ApplicationUrl;
            return model;
        }

        public async Task<PagedList<SysApplicationViewModel>> GetPagedList()
        {
            return await _repository.Query().ProjectTo<SysApplicationViewModel>(AutoMapperConfiguration.MapperConfiguration).OrderByDescending(a => a.CreateTime).ToPagedListAsync(1, 20);
        }

        public async Task<SysApplicationViewModel> SaveSysApplication(SysApplicationViewModel model)
        {
            SysApplication entity = new SysApplication();
            entity.ApplicationName = model.ApplicationName;
            entity.ApplicationUrl = model.ApplicationUrl;
            entity.CreateTime = DateTime.Now;
            entity.Id = SequenceQueue.NewIdString("");
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();
            model.Id = entity.Id;
            model.CreateTime = entity.CreateTime;
            return model;
        }

        public async Task<SysApplicationViewModel> UpdateSysApplication(SysApplicationViewModel model)
        {
            SysApplication entity = new SysApplication();
            entity.ApplicationName = model.ApplicationName;
            entity.ApplicationUrl = model.ApplicationUrl;
            entity.Id = model.Id;
            _repository.Update(entity, new List<Expression<Func<SysApplication, object>>>() { a => a.ApplicationName, a => a.ApplicationUrl });
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
