using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GameDeveloper: IEntity
    {
        public int GameDeveloperId { get; set; }
        public string CompanyName { get; set; }
        public int GameAmount { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
