using Domain.Entities;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options), IApplicationDbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Lecture> Lectures => Set<Lecture>();
}
