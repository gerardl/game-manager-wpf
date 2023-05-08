using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.UI.ViewModels
{
    internal abstract class BaseViewModel
    {
        private readonly IGameService _gameService;
        public BaseViewModel(IGameService gameService)
        {
            _gameService = gameService;
        }
    }
}
