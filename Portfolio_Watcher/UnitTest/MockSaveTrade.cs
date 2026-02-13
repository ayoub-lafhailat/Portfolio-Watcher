using Core.Domain.Interfaces;
using Core.Domain.Models;
using UnitTest;

public class MockSaveTrade : ITradeRepository
{
    public List<TradeDTO> SavedTrades { get; } = new();

    public void SaveTrade(TradeDTO tradeDTO)
    {
        SavedTrades.Add(tradeDTO);
    }

    public List<TradeDTO> GetAllTrades() 
    { 
         throw new NotImplementedException();
    }
}
