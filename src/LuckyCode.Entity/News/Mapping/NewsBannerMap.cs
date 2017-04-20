using System;
using System.Collections.Generic;
using LiteCode.Entity.News;
using LiteCode.Core.Data.Extensions;
using LiteCode.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lucky.Entity.News.Mapping
{
    public class NewsBannerMap : EntityMappingConfiguration<NewsBanner>
    {
        public override void Map(EntityTypeBuilder<NewsBanner> b)
        {
            b.HasKey(t => t.Id);
            b.ToTable("NewsBanner");
            b.Property(t => t.Title).IsRequired().HasMaxLength(128).HasColumnName("Title");
            b.Property(t => t.CreateTime).HasColumnName("CreateTime");
            b.Property(t => t.ImageUrl).HasMaxLength(256).HasColumnName("ImageUrl");
            b.Property(t => t.Sort).HasColumnName("Sort");
            b.Property(t => t.Url).HasMaxLength(256).HasColumnName("Url");
            b.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
