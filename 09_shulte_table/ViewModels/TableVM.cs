using _09_shulte_table.Helpers;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace _09_shulte_table.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TableVM
    {
        private IList<CellVM> cells = new ObservableCollection<CellVM>();
        private RelayCommand cellClickCommand;

        // ------- Binding Properties -------
        public IEnumerable<CellVM> TableCells { get; private set; }
        public int FirstNumber { get; } = 1;
        public int LastNumber => Size * Size - 1; // due to we have eye cell in the center
        public int Size { get; }

        // Click logic
        public int FirstNumberIndex { get; } = 0;
        public int LastNumberIndex { get; }
        public int CurrentNumberIndex { get; private set; }
        public bool IsFinish => CurrentNumberIndex == LastNumberIndex;

        public TableVM(int size) 
        {
            Size = size < 3 ? 3 : (size % 2 == 0 ? size + 1 : size);
            LastNumberIndex = LastNumber - 1;
            CurrentNumberIndex = FirstNumberIndex;

            cellClickCommand = new((o) => CellClick((int)o));

            InitializeCells();
            GenerateTable();
        }

        private void InitializeCells()
        {
            cells.Clear();

            for (int i = FirstNumber; i <= LastNumber; ++i)
            {
                cells.Add(new CellVM(i, cellClickCommand));
            }

            cells[FirstNumberIndex].State = CellState.Current;
        }
        private void GenerateTable()
        {
            var table = new List<CellVM>(cells);
            table.Shuffle();
            table.Insert(cells.Count / 2, new CellVM());

            TableCells = new List<CellVM>(table);
        }
        private void ResetCellStates()
        {
            foreach (var cell in cells)
                cell.State = CellState.Next;

            cells[FirstNumberIndex].State = CellState.Current;
            CurrentNumberIndex = FirstNumberIndex;
        }

        private void CellClick(int number)
        {
            if (cells[CurrentNumberIndex].Number == number)
            {
                cells[CurrentNumberIndex].State = CellState.Previous;

                if (!IsFinish)
                    cells[++CurrentNumberIndex].State = CellState.Current;
                else
                {
                    MessageBox.Show("Congrats!");
                    CurrentNumberIndex = FirstNumberIndex;
                    InitializeCells();
                    GenerateTable();
                    //ResetCellStates();
                }
            }
        }
    }
}
