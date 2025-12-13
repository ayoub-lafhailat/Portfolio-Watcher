using Core.Domain.Models;
using Core.Domain.Services;

namespace UnitTest
{
    public class CalculatePositionSizeUnitTest
    {
        [Fact]
        public void GivenAValidTrade_WhenCalculatingPositionSize_ReturnsSharesTimesPrice()
        {
            // Arrange
            var shares = 10;
            var price = 2.5;
            var expectedPositionSize = 25.0;

            Trade trade = new Trade("TEST", price, shares);
            TradeService service = new TradeService();

            // Act - Subject under Test
            double result = service.CalculatePositionSize(trade);

            // Assert
            Assert.Equal(expectedPositionSize, result);
        }

        [Fact]
        public void GivenATradeWithNonPositiveShares_WhenCalculatingPositionSize()
        {
            // Arrange
            var shares = 0;              // of -5, als het maar =< 0 is
            var price = 10.0;

            Trade trade = new Trade("TEST", price, shares);
            TradeService service = new TradeService();

            ArgumentException? caughtException = null;

            // Act
            try
            {
                service.CalculatePositionSize(trade);
            }
            catch (ArgumentException ex)
            {
                caughtException = ex;
            }

            // Assert
            Assert.NotNull(caughtException);
        }


        [Fact]
        public void GivenATradeWithNonPositivePrice_WhenCalculatingPositionSize()
        {
            // Arrange
            var shares = 10;
            var price = 0.0;             // of -1.0, als het maar =< 0 is

            Trade trade = new Trade("TEST", price, shares);
            TradeService service = new TradeService();

            ArgumentException? caughtException = null;

            // Act
            try
            {
                service.CalculatePositionSize(trade);
            }
            catch (ArgumentException ex)
            {
                caughtException = ex;
            }

            // Assert
            Assert.NotNull(caughtException);
        }

    }
}