using System.Drawing;

namespace GameOfLife
{
    /// <summary>
    /// This class represents a cell in the game of life.
    /// A cell contains a rectangle for display purposes and is in one of two states: alive or dead.
    /// </summary>
    public class Cell
    {
        internal int row { get; set; }
        internal int column { get; set; }
        internal bool alive { get; set; }
        internal bool nextAlive { get; set; }
        internal Rectangle rectangle { get; set; }

        /// <summary>
        /// Constructs the <see cref="Cell"/>.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;
            alive = false;
        }
    }
}
