﻿using MateuszDobrowolski.Core;
using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.Helpers;
using MateuszDobrowolski.UI.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameFormViewModel : BaseViewModel
    {
        private IGame _game;

        public bool IsNew
        {
            get;
        }

        public ObservableCollection<IProducer> Producers { get; }
        public ObservableCollection<SelectOption> GameTypeSelectOptions { get; } = new ObservableCollection<SelectOption>();

        public string FormTitle
        {
            get => IsNew ? "New game" : "Edit game";
        }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 30 letters")]
        public string Name
        {
            get => _game.Name;
            set
            {
                _game.Name = value;
                Validate();
                OnPropertyChanged("Name");
            } 
        }
        [Required(ErrorMessage = "Producer is required")]
        public IProducer Producer
        {
            get => _game.Producer;
            set
            {
                _game.Producer = value;
                Validate();
                OnPropertyChanged("Producer");
            }
        }
        [Required(ErrorMessage = "Game type is required")]
        public SelectOption GameType
        {
            get {
                GameType gameType = _game.Type;
                return GameTypeSelectOptions.First(o => o.Value == (int)gameType);
            }

            set
            {
                SelectOption selected = value;
                _game.Type = (GameType)selected.Value;
                Validate();
                OnPropertyChanged("GameType");
            }
        }

        private string _priceInput;

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\s*(?=.*[1-9])\d*(?:\,\d{1,2})?\s*$", ErrorMessage = "Price must be a valid positive number (with max. 2 decimal places)")]

        public string Price
        {
            get => _priceInput;
            set {
                 _priceInput = value;
                decimal.TryParse(value, out decimal d);
                _game.Price = d;
                Validate();
                OnPropertyChanged("Price");
            }
        }

        [Required(ErrorMessage = "Price is required")]
        [Range(typeof(DateTime), "1/1/1950", "1/1/2099", ErrorMessage = "Date is out of Range")]

        public DateTime ReleaseDate
        {
            get => _game.ReleaseDate;
            set
            {
                _game.ReleaseDate = value;
                Validate();
                OnPropertyChanged("ReleaseDate");
            }
        }

        public RelayCommand GoToListCommand { get; }
        public RelayCommand SaveGameCommand { get; }

        public GameFormViewModel(int? gameId)
        {
            if(gameId.HasValue)
            {
                IsNew = false;
                _game = BLC.BLC.DAO.GetGameById(gameId.Value);
            }
            else
            {
                IsNew = true;
                _game = BLC.BLC.DAO.NewGame();
            }
            _priceInput = _game.Price.ToString();

            Producers = new ObservableCollection<IProducer>(BLC.BLC.DAO.GetAllProducers());
            GoToListCommand = new RelayCommand(param => GoToList());
            SaveGameCommand = new RelayCommand(param => Save(), param=> CanSave());
            InitGameTypeOptions();
            Validate();
        }

        private void InitGameTypeOptions()
        {
            var values = Enum.GetValues(typeof(GameType));
            var types = values.Cast<GameType>();

            foreach (var type in types)
            {
                GameTypeSelectOptions.Add(new SelectOption() { Name = type.ToString(), Value = (int)type });
            }
            OnPropertyChanged("GameTypeSelectOptions");
        }

        private void GoToList()
        {
            GoToPage(new GameListView());
        }

        private void Save()
        {
            BLC.BLC.DAO.SaveGame(_game);
            GoToPage(new GameDetailsView(_game.ID));
        }

        private bool CanSave()
        {
            Validate();
            return !HasErrors;
        }
    }
}
