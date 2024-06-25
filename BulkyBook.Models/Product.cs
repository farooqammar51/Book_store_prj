using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Isbn { get; set; }

    public string? Author { get; set; }

    [DisplayName("List Price")]
    public decimal? ListPrice { get; set; }

    public decimal? Price { get; set; }

    [DisplayName("Price 1-50")]
    public decimal? Price50 { get; set; }

    [DisplayName("Price 51-100")]
    public decimal? Price100 { get; set; }

    [ValidateNever]
    [DisplayName("Product Image")]
    public string? ImageUrl { get; set; }

    [DisplayName("Category")]
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public virtual Category? Category { get; set; }

    [DisplayName("Cover Type")]
    public int? CoverTypeId { get; set; }
    [ForeignKey("CoverTypeId")]
    [ValidateNever]
    public virtual CoverType? CoverType { get; set; }
}
