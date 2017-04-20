using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using LiteCode.Core;
using Lucky.Entity.Models;
using Lucky.IService.News;
using Lucky.ViewModels;
  using  LiteCode.Core.Data;
using LiteCode.Core.Utility;
using LiteCode.Core.Utility.Sequence;
using LiteCode.Data;
using Lucky.ViewModels.Models.News;
using LiteCode.Entity.News;
using LiteCode.ViewModels.Mapper;
using Microsoft.Extensions.Logging;
using LuckyCode.Core.Utility;
namespace Lucky.Service.News
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repository;
        private ILiteCodeContext _context;
        private ILogger _logger;
        public CategoryService(ILiteCodeContext context, IRepository<Category> repository, ILogger<CategoryService> logger)
        {
            _repository = repository;
            _logger = logger;
            _context = context;
        }
        public List<ListItemEntity> AppItemEntities()
        {
            return
                _repository.Query()
                    .Select(a => new ListItemEntity() {ID = a.CategoryId, ParentID = a.ParentId, Title = a.Title})
                    .ToList();
        }

        public void DeleteCategory(string id)
        {
           _repository.Delete(a=>a.CategoryId==id);
            _context.SaveChanges();
        }

        public async Task<CategoryViewModel> GetCategoryViewModel(string id)
        {
            var entity =await _repository.SingleAsync(a => a.CategoryId == id);
            return entity.ToModel();
        }

        public async Task<PagedList<CategoryViewModel>> GetPagedList(int pageIndex, int pageSize)
        {
            return
               await _repository.Query()
                    .ProjectTo<CategoryViewModel>(AutoMapperConfiguration.MapperConfiguration)
                    .OrderByDescending(a => a.CreateDate)
                    .ToPagedListAsync(pageIndex, pageSize);
        }

        public CategoryViewModel SaveCategory(CategoryViewModel model)
        {
            var entity = model.ToEntity();
            entity.CategoryId = SequenceQueue.NewIdString("");
            entity.CreateDate=DateTime.Now;
            _repository.AddAsync(entity);
            _context.SaveChanges();
            return model;
        }

        public CategoryViewModel UpdateCategory(CategoryViewModel model)
        {
            var entity = model.ToEntity();
            _repository.Update(entity);
            _context.SaveChanges();
            return model;
        }
    }
}
