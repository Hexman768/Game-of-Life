using System.Collections.Generic;

namespace GameOfLife
{
    /// <summary>
    /// This class represents a row that will be stored in the <see cref="Board"/>.
    /// </summary>
    class Row
    {
        internal List<Cell> cells;
        
        /// <summary>
        /// Constructs the <see cref="Row"/>.
        /// </summary>
        public Row()
        {
            cells = new List<Cell>();
        }

        /// <summary>
        /// Adds a cell to the front of the list of <see cref="Cell"/>.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void AddCellLeft(int row, int column)
        {
            cells.Insert(0, new Cell(row, column));
        }

        /// <summary>
        /// Adds a cell to the end of the list of <see cref="Cell"/>.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void AddCellRight(int row, int column)
        {
            cells.Add(new Cell(row, column));
        }
    }
}
