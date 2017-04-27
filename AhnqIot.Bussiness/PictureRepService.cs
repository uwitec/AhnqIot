using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;
using Smart.Redis;

namespace AhnqIot.Bussiness
{
    public class PictureRepService : ServiceBase<PictureRep, PictureRepDto>, IPictureRepService
    {
    }
}
