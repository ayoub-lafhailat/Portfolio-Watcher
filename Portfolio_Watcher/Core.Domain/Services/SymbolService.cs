using Core.Domain.Interfaces;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class SymbolService
    {
        private readonly ISymbolRepository _symbolRepository;

        public SymbolService(ISymbolRepository symbolRepository)
        {
            _symbolRepository = symbolRepository;
        }

        public Symbol GetSymbolById(int symbolId)
        {
            Symbol symbol = new Symbol(_symbolRepository.GetSymbolById(symbolId));
            return symbol;
        }
    }
}
