using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GameDetailDto: IDto
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string CategoryName { get; set; }
        public decimal GamePrice { get; set; }
    }
}
