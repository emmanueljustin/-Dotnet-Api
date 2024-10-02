using System;
using BaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasKey(e => e.Id);
      modelBuilder.Entity<User>().HasMany(e => e.Posts).WithOne(e => e.User).HasForeignKey(e => e.UserId);

      modelBuilder.Entity<Post>().HasKey(e => e.Id);
      modelBuilder.Entity<Post>().HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.UserId);
    }
  }

}