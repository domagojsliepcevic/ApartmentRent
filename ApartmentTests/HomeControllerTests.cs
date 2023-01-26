using ApartmentRent.Controllers;
using ApartmentRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;


namespace ApartmentRent.Test
{
    public class HomeControllerTests
    {
        // arrange
        private static bool added = false;
        private readonly HomeController _controller;
        private readonly List<Apartment> _apartments;
        private readonly DbContextOptions<DatabaseContext> _options; public HomeControllerTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase("MyDb")
            .Options;             // Arrange
            _apartments = new List<Apartment> {
                         new Apartment { ApartmentId = 1, NameEng = "Apartment 1", Name = "Apartman 1", ShortDescription = "Short Description 1" },
                         new Apartment { ApartmentId = 2, NameEng = "Apartment 2", Name = "Apartman 2", ShortDescription = "Short Description 2" },
                         new Apartment { ApartmentId = 3, NameEng = "Apartment 3", Name = "Apartman 3", ShortDescription = "Short Description 3" },
         };
            var context = new DatabaseContext(_options);
            if (!added)
            {
                added = true;
                context.Apartment.AddRange(_apartments);
                context.SaveChanges();
            }
            _controller = new HomeController(context);
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            
            // act
            var result = _controller.Index();    
            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
