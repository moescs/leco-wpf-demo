namespace WpfFirmwareDemo.ViewModel
{
    using System.Windows.Media;

    class ItemViewModel
    {
        #region fields

        #endregion

        #region constructors

        public ItemViewModel(
            string name,
            Color color,
            int position)
        {
            Color = color;
            Name = name;
            Position = position;
        }

        #endregion

        #region properties

        public Color Color { get; }
        public string Name { get; }

        public int Position { get; }

        #endregion

        #region methods

        #endregion
    }
}
