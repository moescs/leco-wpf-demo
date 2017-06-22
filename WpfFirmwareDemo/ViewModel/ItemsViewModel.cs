namespace WpfFirmwareDemo.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Media;
    using WpfFirmwareDemo.WpfHelpers;

    class ItemsViewModel: ViewModelBase
    {
        #region fields

        readonly ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
        readonly Random _random = new Random(666);
        ItemViewModel _selected;

        #endregion

        #region constructors

        public ItemsViewModel()
        {
            ResetCommand = new RelayCommand(Reset);
            RemoveCommand = new RelayCommand(Remove, CanRemove);
            Reset();
        }

        #endregion

        #region properties

        public ICommand ResetCommand { get; }
        public ICommand RemoveCommand { get; }

        public IList<ItemViewModel> Things => _items;

        public ItemViewModel Selected
        {
            get => _selected;
            set
            {
                if (_selected == value)
                    return;
                _selected = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region methods

        void Reset()
        {
            Selected = null;

            _items.Clear();
            _items.Add(new ItemViewModel("J", Colors.Red, 1));
            _items.Add(new ItemViewModel("E", Colors.Orange, 2));
            _items.Add(new ItemViewModel("L", Colors.Yellow, 3));
            _items.Add(new ItemViewModel("L", Colors.Green, 4));
            _items.Add(new ItemViewModel("O", Colors.Blue, 5));
        }

        void Remove()
        {
            if (!CanRemove()) return;

            var index = _random.Next(_items.Count);
            var item = _items[index];
            _items.RemoveAt(index);
            if (item == Selected)
                Selected = null;
        }

        bool CanRemove() => _items.Count != 0;

        #endregion
    }
}
