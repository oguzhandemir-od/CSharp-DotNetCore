using Moq;
using ProductStockManagement.Entities;
using ProductStockManagement.Interfaces;
using ProductStockManagement.Services;

namespace ProductStockManagement.Tests;

public class ProductServiceTests
{
    [Fact]
    public void SellProduct_WhenStockIsSufficient_ShouldDecreaseStockAndNotSetCritical()
    {
        var mockRepository = new Mock<IProductRepository>();

        var fakeProduct = new Product(id: 1, name: "Laptop", stockQuantity: 10);

        mockRepository.Setup(repo=>repo.GetById(1)).Returns(fakeProduct);

        var productService = new ProductService(mockRepository.Object);

        productService.SellProduct(1, 3);

        Assert.Equal(7, fakeProduct.StockQuantity);
        Assert.False(fakeProduct.IsCriticalStock);

        mockRepository.Verify(repo => repo.Update(fakeProduct),Times.Once);
    }

    [Fact]
    public void SellProduct_WhenStockDropsBelowThreshold_ShouldSetCriticalStockToTrue()
    {
        var mockRepository = new Mock<IProductRepository>();

        var fakeProduct = new Product(2, "Akıllı Telefon", 6);

        mockRepository.Setup(repo=>repo.GetById(2)).Returns(fakeProduct);

        var productService= new ProductService(mockRepository.Object);

        productService.SellProduct(2, 2);

        Assert.Equal(4, fakeProduct.StockQuantity);
        Assert.True(fakeProduct.IsCriticalStock);

        mockRepository.Verify(repo=>repo.Update(fakeProduct), Times.Once);
    }

    [Fact]
    public void SellProduct_WhenStockIsNotSufficient_ShouldThrowInvalidException()
    {
        var mockRepository = new Mock<IProductRepository>();

        var fakeProduct = new Product(3, "Tablet", 3);

        mockRepository.Setup(repo => repo.GetById(3)).Returns(fakeProduct);

        var productService = new ProductService(mockRepository.Object);

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            productService.SellProduct(3, 5);
        });

        Assert.Equal("Yetersiz stok! İşlem gerçekleştirilemedi.",exception.Message);

        Assert.Equal(3, fakeProduct.StockQuantity);

        mockRepository.Verify(repo => repo.Update(It.IsAny<Product>()), Times.Never);

    }
}
