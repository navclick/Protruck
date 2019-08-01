﻿using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
public interface ISettingRepository
    {

        Task<Response> GetSetting();

        Task<Response> AddSetting(Setting setting);
        Task<Response> RemoveSetting(Setting setting);
        Task<Response> UpdateSetting(Setting setting);

    }
}