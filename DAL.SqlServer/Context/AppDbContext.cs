﻿using Domain.Entities;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace DAL.SqlServer.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Car> Cars { get; set; }
	public DbSet<RefreshToken> RefreshTokens { get; set; }
}