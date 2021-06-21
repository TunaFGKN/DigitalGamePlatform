using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        IGameDal _gameDal;

        public GameManager(IGameDal gameDal)
        {
            _gameDal = gameDal;
        }

        public IResult Add(Game game)
        {
            _gameDal.Add(game);

            return new SuccessResult(Messages.GameAdded);
        }

        [CacheAspect]
        public IDataResult<List<Game>> GetAll()
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll(), Messages.GamesListed);
        }

        public IDataResult<List<Game>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll(g => g.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Game> GetById(int gameId)
        {
            return new SuccessDataResult<Game>(_gameDal.Get(g => g.GameId == gameId));
        }

        public IDataResult<List<Game>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll(g => g.GamePrice >= min && g.GamePrice <= max));
        }

        public IResult Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
