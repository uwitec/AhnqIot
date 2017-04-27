#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.EF
// FILENAME   ： AhnqIotContext.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-26 16:46
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using AhnqIot.DbModel;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

#endregion

namespace AhnqIot.EF
{
    /// <summary>
    ///     Ahnq Iot DbContext
    /// </summary>
    public partial class AhnqIotContext : ContextBase, IDbContext
    {
        public AhnqIotContext()
        {
            //ConnectionString = "Server=192.168.1.242;Database=AWIOT5;User ID=sa;Password=*************";
        }

        public AhnqIotContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(ConnectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AWProduct>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AWProductTypeSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Href).HasMaxLength(500);

                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                //并发控制
                // entity.Property(p => p.TimeStamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

                entity.HasOne(d => d.AWProductTypeSerialnumNavigation)
                    .WithMany(p => p.AWProduct)
                    .HasForeignKey(d => d.AWProductTypeSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.AWProduct)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AWProductType>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AgrDiagnosticInfo>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AgrDiagnosticModelSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgrDiagnosticModelSerialnumNavigation)
                    .WithMany(p => p.AgrDiagnosticInfo)
                    .HasForeignKey(d => d.AgrDiagnosticModelSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AgrDiagnosticModel>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Advise).HasMaxLength(500);

                entity.Property(e => e.AgrProductObjectGrowthInfoSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceTypeSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DisplayColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Effect).HasMaxLength(500);

                entity.Property(e => e.MaxValue).HasColumnType("decimal");

                entity.Property(e => e.MinValue).HasColumnType("decimal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.TipInfo).HasColumnType("ntext");

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgrProductObjectGrowthInfoSerialnumNavigation)
                    .WithMany(p => p.AgrDiagnosticModel)
                    .HasForeignKey(d => d.AgrProductObjectGrowthInfoSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DeviceTypeSerialnumNavigation)
                    .WithMany(p => p.AgrDiagnosticModel)
                    .HasForeignKey(d => d.DeviceTypeSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AgrProduceAnniversaryService>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AgrProductObjectSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.MainDevelopmentalStage)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PossibleDisasters)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.ServiceContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ServiceFocus)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SysAreaSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TakeMeasures)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgrProductObjectSerialnumNavigation)
                    .WithMany(p => p.AgrProduceAnniversaryService)
                    .HasForeignKey(d => d.AgrProductObjectSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysAreaSerialnumNavigation)
                    .WithMany(p => p.AgrProduceAnniversaryService)
                    .HasForeignKey(d => d.SysAreaSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AgrProduceCondition>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AgrProductObjectSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DevelopmentalStage).HasMaxLength(100);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SuitableCondition)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.SysAreaSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgrProductObjectSerialnumNavigation)
                    .WithMany(p => p.AgrProduceCondition)
                    .HasForeignKey(d => d.AgrProductObjectSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysAreaSerialnumNavigation)
                    .WithMany(p => p.AgrProduceCondition)
                    .HasForeignKey(d => d.SysAreaSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AgrProductObject>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AgrProducationTypeSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CropUrl).HasMaxLength(500);

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AgrProductObjectGrowthInfo>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AgrProductObjectSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgrProductObjectSerialnumNavigation)
                    .WithMany(p => p.AgrProductObjectGrowthInfo)
                    .HasForeignKey(d => d.AgrProductObjectSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AreaStation>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Addr).HasMaxLength(500);

                entity.Property(e => e.Atmosphere).HasColumnType("decimal");

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Humidity).HasColumnType("decimal");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Lontitude).HasMaxLength(50);

                entity.Property(e => e.Rainfall).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.StationCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Temprature).HasColumnType("decimal");

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WindSpeed).HasColumnType("decimal");

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.AreaStation)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AreaStationDataInfo>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AreaStationSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Atmosphere).HasColumnType("decimal");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Humidity).HasColumnType("decimal");

                entity.Property(e => e.Rainfall).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Temprature).HasColumnType("decimal");

                entity.Property(e => e.WindSpeed).HasColumnType("decimal");

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.HasOne(d => d.AreaStationSerialnumNavigation)
                    .WithMany(p => p.AreaStationDataInfo)
                    .HasForeignKey(d => d.AreaStationSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ArticleCategory>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserUserName).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserUserName).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArticleContent>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.ArticleCategoryName).HasMaxLength(50);

                entity.Property(e => e.ArticleCategorySerialnum).HasMaxLength(50);

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.Cover).HasMaxLength(200);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PublishTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SourceName).HasMaxLength(50);

                entity.Property(e => e.SourceUrl).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            //modelBuilder.Entity<CONTENT_LIST>(entity =>
            //{
            //    entity.Property(e => e.ID).HasColumnType("decimal");

            //    entity.Property(e => e.City)
            //        .HasMaxLength(8)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.Click).HasColumnType("decimal");

            //    entity.Property(e => e.CustomType)
            //        .HasMaxLength(254)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.FileCode).HasMaxLength(54);

            //    entity.Property(e => e.FileUser).HasMaxLength(54);

            //    entity.Property(e => e.FLV)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.HOT_ID)
            //        .HasMaxLength(200)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.HTML_PATH)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.INFO_ID)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.INFOSOURCE).HasMaxLength(200);

            //    entity.Property(e => e.INFOTYPE).HasColumnType("decimal");

            //    entity.Property(e => e.KEYWORD).HasMaxLength(200);

            //    entity.Property(e => e.LONGTITLE).HasMaxLength(500);

            //    entity.Property(e => e.MP3).HasMaxLength(50);

            //    entity.Property(e => e.ORDERID).HasColumnType("decimal");

            //    entity.Property(e => e.PIC)
            //        .HasMaxLength(200)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.RELATION_ID)
            //        .HasMaxLength(200)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.STATE).HasColumnType("decimal");

            //    entity.Property(e => e.SUMMARY)
            //        .HasMaxLength(800)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.TIME_LAST).HasColumnType("datetime");

            //    entity.Property(e => e.TIME_PUBLISH).HasColumnType("datetime");

            //    entity.Property(e => e.TIME_UNPUBLISH).HasColumnType("datetime");

            //    entity.Property(e => e.TITLE).HasMaxLength(200);

            //    entity.Property(e => e.TITLE_COLOR)
            //        .HasMaxLength(10)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.URL_LINK)
            //        .HasMaxLength(100)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.USER_ID).HasColumnType("decimal");

            //    entity.Property(e => e.USER_ID_PUB).HasColumnType("decimal");

            //    entity.Property(e => e.USER_NAME).HasMaxLength(50);

            //    entity.Property(e => e.USER_NAME_PUB).HasMaxLength(50);
            //});

            modelBuilder.Entity<CameraStationOnlineStatistics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CameraStationsSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.OnlinePercent).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CameraStationsSerialnumNavigation)
                    .WithMany(p => p.CameraStationOnlineStatistics)
                    .HasForeignKey(d => d.CameraStationsSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CameraStationPics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CameraStationsPresetSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PicSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CameraStationsPresetSerialnumNavigation)
                    .WithMany(p => p.CameraStationPics)
                    .HasForeignKey(d => d.CameraStationsPresetSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PicSerialnumNavigation)
                    .WithMany(p => p.CameraStationPics)
                    .HasForeignKey(d => d.PicSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CameraStationPresetPoint>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CameraStationsSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CameraStationsSerialnumNavigation)
                    .WithMany(p => p.CameraStationPresetPoint)
                    .HasForeignKey(d => d.CameraStationsSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CameraStationRunLog>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CameraStationsSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CameraStationsSerialnumNavigation)
                    .WithMany(p => p.CameraStationRunLog)
                    .HasForeignKey(d => d.CameraStationsSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CameraStations>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Channel).HasDefaultValue(1);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DataPort).HasDefaultValue(8000);

                entity.Property(e => e.HttpPort).HasDefaultValue(80);

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.IP).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Lotitude).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.RtspPort).HasDefaultValue(554);

                entity.Property(e => e.SetupTime).HasColumnType("datetime");

                entity.Property(e => e.StreamMedia).HasMaxLength(500);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserID)
                    .HasMaxLength(50)
                    .HasDefaultValue("admin");

                entity.Property(e => e.UserPwd)
                    .HasMaxLength(50)
                    .HasDefaultValue("admin");

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.CameraStations)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Categories>(entity => { entity.HasKey(e => e.CategoryID); });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Addr).HasMaxLength(500);

                entity.Property(e => e.ApplyTime).HasColumnType("datetime");

                entity.Property(e => e.ContactMan).HasMaxLength(50);

                entity.Property(e => e.ContactPhone).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Lontitude).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pinyin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CompanyPics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CompanySerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PicSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CompanySerialnumNavigation)
                    .WithMany(p => p.CompanyPics)
                    .HasForeignKey(d => d.CompanySerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PicSerialnumNavigation)
                    .WithMany(p => p.CompanyPics)
                    .HasForeignKey(d => d.PicSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CompanyUser>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CompanySerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FacilitySerialnum).HasMaxLength(50);

                entity.Property(e => e.FarmSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.SysUserSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CompanySerialnumNavigation)
                    .WithMany(p => p.CompanyUser)
                    .HasForeignKey(d => d.CompanySerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysUserSerialnumNavigation)
                    .WithMany(p => p.CompanyUser)
                    .HasForeignKey(d => d.SysUserSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceTypeSerialnum).HasMaxLength(50);

                entity.Property(e => e.FacilitySerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.ProcessedValue).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.ShowValue).HasMaxLength(500);

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.Property(e => e.RelayType).HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceTypeSerialnumNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.DeviceTypeSerialnum);

                entity.HasOne(d => d.FacilitySerialnumNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.FacilitySerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceControlCommand>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Command).HasMaxLength(500);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceControlCommand)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceControlLog>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CommandSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceShowValue).HasMaxLength(500);

                entity.Property(e => e.DeviceValue).HasColumnType("decimal");

                entity.Property(e => e.FailReason).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CommandSerialnumNavigation)
                    .WithMany(p => p.DeviceControlLog)
                    .HasForeignKey(d => d.CommandSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceControlLog)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceDataExceptionLog>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Max).HasColumnType("decimal");

                entity.Property(e => e.Min).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal");

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceDataExceptionLog)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceDataInfo>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Max).HasColumnType("decimal");

                entity.Property(e => e.Min).HasColumnType("decimal");

                entity.Property(e => e.ProcessedValue).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.ShowValue).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceDataInfo)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceExceptionSet>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Max).HasColumnType("decimal");

                entity.Property(e => e.Min).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceExceptionSet)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceRunLog>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DeviceRunLogTypeSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceRunLogTypeSerialnumNavigation)
                    .WithMany(p => p.DeviceRunLog)
                    .HasForeignKey(d => d.DeviceRunLogTypeSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceRunLog)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceRunLogType>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<DeviceRunningStatistics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DataExceptionPercent).HasColumnType("decimal");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReceivePercent).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceRunningStatistics)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceTimeSharingStatistics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AvgValue).HasColumnType("decimal");

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndValue).HasColumnType("decimal");

                entity.Property(e => e.Max).HasColumnType("decimal");

                entity.Property(e => e.MaxValue).HasColumnType("decimal");

                entity.Property(e => e.Min).HasColumnType("decimal");

                entity.Property(e => e.MinValue).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.StartValue).HasColumnType("decimal");

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceSerialnumNavigation)
                    .WithMany(p => p.DeviceTimeSharingStatistics)
                    .HasForeignKey(d => d.DeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExceptionSms>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.ContactMobile).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.ContactMan).HasMaxLength(50);

                entity.Property(e => e.ContactMobile).HasMaxLength(50);

                entity.Property(e => e.ContactPhone).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FacilityTypeSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FarmSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.FacilityTypeSerialnumNavigation)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.FacilityTypeSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.FarmSerialnumNavigation)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.FarmSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FacilityCamera>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Channel).HasDefaultValue(1);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DataPort).HasDefaultValue(8000);

                entity.Property(e => e.FacilitySerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HttpPort).HasDefaultValue(80);

                entity.Property(e => e.IP).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.RtspPort).HasDefaultValue(554);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("admin");

                entity.Property(e => e.UserPwd).HasMaxLength(50);
            });

            modelBuilder.Entity<FacilityCameraPresetPoint>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FacilityCameraSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.FacilityCameraSerialnumNavigation)
                    .WithMany(p => p.FacilityCameraPresetPoint)
                    .HasForeignKey(d => d.FacilityCameraSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FacilityCameraRunLog>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FacilityCameraSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.FacilityCameraSerialnumNavigation)
                    .WithMany(p => p.FacilityCameraRunLog)
                    .HasForeignKey(d => d.FacilityCameraSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FacilityCameraRunStatistics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FacilityCameraSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OnlinePercent).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.FacilityCameraSerialnumNavigation)
                    .WithMany(p => p.FacilityCameraRunStatistics)
                    .HasForeignKey(d => d.FacilityCameraSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FacilityPics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FacilityCameraPresetSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FacilitySerialnum)
                  .IsRequired()
                  .HasMaxLength(50);

                entity.Property(e => e.PicSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.FacilityCameraPresetSerialnumNavigation)
                    .WithMany(p => p.FacilityPics)
                    .HasForeignKey(d => d.FacilityCameraPresetSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.FacilitySerialnumNavigation)
                  .WithMany(p => p.FacilityPics)
                  .HasForeignKey(d => d.FacilitySerialnum)
                  .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PicSerialnumNavigation)
                    .WithMany(p => p.FacilityPics)
                    .HasForeignKey(d => d.PicSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FacilityProduceInfo>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AgrProductObjectSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FacilitySerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgrProductObjectSerialnumNavigation)
                    .WithMany(p => p.FacilityProduceInfo)
                    .HasForeignKey(d => d.AgrProductObjectSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.FacilitySerialnumNavigation)
                    .WithMany(p => p.FacilityProduceInfo)
                    .HasForeignKey(d => d.FacilitySerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FacilityType>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Css).HasMaxLength(50);

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.IsSystem).HasDefaultValue(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.APIKey).HasMaxLength(500);

                entity.Property(e => e.AreaStationSerialnum).HasMaxLength(50);

                entity.Property(e => e.CompanySerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactMan).HasMaxLength(50);

                entity.Property(e => e.ContactPhone).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Lotitude).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UploadPassword).HasMaxLength(50);

                entity.HasOne(d => d.AreaStationSerialnumNavigation)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.AreaStationSerialnum);

                entity.HasOne(d => d.CompanySerialnumNavigation)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.CompanySerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.IP)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OccurTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            //modelBuilder.Entity<NewClassByContent>(entity =>
            //{
            //    entity.Property(e => e.DateTime).HasColumnType("datetime");

            //    entity.Property(e => e.Title)
            //        .HasMaxLength(100)
            //        .HasColumnType("varchar");

            //    entity.Property(e => e.Title1)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar");
            //});

            modelBuilder.Entity<PictureRep>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Href).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<SysArea>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.AwCode).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SysDepartment>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysAreaSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SysAreaSerialnumNavigation)
                    .WithMany(p => p.SysDepartment)
                    .HasForeignKey(d => d.SysAreaSerialnum);
            });

            modelBuilder.Entity<SysFunction>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Action).HasMaxLength(500);

                entity.Property(e => e.Controller).HasMaxLength(500);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysFunctionSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SysFunctionSerialnumNavigation)
                    .WithMany(p => p.SysMenu)
                    .HasForeignKey(d => d.SysFunctionSerialnum);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Permission).HasColumnType("ntext");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Url).HasMaxLength(500);
            });

            modelBuilder.Entity<SysRoleMenu>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysMenuSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysRoleSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SysMenuSerialnumNavigation)
                    .WithMany(p => p.SysRoleMenu)
                    .HasForeignKey(d => d.SysMenuSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysRoleSerialnumNavigation)
                    .WithMany(p => p.SysRoleMenu)
                    .HasForeignKey(d => d.SysRoleSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastIP).HasMaxLength(50);

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.LastUrl).HasMaxLength(500);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysRoleSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.SysUser)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SysRoleSerialnumNavigation)
                    .WithMany(p => p.SysUser)
                    .HasForeignKey(d => d.SysRoleSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WeatherDevice>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal");

                entity.Property(e => e.WeatherDeviceTypeSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WeatherStationSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.WeatherDeviceTypeSerialnumNavigation)
                    .WithMany(p => p.WeatherDevice)
                    .HasForeignKey(d => d.WeatherDeviceTypeSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WeatherStationSerialnumNavigation)
                    .WithMany(p => p.WeatherDevice)
                    .HasForeignKey(d => d.WeatherStationSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WeatherDeviceType>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Calc).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Introduce).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentSerialnum).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<WeatherStation>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Introduce).HasColumnType("ntext");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Lotitude).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SetupTime).HasColumnType("datetime");

                entity.Property(e => e.SysDepartmentSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.WeatherStation)
                    .HasForeignKey(d => d.SysDepartmentSerialnum);
            });

            modelBuilder.Entity<WeatherStationOnlineStatistics>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ReceivePercent).HasColumnType("decimal");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SetupTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WeatherDeviceSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.WeatherDeviceSerialnumNavigation)
                    .WithMany(p => p.WeatherStationOnlineStatistics)
                    .HasForeignKey(d => d.WeatherDeviceSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WeatherWarn>(entity =>
            {
                entity.HasKey(e => e.Serialnum);

                entity.Property(e => e.Serialnum).HasMaxLength(50);

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.Cover).HasMaxLength(200);

                entity.Property(e => e.CreateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PublishTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SourceName).HasMaxLength(50);

                entity.Property(e => e.SourceUrl).HasMaxLength(50);

                entity.Property(e => e.SysDepartmentSerialnum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateSysUserSerialnum).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SysDepartmentSerialnumNavigation)
                    .WithMany(p => p.WeatherWarn)
                    .HasForeignKey(d => d.SysDepartmentSerialnum)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //modelBuilder.Entity<sysdiagrams>(entity =>
            //{
            //    entity.HasKey(e => e.diagram_id);

            //    entity.Property(e => e.definition).HasColumnType("varbinary");
            //});

            ConfigConcurrencyToken(modelBuilder);
        }

        /// <summary>
        ///     并发配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected void ConfigConcurrencyToken(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<AWProduct>(entity =>entity.Property(p => p.TimeStamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken());
        }

        #region DbSet<T>

        //public virtual DbSet<AWProduct> AWProduct { get; set; }
        //public virtual DbSet<AWProductType> AWProductType { get; set; }
        //public virtual DbSet<AgrDiagnosticInfo> AgrDiagnosticInfo { get; set; }
        //public virtual DbSet<AgrDiagnosticModel> AgrDiagnosticModel { get; set; }
        //public virtual DbSet<AgrProduceAnniversaryService> AgrProduceAnniversaryService { get; set; }
        //public virtual DbSet<AgrProduceCondition> AgrProduceCondition { get; set; }
        //public virtual DbSet<AgrProductObject> AgrProductObject { get; set; }
        //public virtual DbSet<AgrProductObjectGrowthInfo> AgrProductObjectGrowthInfo { get; set; }
        //public virtual DbSet<AreaStation> AreaStation { get; set; }
        //public virtual DbSet<AreaStationDataInfo> AreaStationDataInfo { get; set; }
        //public virtual DbSet<ArticleCategory> ArticleCategory { get; set; }
        //public virtual DbSet<ArticleContent> ArticleContent { get; set; }
        ////public virtual DbSet<CONTENT_LIST> CONTENT_LIST { get; set; }
        //public virtual DbSet<CameraStationOnlineStatistics> CameraStationOnlineStatistics { get; set; }
        //public virtual DbSet<CameraStationPics> CameraStationPics { get; set; }
        //public virtual DbSet<CameraStationPresetPoint> CameraStationPresetPoint { get; set; }
        //public virtual DbSet<CameraStationRunLog> CameraStationRunLog { get; set; }
        //public virtual DbSet<CameraStations> CameraStations { get; set; }
        //public virtual DbSet<Categories> Categories { get; set; }
        //public virtual DbSet<Company> Company { get; set; }
        //public virtual DbSet<CompanyPics> CompanyPics { get; set; }
        //public virtual DbSet<CompanyUser> CompanyUser { get; set; }
        //public virtual DbSet<Device> Device { get; set; }
        //public virtual DbSet<DeviceControlCommand> DeviceControlCommand { get; set; }
        //public virtual DbSet<DeviceControlLog> DeviceControlLog { get; set; }
        //public virtual DbSet<DeviceDataExceptionLog> DeviceDataExceptionLog { get; set; }
        //public virtual DbSet<DeviceDataInfo> DeviceDataInfo { get; set; }
        //public virtual DbSet<DeviceExceptionSet> DeviceExceptionSet { get; set; }
        //public virtual DbSet<DeviceRunLog> DeviceRunLog { get; set; }
        //public virtual DbSet<DeviceRunLogType> DeviceRunLogType { get; set; }
        //public virtual DbSet<DeviceRunningStatistics> DeviceRunningStatistics { get; set; }
        //public virtual DbSet<DeviceTimeSharingStatistics> DeviceTimeSharingStatistics { get; set; }
        //public virtual DbSet<DeviceType> DeviceType { get; set; }
        //public virtual DbSet<ExceptionSms> ExceptionSms { get; set; }
        //public virtual DbSet<Facility> Facility { get; set; }
        //public virtual DbSet<FacilityCamera> FacilityCamera { get; set; }
        //public virtual DbSet<FacilityCameraPresetPoint> FacilityCameraPresetPoint { get; set; }
        //public virtual DbSet<FacilityCameraRunLog> FacilityCameraRunLog { get; set; }
        //public virtual DbSet<FacilityCameraRunStatistics> FacilityCameraRunStatistics { get; set; }
        //public virtual DbSet<FacilityPics> FacilityPics { get; set; }
        //public virtual DbSet<FacilityProduceInfo> FacilityProduceInfo { get; set; }
        //public virtual DbSet<FacilityType> FacilityType { get; set; }
        //public virtual DbSet<Farm> Farm { get; set; }
        //public virtual DbSet<Log> Log { get; set; }
        ////public virtual DbSet<NewClassByContent> NewClassByContent { get; set; }
        //public virtual DbSet<PictureRep> PictureRep { get; set; }
        //public virtual DbSet<SysArea> SysArea { get; set; }
        //public virtual DbSet<SysDepartment> SysDepartment { get; set; }
        //public virtual DbSet<SysFunction> SysFunction { get; set; }
        //public virtual DbSet<SysMenu> SysMenu { get; set; }
        //public virtual DbSet<SysRole> SysRole { get; set; }
        //public virtual DbSet<SysRoleMenu> SysRoleMenu { get; set; }
        //public virtual DbSet<SysUser> SysUser { get; set; }
        //public virtual DbSet<WeatherDevice> WeatherDevice { get; set; }
        //public virtual DbSet<WeatherDeviceType> WeatherDeviceType { get; set; }
        //public virtual DbSet<WeatherStation> WeatherStation { get; set; }
        //public virtual DbSet<WeatherStationOnlineStatistics> WeatherStationOnlineStatistics { get; set; }
        //public virtual DbSet<WeatherWarn> WeatherWarn { get; set; }
        //public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        // Unable to generate entity type for table 'dbo.CHANNEL_MAP'. Please see the warning messages. 

        #endregion
    }
}