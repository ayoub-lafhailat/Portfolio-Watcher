using Core.Domain.Dto;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Moq;

namespace UnitTest
{
    public class CalculatePositionSizeUnitTest
    {
        private readonly Portfolio portfolioTestObject;
        private readonly Symbol symbolTestObject;
        private readonly Mock<ITradeRepository> mockTradeRepository;
        private readonly TradeService tradeService;

        public CalculatePositionSizeUnitTest()
        {
            // Setup test objects
            portfolioTestObject = new Portfolio(1, "TestPortfolio", "Portfolio test description", 100.00, 200.00);
            symbolTestObject = new Symbol(1, "Apple", "AAPL", 1.50);

            // Setup mock repository
            mockTradeRepository = new Mock<ITradeRepository>();

            // Create service with mocked dependency
            tradeService = new TradeService(mockTradeRepository.Object);
        }

        [Fact]
        public void GivenAValidTrade_WhenCalculatingPositionSize_ReturnsSharesTimesBuyPrice()
        {
            // Arrange
            int shares = 10;
            double buyPrice = 2.5;
            double sellPrice = 5.0;

            var expectedPositionSize = 25.0;
            Trade trade = new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioTestObject);

            // Act
            double result = trade.PositionSize; // PositionSize is calculated in constructor

            // Assert
            Assert.Equal(expectedPositionSize, result);
        }

        [Fact]
        public void GivenATradeWithNonPositiveShares_WhenCreatingTrade_ThrowsException()
        {
            // Arrange
            var shares = 0;
            var buyPrice = 10.0;
            var sellPrice = 15.0;

            // Act & Assert
            var exception = Assert.Throws<TradeModelException>(() =>
                new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioTestObject)
            );

            Assert.Equal("Shares must be greater than 0.", exception.Message);
        }

        [Fact]
        public void GivenATradeWithNegativeShares_WhenCreatingTrade_ThrowsException()
        {
            // Arrange
            var shares = -5;
            var buyPrice = 10.0;
            var sellPrice = 15.0;

            // Act & Assert
            var exception = Assert.Throws<TradeModelException>(() =>
                new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioTestObject)
            );

            Assert.Equal("Shares must be greater than 0.", exception.Message);
        }

        [Fact]
        public void GivenATradeWithNonPositiveBuyPrice_WhenCreatingTrade_ThrowsException()
        {
            // Arrange
            var shares = 10;
            var buyPrice = 0.0;
            var sellPrice = 15.0;

            // Act & Assert
            var exception = Assert.Throws<TradeModelException>(() =>
                new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioTestObject)
            );

            Assert.Equal("BuyPrice must be greater than 0.", exception.Message);
        }

        [Fact]
        public void GivenATradeWithNonPositiveSellPrice_WhenCreatingTrade_ThrowsException()
        {
            // Arrange
            var shares = 10;
            var buyPrice = 10.0;
            var sellPrice = 0.0;

            // Act & Assert
            var exception = Assert.Throws<TradeModelException>(() =>
                new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioTestObject)
            );

            Assert.Equal("SellPrice must be greater than 0.", exception.Message);
        }

        [Fact]
        public void GivenAValidTradeDto_WhenConstructingTrade_PositionSizeIsSharesTimesBuyPrice()
        {
            // Arrange
            var portfolio = new Portfolio(1, "TestPortfolio", "Desc", equity: 100, balance: 200);
            var symbol = new Symbol(1, "Apple", "AAPL", 1.50);

            // Use constructor instead of object initializer since properties have private setters
            var dto = new TradeDTO(
                id: 1,
                symbolId: 1,
                buyPrice: 2.5,
                sellPrice: 5.0,
                shares: 10,
                portfolioId: 1
            );

            var expectedPositionSize = 25.0;
            var expectedProfitLoss = 25.0; // (5.0 - 2.5) * 10

            // Act
            var trade = new Trade(dto, symbol, portfolio);

            // Assert
            Assert.Equal(expectedPositionSize, trade.PositionSize, 6);
            Assert.Equal(expectedProfitLoss, trade.ProfitLoss, 6);
        }

        [Fact]
        public void GivenAValidTrade_WhenCalculatingProfitLoss_ReturnsCorrectValue()
        {
            // Arrange
            int shares = 10;
            double buyPrice = 2.5;
            double sellPrice = 5.0;

            var expectedProfitLoss = 25.0; // (5.0 - 2.5) * 10
            Trade trade = new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioTestObject);

            // Act
            double result = trade.ProfitLoss;

            // Assert
            Assert.Equal(expectedProfitLoss, result);
        }

        [Fact]
        public void GivenATradeWithoutPortfolioId_WhenCreatingTrade_ThrowsException()
        {
            // Arrange
            var portfolioWithoutId = new Portfolio("TestPortfolio", "Description");
            var shares = 10;
            var buyPrice = 10.0;
            var sellPrice = 15.0;

            // Act & Assert
            var exception = Assert.Throws<TradeModelException>(() =>
                new Trade(symbolTestObject, buyPrice, sellPrice, shares, portfolioWithoutId)
            );

            Assert.Equal("Trade cannot be created without a persisted Portfolio.", exception.Message);
        }
    }
}