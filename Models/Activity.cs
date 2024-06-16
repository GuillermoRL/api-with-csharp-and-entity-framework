using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEntityFramework.Models;

public class Activity
{
    // [Key]
    public Guid ActivityId { get; set; }
    // [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    // [Required]
    // [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Category Category { get; set; }
    // [NotMapped]
    public string Resume { get; set; }
}

public enum Priority{
    low,
    medium,
    hight
}