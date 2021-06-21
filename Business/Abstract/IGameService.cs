using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameService
    {
        IDataResult<List<Game>> GetAll();
        IDataResult<List<Game>> GetAllByCategoryId(int id);
        IDataResult<List<Game>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<Game> GetById(int gameId);
        IResult Add(Game game);
        IResult Update(Game game);
    }
}
