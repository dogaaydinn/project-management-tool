using Core.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework;

public class EfDbContext : DbContextBase
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}