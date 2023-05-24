﻿using FourthTeamProject.Models;
using FourthTeamProject.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourthTeamProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetHotelAPIController : ControllerBase
    {
        private readonly PetHeavenDbContext petHeavenDb;

        public PetHotelAPIController(PetHeavenDbContext petHeavenDb)
        {
            this.petHeavenDb = petHeavenDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var petHotelDB = petHeavenDb.Hotel.ToList();
            var petHotelList = petHotelDB.Select(data => new PetHotelViewModel()
            {
                ID = data.HotelId,
                CatagoryID = data.HotelCatagoryId,
                HotelName = data.HotelName,
                UnitPrice = data.UnitPrice,
                HotelContent = data.HotelContent,
                HotelContentDetail = data.HotelContentDetail,
                HotelImage = data.HotelImage,
            });


            return Ok(petHotelList);
        }


        //public IActionResult getRoomDataById(int roomId)
        //{

        //}
    }
}
