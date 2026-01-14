using Core.Domain.Dto;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ISymbolRepository
    {
        SymbolDTO GetSymbolById(int id);
    }
}
