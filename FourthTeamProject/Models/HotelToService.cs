﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FourthTeamProject.Models
{
    public partial class HotelToService
    {
        public int HotelId { get; set; }
        public int HotelServiceId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual HotelService HotelService { get; set; }
    }
}