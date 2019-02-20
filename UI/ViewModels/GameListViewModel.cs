using MateuszDobrowolski.Core;
using MateuszDobrowolski.UI.Helpers;
using MateuszDobrowolski.UI.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameListViewModel: BaseViewModel
    {
        public ObservableCollection<GameListItemViewModel> Games { get; set; } = new ObservableCollection<GameListItemViewModel>();
        public ObservableCollection<SelectOption> ProducerSelectOptions { get; set; } = new ObservableCollection<SelectOption>();
        public ObservableCollection<SelectOption> GameTypeSelectOptions { get; set; } = new ObservableCollection<SelectOption>();
        public RelayCommand ShowGameDetailsCommand { get; }
        public RelayCommand EditGameCommand { get; }
        public RelayCommand NewGameCommand { get; }
        public RelayCommand FilterCommand { get; }
        public RelayCommand ResetFilterCommand { get; }
        public RelayCommand DeleteGameCommand { get; }
        private SelectOption _filterProducer;

        public SelectOption FilterProducer
        {
            get => _filterProducer;
            set
            {
                _filterProducer = value;
               OnPropertyChanged("FilterProducer");
            }
        }

        private string _filterName;

        public string FilterName 
        {
            get => _filterName;
            set {
                _filterName = value;
                OnPropertyChanged("FilterName");
            }
        }

        private SelectOption _filterGameType;

        public SelectOption FilterGameType
        {
            get => _filterGameType;
            set
            {
                _filterGameType = value;
                OnPropertyChanged("FilterGameType");
            }
        }

        public GameListViewModel()
        {
            GetGames();
            InitProducerOptions();
            InitGameTypeOptions();
            ShowGameDetailsCommand = new RelayCommand(param => GoToPage(new GameDetailsView((param as GameListItemViewModel).ID)));
            FilterCommand = new RelayCommand(param => GetGames());
            ResetFilterCommand = new RelayCommand(param => ResetFilters());
            EditGameCommand = new RelayCommand(param => GoToPage(new GameFormView((param as GameListItemViewModel).ID)));
            DeleteGameCommand = new RelayCommand(param => DeleteGame((param as GameListItemViewModel).ID));
            NewGameCommand = new RelayCommand(param => GoToPage(new GameFormView(null)));
        }

        private void InitProducerOptions()
        {
            ProducerSelectOptions.Add(new SelectOption() { Name = "All", Value = -1 });

            foreach(var producer in (BLC.BLC.DAO.GetAllProducers()).OrderBy(x => x.Name))
            {
                ProducerSelectOptions.Add(new SelectOption() { Name=producer.Name, Value=producer.ID });
            }
            OnPropertyChanged("ProducerSelectOptions");
        }

        private void InitGameTypeOptions()
        {
            GameTypeSelectOptions.Add(new SelectOption() { Name = "All", Value = -1 });

            var values = Enum.GetValues(typeof(GameType));
            var types = values.Cast<GameType>();

            foreach (var type in types)
            {
                GameTypeSelectOptions.Add(new SelectOption() { Name = type.ToString(), Value = (int)type });
            }
            OnPropertyChanged("GameTypeSelectOptions");
        }

        private void GetGames()
        {
            Games.Clear();
            string name = FilterName ?? "";
            int producerId =  FilterProducer is null ? -1 : FilterProducer.Value;
            int gameType = FilterGameType is null ? -1 : FilterGameType.Value;

            foreach (var game in BLC.BLC.DAO.GetGames(name, producerId, gameType))
            {
                Games.Add(new GameListItemViewModel(game));
            }
            OnPropertyChanged("Games");
        }

        private void ResetFilters()
        {
            FilterProducer = ProducerSelectOptions[0];
            OnPropertyChanged("ProducerSelectOptions");
            FilterGameType = GameTypeSelectOptions[0];
            FilterName = "";
            GetGames();
        }

        private void DeleteGame(int gameId)
        {
            BLC.BLC.DAO.DeleteGame(gameId);
            Games = new ObservableCollection<GameListItemViewModel>(Games.Where(o => o.ID != gameId));
            OnPropertyChanged("Games");
        }
    }
}
