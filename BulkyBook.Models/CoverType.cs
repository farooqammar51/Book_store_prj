using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

public partial class CoverType
{
    public int Id { get; set; }

    [Required]
    [DisplayName("Cover Type")]
    public string Name { get; set; } = null!;

}
