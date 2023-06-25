using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Controllers;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RiskManagementAPI.Tests
{
    public class ControlsControllerTests
    {
        private ControlsController _controller;
        private Mock<IControlService> _mockControlService;

        public ControlsControllerTests()
        {
            _mockControlService = new Mock<IControlService>();
            _controller = new ControlsController(_mockControlService.Object);
        }

        [Fact]
        public async Task GetControls_ReturnsOkResult()
        {
            // Arrange
            var controls = new List<Control>()
            {
                new Control { ControlId = 1, ControlName = "Control 1" },
                new Control { ControlId = 2, ControlName = "Control 2" }
            };
            _mockControlService.Setup(s => s.GetControls()).ReturnsAsync(controls);

            // Act
            var result = await _controller.GetControls();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedControls = Assert.IsAssignableFrom<IEnumerable<Control>>(okResult.Value);
            Assert.Equal(2, returnedControls.Count());
        }

        [Fact]
        public async Task GetControl_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var control = new Control { ControlId = 1, ControlName = "Control 1" };
            _mockControlService.Setup(s => s.GetControlById(1)).ReturnsAsync(control);

            // Act
            var result = await _controller.GetControl(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedControl = Assert.IsType<Control>(okResult.Value);
            Assert.Equal(control.ControlId, returnedControl.ControlId);
        }

        [Fact]
        public async Task GetControl_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _ = _mockControlService.Setup(s => s.GetControlById(1)).ReturnsAsync((Control)null);

            // Act
            var result = await _controller.GetControl(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutControl_WithValidIdAndMatchingControl_ReturnsNoContentResult()
        {
            // Arrange
            var control = new Control { ControlId = 1, ControlName = "Control 1" };

            // Act
            var result = await _controller.PutControl(1, control);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutControl_WithInvalidIdAndMatchingControl_ReturnsBadRequestResult()
        {
            // Arrange
            var control = new Control { ControlId = 1, ControlName = "Control 1" };

            // Act
            var result = await _controller.PutControl(2, control);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}