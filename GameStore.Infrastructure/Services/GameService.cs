using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;

namespace GameStore.Infrastructure.Services
{
    public class GameService : IGameService
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

        public IEnumerable<Game> GetListOfGamesForSinglePage(int pageSize, int page)
        {
            return _unitOfWork.GetRepository<Game>().Filter(orderBy: x =>
                (IOrderedQueryable<Game>) x.OrderBy(g => g.Price).Skip((page - 1) * pageSize).Take(pageSize));
        }

        public int GetCountOfAllGames()
        {
            return _unitOfWork.GetRepository<Game>().Count();
        }
    }
}