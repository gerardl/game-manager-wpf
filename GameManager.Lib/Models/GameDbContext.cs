using GameManager.Lib.Models.Account;
using GameManager.Lib.Models.Base;
using GameManager.Lib.Models.Game;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models
{
    public class GameDbContext : DbContext
    {
        #region Account

        internal DbSet<Account.User> User { get; set; }
        internal DbSet<Account.AccountType> AccountType { get; set; }

        #endregion

        #region Game

        internal DbSet<Game.Mob> Mob { get; set; }
        internal DbSet<Game.Player> Player { get; set; }
        internal DbSet<Game.Race> Race { get; set; }
        
        #endregion

        public GameDbContext(DbContextOptions<GameDbContext> options) 
            : base(options)
        {
        }

        #region Handle IsDeleted & CreatedBy/ModifiedBy & Timestamps
        public override int SaveChanges()
        {
            UpdateAuditData();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditData();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditData()
        {
            ChangeTracker.DetectChanges();

            var changedObjs = ChangeTracker.Entries()
                .Where(i => i.State != EntityState.Unchanged)
                .Where(i => i.Entity is EntityBase);

            if (changedObjs == null || changedObjs.Count() == 0) return;

            // save one time instance so we have consistent times for this
            // whole update set
            var updateTime = DateTime.UtcNow;

            // soft delete all objects with an isdeleted
            foreach (var item in changedObjs.Where(e => e.State == EntityState.Deleted))
            {
                item.State = EntityState.Modified;
                item.CurrentValues["IsDeleted"] = true;
            }

            foreach (var entity in changedObjs)
            {
                var specEntity = (EntityBase)entity.Entity;
                if (specEntity.DateCreated == null || specEntity.DateCreated == DateTime.MinValue) specEntity.DateCreated = updateTime;
                specEntity.DateModified = updateTime;

                //if (string.IsNullOrEmpty(specEntity.CreatedByUserID)) specEntity.CreatedByUserID = currentUser;
                //specEntity.UpdatedByUserID = currentUser;
            }
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var now = DateTime.UtcNow;

            // globally turn off cascade delete. No more conventions in ef, so need to loop types
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // don't return soft deleted items in any query
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProp = entityType.FindProperty("IsDeleted");
                if (isDeletedProp != null && isDeletedProp.ClrType == typeof(bool))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "p");
                    var filter = Expression.Lambda(Expression.Not(Expression.Property(parameter, isDeletedProp.PropertyInfo)), parameter);
                    entityType.SetQueryFilter(filter);
                }
            }

            #region Data Seeding
            
            foreach (AccountTypes type in Enum.GetValues(typeof(AccountTypes)))
            {
                modelBuilder.Entity<AccountType>().HasData(new AccountType
                {
                    Id = (int)type,
                    Name = type.ToString(),
                    IsActive = true,
                    IsDeleted = false
                });
            }
            
            foreach (Races race in Enum.GetValues(typeof(Races)))
            {
                modelBuilder.Entity<Race>().HasData(new Race
                {
                    Id = (int)race,
                    Name = race.ToString(),
                    IsActive = true,
                    IsDeleted = false
                });
            }

            #endregion
        }
    }
}
