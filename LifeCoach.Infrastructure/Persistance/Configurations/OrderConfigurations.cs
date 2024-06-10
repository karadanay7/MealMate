using System.Text.Json;
using LifeCoach.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeCoach.Infrastructure;

public class OrderConfigurations : IEntityTypeConfiguration<MealPlanOrder>
{
    public void Configure(EntityTypeBuilder<MealPlanOrder> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Weight).IsRequired();
        builder.Property(x => x.Height).IsRequired();
        builder.Property(x => x.Age).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.MealPreference).IsRequired();
        builder.Property(x => x.ActivityLevel).IsRequired();
        builder.Property(x => x.Goal).IsRequired();
        builder.Property(x => x.Allergies).HasMaxLength(100);
        builder.Property(x => x.Disorders).HasMaxLength(100);
        builder.Property(e => e.MealPlanResponses)
     .HasConversion(
         v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
         v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
         new ValueComparer<List<string>>(
             (c1, c2) => c1.SequenceEqual(c2),
             c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v != null ? v.GetHashCode() : 0)),
             c => c.ToList()));


            // Common Properties

            // CreatedDate
            builder.Property(x => x.CreatedOn).IsRequired();

            // CreatedByUserId
            builder.Property(user => user.CreatedByUserId)
                .HasMaxLength(100)
                .IsRequired();

            // ModifiedDate
            builder.Property(user => user.ModifiedOn)
                .IsRequired(false);

            // ModifiedByUserId
            builder.Property(user => user.ModifiedByUserId)
                .HasMaxLength(100)
                .IsRequired(false);

            // Relationships
            //builder.HasOne<User>(x => x.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(x => x.UserId);

            builder.ToTable("MealPlanOrders");

    }

}

