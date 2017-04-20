using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using LiteCode.Core;
using LiteCode.Core.Data;
using LiteCode.Core.Utility.Sequence;
using LiteCode.Data;
using LiteCode.Entity.News;
using LiteCode.ViewModels.Mapper;
using Lucky.Entity.News;
using Lucky.IService;
using Lucky.IService.News;
using Lucky.ViewModels;
using Lucky.ViewModels.Models.News;
using Microsoft.Extensions.Logging;

namespace Lucky.Service
{
    public class NewsBannerService : INewsBannerService
    {
        private IRepository<NewsBanner> _repository;
        private ILiteCodeContext _context;
        private ILogger _logger;
        public NewsBannerService(ILiteCodeContext context, IRepository<NewsBanner> repository, ILogger<NewsBannerService> logger)
        {
            _repository = repository;
            _logger = logger;
            _context = context;
        }
        public void DeleteNewsBanner(Guid id)
        {
            _repository.Delete(a=>a.Id==id);
            _context.SaveChanges();
        }

        public async Task<NewsBannerViewModel> GetNewsBannerViewModel(Guid id)
        {
            var entity =await _repository.SingleAsync(a => a.Id == id);
            return entity.ToModel();
        }

        public PagedList<NewsBannerViewModel> GetPagedList(int pageIndex, int pageSize)
        {
            return _repository.Query().ProjectTo<NewsBannerViewModel>(AutoMapperConfiguration.MapperConfiguration).OrderByDescending(a => a.CreateTime).ToPagedList(pageIndex, pageSize);
        }

        public NewsBannerViewModel SaveNewsBanner(NewsBannerViewModel model)
        {
            var entity = model.ToEntity();
            entity.Id = SequenceQueue.NewIdGuid();
            entity.CreateTime=DateTime.Now;
            _repository.AddAsync(entity);
            model.Id = entity.Id;
            _context.SaveChanges();
            return model;
        }

        public NewsBannerViewModel UpdateNewsBanner(NewsBannerViewModel model)
        {
            var entity = model.ToEntity();
            _repository.Update(entity);
            _context.SaveChanges();
            return model;
        }
    }
}
