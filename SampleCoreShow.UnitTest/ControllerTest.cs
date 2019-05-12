using BusinessLayer;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using SampleCoreShow.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace SampleCoreShow.UnitTest
{
    public class ControllerTest
    {
        private readonly Mock<IBusiness> _business;
        private readonly StudentController _controller;

        public ControllerTest()
        {
            _business = new Mock<IBusiness>();
            _controller = new StudentController(_business.Object);
        }
        [Fact]
        public void Get_Returns_Ok_Students()
        {
            //Arrange
            var expectedStudent = new Student
            {
                ID = 1, Name = "test", Grade = "A", DeptName = "testDept", DeptLoc = "Ind"
            };
            _business.Setup(x => x.getStudents()).Returns(new List<Student> { expectedStudent });

            //Act
            var response = _controller.Get();

            //Assert
            Assert.NotNull(response);
            var result = Assert.IsType<OkObjectResult>(response);
            var resultData = Assert.IsType<List<Student>>(result.Value);
            Assert.Single(resultData);
            Assert.Equal(JsonConvert.SerializeObject(expectedStudent), JsonConvert.SerializeObject(resultData[0]));
        }

        [Fact]
        public void Get_Returns_500_Error()
        {
            //Arrange
            _business.Setup(x => x.getStudents()).Throws(new Exception());

            //Act
            var response = _controller.Get();

            //Assert
            Assert.NotNull(response);
            var result = Assert.IsType<StatusCodeResult>(response);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
