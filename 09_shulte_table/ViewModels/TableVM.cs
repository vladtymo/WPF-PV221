using _09_shulte_table.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_shulte_table.ViewModels
{
    public class TableVM
    {
        private IList<CellVM> cells = new List<CellVM>();

        // ------- Binding Properties -------
        public IEnumerable<CellVM> Cells => cells;
        public int FirstNumber => 1;
        public int LastNumber => Size * Size - 1; // due to we have eye cell in center
        public int Size { get; }

        public TableVM(int size) 
        {
            Size = size;

            for (int i = FirstNumber; i <= LastNumber; ++i)
            {
                cells.Add(new CellVM(i));
            }
            cells.Shuffle();

            cells.Insert(cells.Count / 2, new CellVM());
        }
    }

    public enum CellColor
    {
        White, Yellow, Green, Blue, Red, Purple
    }
    public class CellVM
    {
        private static Random rnd = new();

        // ------- Binding Properties -------
        public int? Number { get; }
        public CellColor Color { get; set; }

        public CellVM(int? number = null)
        {
            Number = number;
            Color = Number != null ? GetRandomColor() : CellColor.White;
        }

        private static CellColor GetRandomColor()
        {
            return (CellColor)rnd.Next(Enum.GetValues(typeof(CellColor)).Length);
        }
    }
}
