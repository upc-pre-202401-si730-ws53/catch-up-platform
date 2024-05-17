using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/**
 * <summary>
 * Extension method to use snake case naming convention.
 * </summary>
 */
public static class ModelBuilderExtensions
{
    /**
     * <summary>
     * Use snake case naming convention.
     * This method will convert the table name, column names, key names, foreign key constraint names, and index names to snake case.
     * </summary>
     * <param name="builder">The model builder.</param>
     */
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName)) entity.SetTableName(tableName.ToSnakeCase());

            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyConstraintName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyConstraintName))
                    foreignKey.SetConstraintName(foreignKeyConstraintName.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName)) index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
            }
        }
    } 
}