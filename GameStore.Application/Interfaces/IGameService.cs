using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Application.Interfaces
{
    public interface IGameService
    {
        Task<ICollection<Game>> GetListOfAllGamesAsync();
    }
}
