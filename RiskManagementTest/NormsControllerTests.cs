using Microsoft.AspNetCore.Mvc;
using Moq;
using RiskManagementAPI.Controllers;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Tests
{
    public class NormsControllerTests
    {
        private readonly NormsController _controller;
        private readonly Mock<INormService> _mockNormService;

        public NormsControllerTests()
        {
            _mockNormService = new Mock<INormService>();
            _controller = new NormsController(_mockNormService.Object);
        }

        [Fact]
        public async Task GetNorms_ReturnsOkResult_WhenNormsExist()
        {
            // Arrange
            var norms = new List<Norm> { new Norm { NormId = 1 } };
            _mockNormService.Setup(service => service.GetNorms()).ReturnsAsync(norms);

            // Act
            var result = await _controller.GetNorms();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedNorms = Assert.IsAssignableFrom<IEnumerable<Norm>>(okResult.Value);
            Assert.Equal(norms, returnedNorms);
        }

        [Fact]
        public async Task GetNorms_ReturnsNotFound_WhenNormsDoNotExist()
        {
            // Arrange
            _mockNormService.Setup(service => service.GetNorms()).ReturnsAsync((List<Norm>)null);

            // Act
            var result = await _controller.GetNorms();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetNorm_ReturnsOkResult_WhenNormExists()
        {
            // Arrange
            var normId = 1;
            var norm = new Norm { NormId = normId };
            _mockNormService.Setup(service => service.GetNorm(normId)).ReturnsAsync(norm);

            // Act
            var result = await _controller.GetNorm(normId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedNorm = Assert.IsType<Norm>(okResult.Value);
            Assert.Equal(norm, returnedNorm);
        }

        [Fact]
        public async Task GetNorm_ReturnsNotFound_WhenNormDoesNotExist()
        {
            // Arrange
            var normId = 1;
            _mockNormService.Setup(service => service.GetNorm(normId)).ReturnsAsync((Norm)null);

            // Act
            var result = await _controller.GetNorm(normId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutNorm_ReturnsNoContentResult_WhenUpdateSucceeds()
        {
            // Arrange
            var normId = 1;
            var norm = new Norm { NormId = normId };
            _mockNormService.Setup(service => service.UpdateNorm(norm)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.PutNorm(normId, norm);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutNorm_ReturnsBadRequest_WhenNormIdDoesNotMatch()
        {
            // Arrange
            var normId = 1;
            var norm = new Norm { NormId = 2 };

            // Act
            var result = await _controller.PutNorm(normId, norm);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}