using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BullkyBookWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    // dong nay de khi ma co asp-for thi tu dong lay ten feild co trong Model luon, tag helper hay vcl :)
    [DisplayName("Display Order")]
    [Range(0, 100, ErrorMessage = "Display Order must be between 0 and 100")]
    public int DisplayOrder { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;

}