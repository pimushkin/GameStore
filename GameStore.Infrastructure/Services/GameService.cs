using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Persistence;

namespace GameStore.Infrastructure.Services
{
    class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICollection<Game>> GetListOfAllGamesAsync()
        {
            return await _unitOfWork.GetRepository<Game>().GetAllAsync();
        }
    }
}
