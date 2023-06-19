using _09_shulte_table.Helpers;
using PropertyChanged;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _09_shulte_table.ViewModels
{
    public enum CellColor
    {
        White, Yellow, Green, Blue, Red, Purple
    }
    public enum CellState
    {
        Current, Next, Previous 
    }

    [AddINotifyPropertyChangedInterface]
    public class CellVM
    {
        private static Random rnd = new();

        // ------- Binding Properties -------
        public int? Number { get; }
        public CellColor Color { get; set; }
        public CellState State { get; set; }
        public ICommand? ClickCommand { get; }

        public CellVM(int? number = null, ICommand? clickCommand = null)
        {
            Number = number;
            Color = Number != null ? GetRandomColor() : CellColor.White;
            State = CellState.Next;
            ClickCommand = clickCommand;
        }

        private static CellColor GetRandomColor()
        {
            return (CellColor)rnd.Next(Enum.GetValues(typeof(CellColor)).Length);
        }
    }
}
