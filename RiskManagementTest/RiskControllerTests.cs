using Microsoft.AspNetCore.Mvc;
using Moq;
using RiskManagementAPI.Controllers;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Tests
{
    public class RisksControllerTests
    {
        [Fact]
        public async Task GetRisks_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IRiskService>();
            var risks = new List<Risk> { new Risk { RiskId = 1, RiskName = "Risk 1" } };
            mockService.Setup(service => service.GetRisks()).ReturnsAsync(risks);
            var controller = new RisksController(mockService.Object);

            // Act
            var result = await controller.GetRisks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Risk>>(okResult.Value);
            Assert.Equal(risks, model);
        }

        [Fact]
        public async Task GetRisk_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IRiskService>();
            var risk = new Risk { RiskId = 1, RiskName = "Risk 1" };
            mockService.Setup(service => service.GetRiskById(1)).ReturnsAsync(risk);
            var controller = new RisksController(mockService.Object);

            // Act
            var result = await controller.GetRisk(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<Risk>(okResult.Value);
            Assert.Equal(risk, model);
        }

        [Fact]
        public async Task GetRisk_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IRiskService>();
            _ = mockService.Setup(service => service.GetRiskById(1)).ReturnsAsync((Risk)null);
            var controller = new RisksController(mockService.Object);

            // Act
            var result = await controller.GetRisk(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        // Add more unit tests for other actions in the RisksController
        // such as GetRiskByCategoryId, PutRisk, PostRisk, and DeleteRisk.
    }
}