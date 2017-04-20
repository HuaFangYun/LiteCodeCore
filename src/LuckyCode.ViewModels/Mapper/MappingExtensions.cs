using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Entity;
using LiteCode.Entity.News;
using LiteCode.Entity.OauthBase;
using LiteCode.ViewModels.SiteManager;
using Lucky.ViewModels.Models.News;

namespace LiteCode.ViewModels.Mapper
{
    public static class MappingExtensions
    {
        #region SysDepartment
        public static SysDepartment ToEntity(this SysDepartmentViewModel model)
        {
            return model.MapTo<SysDepartmentViewModel, SysDepartment>();
        }

        public static SysDepartmentViewModel ToModel(this SysDepartment entity)
        {
            return entity.MapTo<SysDepartment, SysDepartmentViewModel>();
        }
        #endregion

        #region SysApplication

        public static SysApplication ToEntity(this SysApplicationViewModel model)
        {
            return model.MapTo<SysApplicationViewModel, SysApplication>();
        }

        public static SysApplicationViewModel ToModel(this SysApplication entity)
        {
            return entity.MapTo<SysApplication, SysApplicationViewModel>();
        }
        #endregion

        #region SysUser

        public static SysUsers ToEntity(this SysUsersCreateViewModel model)
        {
            return model.MapTo<SysUsersCreateViewModel, SysUsers>();
        }

        public static SysUsersCreateViewModel ToModel(this SysUsers entity)
        {
            return entity.MapTo<SysUsers, SysUsersCreateViewModel>();
        }
        #endregion

        #region SysRole

        public static SysRoles ToEntity(this SysRoleViewModel model)
        {
            return model.MapTo<SysRoleViewModel, SysRoles>();
        }

        public static SysRoleViewModel ToModel(this SysRoles entity)
        {
            return entity.MapTo<SysRoles, SysRoleViewModel>();
        }
        #endregion

        #region SysModule

        public static SysModules ToEntity(this SysModuleViewModel model)
        {
            return model.MapTo<SysModuleViewModel, SysModules>();
        }
        public static SysModules ToEntity(this SysModuleViewModel model, SysModules entity)
        {
            return model.MapTo(entity);
        }

        public static SysModuleViewModel ToModel(this SysModules entity)
        {
            return entity.MapTo<SysModules, SysModuleViewModel>();
        }

        #endregion

        #region NewsArticle

        public static NewsArticle ToEntity(this ArticleViewModel model)
        {
            return model.MapTo<ArticleViewModel, NewsArticle>();
        }

        public static ArticleViewModel ToModel(this NewsArticle entity)
        {
            return entity.MapTo<NewsArticle, ArticleViewModel>();
        }
        #endregion

        #region Link

        public static Link ToEntity(this LinkViewModel model)
        {
            return model.MapTo<LinkViewModel, Link>();
        }

        public static LinkViewModel ToModel(this Link entity)
        {
            return entity.MapTo<Link, LinkViewModel>();
        }
        #endregion

        #region Category
        public static Category ToEntity(this CategoryViewModel model)
        {
            return model.MapTo<CategoryViewModel, Category>();
        }

        public static CategoryViewModel ToModel(this Category entity)
        {
            return entity.MapTo<Category, CategoryViewModel>();
        }
        #endregion

        #region NewsBanner
        public static NewsBanner ToEntity(this NewsBannerViewModel model)
        {
            return model.MapTo<NewsBannerViewModel, NewsBanner>();
        }

        public static NewsBannerViewModel ToModel(this NewsBanner entity)
        {
            return entity.MapTo<NewsBanner, NewsBannerViewModel>();
        }
        #endregion
    }
}
