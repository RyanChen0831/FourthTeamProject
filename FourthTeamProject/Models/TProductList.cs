﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FourthTeamProject.Models
{
    public partial class TProductList
    {
        public int CProductId { get; set; }
        public int CProductTypeId { get; set; }
        public int CProductUsage { get; set; }
        public string CProductName { get; set; }
        public string CProductSpecification { get; set; }
        public string CProductContent { get; set; }
        public int CUnitPrice { get; set; }
        public int CStock { get; set; }
        public double? CProductRating { get; set; }

        public virtual TProductUsage CProduct { get; set; }
        public virtual TProductOrderDetail TProductOrderDetail { get; set; }
        public virtual TProductType TProductType { get; set; }
    }
}