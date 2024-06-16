using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectEntityFramework.Models;

public class Category
{
    // [Key]
    public Guid CategoryId { get; set; }
    // [Required]
    // [MaxLength(150)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    [JsonIgnore]
    public virtual ICollection<Activity> Activities { get; set; }

}