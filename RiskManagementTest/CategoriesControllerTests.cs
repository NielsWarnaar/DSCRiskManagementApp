using Moq;
using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Controllers;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Tests;

public class CategoriesControllerTests
{
    private readonly Mock<ICategoryService> _mockCategoryService;
    private readonly CategoriesController _controller;

    public CategoriesControllerTests()
    {
        _mockCategoryService = new Mock<ICategoryService>();
        _controller = new CategoriesController(_mockCategoryService.Object);
    }

    [Fact]
    public async Task GetCategories_ReturnsOkResultWithCategories()
    {
        // Arrange
        var categories = new List<Category> { new Category { CategoryId = 1, CategoryName = "Category 1" } };
        _mockCategoryService.Setup(service => service.GetCategories()).ReturnsAsync(categories);

        // Act
        var result = await _controller.GetCategories();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedCategories = Assert.IsType<List<Category>>(okResult.Value);
        Assert.Equal(categories, returnedCategories);
    }

    [Fact]
    public async Task GetCategories_ReturnsNotFoundResult()
    {
        // Arrange
        _mockCategoryService.Setup(service => service.GetCategories()).ReturnsAsync((List<Category>)null);

        // Act
        var result = await _controller.GetCategories();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetCategory_WithValidId_ReturnsOkResultWithCategory()
    {
        // Arrange
        var category = new Category { CategoryId = 1, CategoryName = "Category 1" };
        _mockCategoryService.Setup(service => service.GetCategoryById(category.CategoryId)).ReturnsAsync(category);

        // Act
        var result = await _controller.GetCategory(category.CategoryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedCategory = Assert.IsType<Category>(okResult.Value);
        Assert.Equal(category, returnedCategory);
    }

    [Fact]
    public async Task GetCategory_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        var categoryId = 1;
        _ = _mockCategoryService.Setup(service => service.GetCategoryById(categoryId)).ReturnsAsync((Category)null);

        // Act
        var result = await _controller.GetCategory(categoryId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PutCategory_WithValidIdAndMatchingCategory_ReturnsNoContentResult()
    {
        // Arrange
        var categoryId = 1;
        var category = new Category { CategoryId = categoryId, CategoryName = "Updated Category" };
        _mockCategoryService.Setup(service => service.CategoryExists(categoryId)).ReturnsAsync(true);

        // Act
        var result = await _controller.PutCategory(categoryId, category);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task PutCategory_WithInvalidId_ReturnsBadRequestResult()
    {
        // Arrange
        var categoryId = 1;
        var category = new Category { CategoryId = 2, CategoryName = "Updated Category" };

        // Act
        var result = await _controller.PutCategory(categoryId, category);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
}