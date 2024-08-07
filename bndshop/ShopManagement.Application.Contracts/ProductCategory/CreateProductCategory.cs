﻿

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Label { get; set; }
        public string Specifications { get; set; }
        public string Description { get;  set; }
        [FileExtentionLimitation(new string[]{ ".jpeg", ".jpg" ,".png"},ErrorMessage = ValidationMessages.InvalidFileFormat)]
        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxFileSize(3*1024*1024,ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public int Code{ get; set; }
        public int Priority { get; set; }
        public int LastProductCode { get; set; }
        public string PictureTitle { get;  set; }
        public long ParentId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get;  set; } 

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
