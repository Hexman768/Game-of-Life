using System.Collections.Generic;

namespace GameOfLife
{
    /// <summary>
    /// Class to represent the game board.
    /// </summary>
    class Board
    {
        internal List<Row> rows;

        /// <summary>
        /// Constructs the <see cref="Board" />.
        /// </summary>
        public Board()
        {
            rows = new List<Row>();
        }

        /// <summary>
        /// Adds a new row to the end of the row list.
        /// </summary>
        public void AddRowBottom()
        {
            rows.Add(new Row());
        }

        /// <summary>
        /// Adds a new row to the front of the row list.
        /// </summary>
        public void AddRowTop()
        {
            rows.Insert(0, new Row());
        }

        /// <summary>
        /// Checks the 8 adjacent cells around the given cell for live cells.
        /// Each live cell is added to a count variable to keep track of each 'neighbor'.
        /// </summary>
        /// <param name="row">Current row of selected cell.</param>
        /// <param name="cell">Selected cell.</param>
        /// <returns></returns>
        public int getLiveNeighbors(Row row, Cell cell)
        {
            int neighbors = 0;

            int maxRow = row.cells.Count - 1;

            // Check top row
            if (cell.row != 0)
            {
                Row topRow = rows[cell.row - 1];
                Cell middleTop = topRow.cells[cell.column];

                if (middleTop.alive)
                    neighbors++;

                if (cell.column != 0)
                {
                    Cell topLeft = topRow.cells[cell.column - 1];
                    if (topLeft.alive)
                        neighbors++;
                }

                if (cell.column != maxRow)
                {
                    Cell topRight = topRow.cells[cell.column + 1];
                    if (topRight.alive)
                        neighbors++;
                }
            }

            // Check left
            if (cell.column != 0)
            {
                Cell middleLeft = row.cells[cell.column - 1];
                if (middleLeft.alive)
                    neighbors++;
            }

            // Check right
            if (cell.column != maxRow)
            {
                Cell middleRight = row.cells[cell.column + 1];
                if (middleRight.alive)
                    neighbors++;
            }

            // Check bottom
            if (cell.row != rows.Count - 1)
            {
                Row bottomRow = rows[cell.row + 1];
                Cell bottomMiddle = bottomRow.cells[cell.column];

                if (bottomMiddle.alive)
                    neighbors++;

                if (cell.column != 0)
                {
                    Cell bottomLeft = bottomRow.cells[cell.column - 1];
                    if (bottomLeft.alive)
                        neighbors++;
                }

                if (cell.column != maxRow)
                {
                    Cell bottomRight = bottomRow.cells[cell.column + 1];
                    if (bottomRight.alive)
                        neighbors++;
                }
            }
            return neighbors;
        }
    }
}
