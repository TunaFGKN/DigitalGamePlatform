using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [ValidationAspect(typeof(GameValidator))]
        [CacheRemoveAspect("IGameService.Get")]
        public IResult Add(Game game)
        {
            IResult result = BusinessRules.Run(CheckIfGameNameExists(game.GameName));

            if (result != null)
            {
                return result;
            }

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
            _gameDal.Update(game);
            return new SuccessResult(Messages.GameUpdated);
        }

        public IResult Delete(Game game)
        {
            _gameDal.Delete(game);
            return new SuccessResult(Messages.GameDeleted);
        }

        private IResult CheckIfGameNameExists(string gameName)
        {
            var result = _gameDal.GetAll(g => g.GameName == gameName).Any();
            if (result)
            {
                return new ErrorResult(Messages.GameNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
