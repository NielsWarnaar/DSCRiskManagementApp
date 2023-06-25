using Moq;
using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Tests
{
    public class RiskServiceTests
    {
        private readonly Mock<IRiskRepository> _mockRiskRepository;
        private readonly Mock<IRiskHistoryRepository> _mockRiskHistoryRepository;
        private readonly RiskService _riskService;

        public RiskServiceTests()
        {
            _mockRiskRepository = new Mock<IRiskRepository>();
            _mockRiskHistoryRepository = new Mock<IRiskHistoryRepository>();
            _riskService = new RiskService(_mockRiskRepository.Object, _mockRiskHistoryRepository.Object);
        }

        [Fact]
        public async Task GetRisks_ReturnsRisks()
        {
            // Arrange
            var expectedRisks = new List<Risk> { new Risk { RiskId = 1, RiskName = "Risk 1" }, new Risk { RiskId = 2, RiskName = "Risk 2" } };
            _mockRiskRepository.Setup(repo => repo.GetRisks()).ReturnsAsync(expectedRisks);

            // Act
            var result = await _riskService.GetRisks();

            // Assert
            Assert.Equal(expectedRisks, result);
        }

        [Fact]
        public async Task GetRiskById_ReturnsRisk()
        {
            // Arrange
            int riskId = 1;
            var expectedRisk = new Risk { RiskId = riskId, RiskName = "Risk 1" };
            _mockRiskRepository.Setup(repo => repo.GetRiskByID(riskId)).ReturnsAsync(expectedRisk);

            // Act
            var result = await _riskService.GetRiskById(riskId);

            // Assert
            Assert.Equal(expectedRisk, result);
        }
    }
}