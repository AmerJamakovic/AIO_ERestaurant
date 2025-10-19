namespace Market.Domain.Entities.Catalog;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Market.Domain.Common;

public class ProductCategoryEntity : BaseEntity
{
    [Required]
    [StringLength(256)]
    public required string Name { get; set; }

    public bool IsEnabled { get; set; } = true;

    // Navigation
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    // Validation / constraints used by Application validators
    public static class Constraints
    {
        public const int NameMaxLength = 256;
    }
}
