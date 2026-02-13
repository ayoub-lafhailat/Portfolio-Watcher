using Core.Data.Exceptions;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using UnitTest;
using Core.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{

    public class SaveTradeUnitTest
    {
        public Portfolio portfolioTestObject;
        public Symbol symbolTestObject;
        //ik moet die tradeservice die mock repository geven
        public TradeService tradeService;

        public SaveTradeUnitTest()
        {
            // Setup test objects
            portfolioTestObject = new Portfolio(1, "TestPortfolio", "Portfolio test description", 100.00, 200.00);
            symbolTestObject = new Symbol(1, "Apple", "AAPL", 1.50);
        }

        [Fact]
        public void GivenAValidTrade_WhenSavingTrade_SavesTradeInRepository()
        {
            // Arrange
            MockSaveTrade mockRepo = new MockSaveTrade();
            TradeService tradeService = new TradeService(mockRepo);

            Trade trade = new Trade(symbolTestObject, 10.0, 15.0, 10, portfolioTestObject);

            // Act
            tradeService.SaveTrade(trade);

            // Assert
            Assert.NotEmpty(mockRepo.SavedTrades);

        }

        [Fact]
        public void GivenNegativeSymbolId_WhenCheckingTrade()
        {

            // Arrange
            symbolTestObject = new Symbol(-1, "Apple", "AAPL", 1.50);
            Trade trade = new Trade(symbolTestObject, 10.0, 15.0, 10, portfolioTestObject);

            //Act
            var exception = Assert.Throws<TradeServiceFixableException>(() =>
                tradeService.SaveTrade(trade)
            );

            //Assert
            Assert.Equal("SymbolId bestaat niet of is ongeldig.", exception.Message);

        }

        [Fact]
        public void GivenATradeWithoutPortfolioId_WhenSavingTrade_ThrowsTradeServiceFixableException()
        {
            // Arrange
            Portfolio portfolioWithoutId = new Portfolio("TestPortfolio", "Description");
            var trade = new Trade(symbolTestObject, 10.0, 15.0, 10, portfolioWithoutId);

            // Act & Assert
            var exception = Assert.Throws<TradeServiceFixableException>(() =>
                tradeService.SaveTrade(trade)
            );

            Assert.Equal("PortfolioId bestaat niet of is ongeldig.", exception.Message);

        }

        [Fact]
        public void GivenValidTrade_WhenSavingTrade_CreatesCorrectDTO()
        {
            // Arrange
            var trade = new Trade(symbolTestObject, 10.5, 15.75, 20, portfolioTestObject);
            TradeDTO capturedDto = null;

            // Act
            tradeService.SaveTrade(trade);

            // Assert
            Assert.NotNull(capturedDto);
            Assert.Equal(symbolTestObject.SymbolId, capturedDto.SymbolId);
            Assert.Equal(10.5, capturedDto.BuyPrice);
            Assert.Equal(15.75, capturedDto.SellPrice);
            Assert.Equal(20, capturedDto.Shares);
            Assert.Equal(portfolioTestObject.PortfolioId.Value, capturedDto.PortfolioId);
        }



    }
}


