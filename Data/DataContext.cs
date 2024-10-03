using System;
using BaseApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Data
{
  public class DataContext : IdentityDbContext<IdentityUser>
    {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Goal> Goals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
     
      modelBuilder.Entity<User>().HasKey(e => e.Id);
      modelBuilder.Entity<User>().HasMany(e => e.Posts).WithOne(e => e.User).HasForeignKey(e => e.UserId);

      modelBuilder.Entity<Post>().HasKey(e => e.Id);
      modelBuilder.Entity<Post>().HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.UserId);
    }
  }

}