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
using NewLife.Common;
using Smart.Redis;
using AhnqIot.Infrastructure.DI;
using Autofac;

namespace AhnqIot.Bussiness
{
    public class FacilityService : ServiceBase<Facility, FacilityDto>, IFacilityService
    {
        public IAhnqIotRepository<FacilityType> FacilityTypeRep { get; set; }

        /// <summary>
        /// 初始化设施类型数据
        /// </summary>
        /// <returns></returns>
        public override void InitData()
        {
            AddEntity("wenshi", "温室类", "", "");
            AddEntity("wenshi-" + PinYin.Get("花卉"), "花卉", "wenshi", "");
            AddEntity("wenshi-" + PinYin.Get("蔬菜"), "蔬菜", "wenshi", "");

            AddEntity("datian", "大田类", "", "");
            AddEntity("datian-" + PinYin.Get("水稻"), "水稻", "datian", "");
            AddEntity("datian-" + PinYin.Get("小麦"), "小麦", "datian", "");
            AddEntity("datian-" + PinYin.Get("茶叶"), "茶叶", "datian", "");

            AddEntity("bird", "禽类", "", "");
            AddEntity("bird-" + PinYin.Get("鸡舍"), "鸡舍", "bird", "");
            AddEntity("bird-" + PinYin.Get("鸭舍"), "鸭舍", "bird", "");

            AddEntity("livestock", "畜牧类", "", "");
            AddEntity("livestock-" + PinYin.Get("猪舍"), "猪舍", "livestock", "");
            AddEntity("livestock-" + PinYin.Get("羊舍"), "羊舍", "livestock", "");

            AddEntity("aquatic", "水产类", "", "");
            AddEntity("aquatic-" + PinYin.Get("虾"), "虾", "aquatic", "");
            AddEntity("aquatic-" + PinYin.Get("蟹"), "蟹", "aquatic", "");
            AddEntity("aquatic-" + PinYin.Get("鱼"), "鱼", "aquatic", "");

        }

        /// <summary>
        /// 根据编码获取设施
        /// </summary>
        /// <param name="id">设施编码</param>
        /// <returns></returns>
        public async Task<FacilityDto> GetFacilityByIdAsny(string id)
        {
            //var e = await _facilityDtoRep.GetByIdAsync(id);
            //return Mapper.Map<FacilityDto>(e);
            try
            {
                var facility = RedisClient.HashGet<FacilityDto>(RedisKey, id, DataType.Protobuf);
                if (facility == null)
                {
                    var dev = await Repository.GetByIdAsync(id);
                    if (dev != null)
                    {
                        var dto = Mapper.Map<FacilityDto>(dev);
                        RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);
                        return dto;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return facility;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加设施
        /// </summary>
        /// <param name="dto">设施实体</param>
        /// <returns></returns>
        public async Task<bool> AddFacility(FacilityDto dto)
        {
            try
            {
                RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);
                return await base.AddAsync(dto) > 0;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// 更新设施
        /// </summary>
        /// <param name="dto">设施</param>
        /// <returns></returns>实体
        public async Task<bool> UpdateFacilityAsnyc(FacilityDto dto)
        {
            try
            {
                RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);
                return await base.UpdateAsync(dto) > 0;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 根据基地编码获取设施
        /// </summary>
        /// <param name="farmId">基地编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<FacilityDto>> GetFacilitiesByFarmIdAsny(string farmId)
        {
            return await GetManyAsync(f => f.FarmSerialnum.Equals(farmId));
        }
        /// <summary>
        /// 根据基地编码获取设施
        /// </summary>
        /// <param name="farmId">基地编码</param>
        /// <returns></returns>
        public IEnumerable<FacilityDto> GetFacilitiesByFarmId(string farmId)
        {
            return GetDtoModels(Repository.GetMany(f => f.FarmSerialnum.Equals(farmId)));
        }
        /// <summary>
        /// 添加设施类型
        /// </summary>
        /// <param name="serialnum"></param>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private FacilityType AddEntity(string serialnum, string name, string parent, string description)
        {
            var entity = new FacilityType();
            entity.Serialnum = serialnum;
            entity.Name = name;
            entity.ParentSerialnum = parent;
            entity.PhotoUrl = "FacilityType/" + PinYin.GetFirst(name) + ".png";
            entity.Css = "xzss-icon xzss-icon-" + PinYin.GetFirst(name);
            entity.Introduce = description;
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.UpdateSysUserSerialnum = "admin";
            entity.Sort = 0;
            entity.Remark = "systype";
            entity.IsSystem = true;
            FacilityTypeRep.Add(entity);
            FacilityTypeRep.Commit();
            return entity;
        }


        /// <summary>
        /// 检验编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode(string code)
        {
            return code.Substring(9, 1).Equals("G") ? true : false;
        }

        /// <summary>
        ///     检测设施是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(string id)
        {
            var redisExists = RedisClient.HashFieldExists(RedisKey, id, DataType.Protobuf) > 0;
            if (redisExists) return true;

            var dbExists = await base.ExistsAsync(id);
            return dbExists;
        }

        /// <summary>
        ///     初始化,将数据库中facility表的所有记录取出来放到Redis中
        /// </summary>
        /// <returns></returns>
        private static async Task LoadData()
        {
            var list = await AhnqIotContainer.Container.Resolve<IAhnqIotRepository<Facility>>().GetAllAsync();
            var dtoList = Mapper.Map<IEnumerable<FacilityDto>>(list);
            Parallel.ForEach(dtoList,
                item => { RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf); });
        }
    }
}
