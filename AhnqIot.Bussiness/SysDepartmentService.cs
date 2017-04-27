#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： SysDepartmentService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 0:10
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Hxj.Repository.AhnqIot;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.Log;
using AutoMapper;

namespace AhnqIot.Bussiness
{
    [InitData(1)]
    public class SysDepartmentService : ServiceBase<SysDepartment, SysDepartmentDto>, ISysDepartmentService
    {
        public IAhnqIotRepository<SysArea> SysAreaRep { get; set; }

        public SysDepartmentService()
        {

        }

        /// <summary>
        /// 根据名称查找机构
        /// </summary>
        /// <param name="name">机构名称</param>
        /// <returns></returns>
        public async Task<SysDepartmentDto> GetSysDepartByNameAsny(string name)
        {
            return Mapper.Map<SysDepartmentDto>(await Repository.GetAsync(sd => sd.Name.Equals(name)));
        }

        /// <summary>
        /// 根据上级编码查找机构
        /// </summary>
        /// <param name="id">上级编码</param>
        /// <returns></returns>
        public async Task<SysDepartmentDto> GetParentByParentIdAsny(string id)
        {
            return Mapper.Map<SysDepartmentDto>(await Repository.GetAsync(sd => sd.ParentSerialnum.Equals(id)));
        }

        /// <summary>
        /// 根据上级编码查找机构
        /// </summary>
        /// <param name="id">上级编码</param>
        /// <returns></returns>
        public SysDepartmentDto GetParentByParentId(string id)
        {
            return Mapper.Map<SysDepartmentDto>(Repository.Get(sd => sd.Serialnum.Equals(id)));
        }


        #region 从text文件导入初始化数据

        public override void InitData()
        {
            ImportFromText();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        public async void ImportFromText()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NewLife.Runtime.IsWeb ? "bin" : "", "ExtendResource", "安徽行政区域.txt");
            if (File.Exists(path))
            {
                LogHelper.Info("从文件导入系统机构信息");
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    sr.ReadLine(); //跳过第一行
                    sr.ReadLine(); //跳过第二行
                    var systemDep = sr.ReadLine();
                    FindByAdd("00001", "系统机构");
                    var areas = Repository.GetAll().ToList();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.IsNullOrWhiteSpace()) continue;

                        var arr = line.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.None);

                        var area = SysAreaRep.Get(sa => sa.Name.Equals(arr[3]));
                        FindByAdd(arr[0].PadLeft(5, '0'), arr[1], arr[2], area == null ? "" : area.Serialnum);
                    }
                }
            }
            var result = (await Repository.GetAllAsync()).ToList().Count;
            LogHelper.Info("共初始化机构数据{0}条", result);
        }


        /// <summary>
        /// 查找机构并添加
        /// </summary>
        /// <param name="name">机构名称</param>
        /// <param name="parentName">上级机构名称</param>
        /// <param name="areaSerialnum">区域编码</param>
        /// <returns></returns>
        public SysDepartment FindByAdd(string serialnum, string name, string parentName = null,
            string areaSerialnum = null)
        {
            var entity = Repository.Get(sd => sd.Name.Equals(name));
            if (entity == null)
            {
                entity = new SysDepartment() { Name = name };
                if (!parentName.IsNullOrWhiteSpace())
                {
                    var parent = Repository.Get(sd => sd.Name.Equals(parentName));
                    if (parent != null)
                    {
                        entity.ParentSerialnum = parent.Serialnum;
                        if (!areaSerialnum.IsNullOrWhiteSpace())
                        {
                            entity.SysAreaSerialnum = areaSerialnum;
                        }
                    }
                }
                entity.Serialnum = serialnum;
                entity.Status = 1;
                entity.Description = "";
                entity.CreateTime = entity.UpdateTime = DateTime.Now;
                entity.Sort = 0;
                Repository.Add(entity);
                Repository.Commit();
            }

            return entity;
        }



        /// <summary>
        /// 添加机构
        /// </summary>
        /// <param name="serialnum">机构编码</param>
        /// <param name="name">机构名称</param>
        /// <param name="description">描述</param>
        /// <param name="parent">上级编码</param>
        private void AddDepartment(string serialnum, string name, string description, string parent)
        {
            var department = new SysDepartment();
            department.Serialnum = serialnum;
            department.Name = name;
            department.ParentSerialnum = parent;
            department.Status = 1;
            department.Description = description;
            department.SysAreaSerialnum = "A0";
            Repository.Add(department);
        }
        #endregion
    }
}