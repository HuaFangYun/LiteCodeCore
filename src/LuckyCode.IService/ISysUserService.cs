﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Entity;
using LiteCode.ViewModels;


namespace LiteCode.IService
{
    public interface ISysUserService
    {
        Task<PagedList<SysUsersCreateViewModel>> GetPagedList(int pageIndex, int pageSize);
        Task<SysUsersCreateViewModel> GetSysUsersViewModel(string id);
    }
}
