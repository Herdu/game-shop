using MateuszDobrowolski.UI.Helpers;
using MateuszDobrowolski.UI.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameListViewModel: BaseViewModel
    {
        public ObservableCollection<GameListItemViewModel> Games { get; set; } = new ObservableCollection<GameListItemViewModel>();
        public ObservableCollection<SelectOption> ProducerSelectOptions { get; set; } = new ObservableCollection<SelectOption>();
        public RelayCommand ShowGameDetailsCommand { get; }
        public RelayCommand EditGameCommand { get; }
        public RelayCommand NewGameCommand { get; }
        public RelayCommand FilterCommand { get; }
        public RelayCommand ResetFilterCommand { get; }
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

        public string FilterName {
            get => _filterName;
            set {
                _filterName = value;
                OnPropertyChanged("FilterName");
            }
        }

        public GameListViewModel()
        {
            GetGames();
            OnPropertyChanged("Games");
            InitProducerOptions();
            OnPropertyChanged("ProducerSelectOptions");
            ShowGameDetailsCommand = new RelayCommand(param => GoToPage(new GameDetailsView((param as GameListItemViewModel).ID)));
            FilterCommand = new RelayCommand(param => GetGames());
            ResetFilterCommand = new RelayCommand(param => ResetFilters());
            EditGameCommand = new RelayCommand(param => GoToPage(new GameFormView((param as GameListItemViewModel).ID)));
            NewGameCommand = new RelayCommand(param => GoToPage(new GameFormView(null)));
        }

        private void InitProducerOptions()
        {
            ProducerSelectOptions.Add(new SelectOption() { Name = "All", Value = -1 });

            foreach(var producer in (BLC.BLC.DAO.GetAllProducers()).OrderBy(x => x.Name))
            {
                ProducerSelectOptions.Add(new SelectOption() { Name=producer.Name, Value=producer.ID });
            }
        }

        private void GetGames()
        {
            Games.Clear();
            string name = FilterName ?? "";
            int producerId =  FilterProducer is null ? -1 : FilterProducer.Value;

            foreach (var game in BLC.BLC.DAO.GetGames(name, producerId))
            {
                Games.Add(new GameListItemViewModel(game));
            }
        }

        private void ResetFilters()
        {
            FilterProducer = ProducerSelectOptions[0];
            FilterName = "";
        }
    }
}
