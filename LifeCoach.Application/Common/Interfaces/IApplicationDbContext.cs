using LifeCoach.Domain;
using Microsoft.EntityFrameworkCore;


namespace LifeCoach.Application;

public interface IApplicationDbContext
{
    
        DbSet <MealPlanOrder> MealPlanOrders { get; set; }

        DbSet<UserBalance> UserBalances { get; set; }

        DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    

}
