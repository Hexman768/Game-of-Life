using System.Drawing;

namespace GameOfLife
{
    /// <summary>
    /// This class represents the game in the game of life.
    /// This class will contain the <see cref="Board"/> and will contain the major logic for the game.
    /// </summary>
    class Game
    {
        private const int cellSize = 10;
        private Board board { get; set; }

        /// <summary>
        /// Constructs the <see cref="Game"/>.
        /// </summary>
        /// <param name="length">Length of board.</param>
        /// <param name="width">Width of board.</param>
        public Game(int length, int width)
        {
            board = MakeBoard(length, width);
        }

        private Board MakeBoard(int rows, int columns)
        {
            board = new Board();

            for (int i = 0; i < rows; i++)
            {
                board.AddRowBottom();
            }

            int rowCount = 0;

            foreach (Row row in board.rows)
            {
                for (int i = 0; i < columns; i++)
                {
                    row.AddCellRight(rowCount, i);
                }
                rowCount++;
            }

            return board;
        }

        /// <summary>
        /// Draws the game board onto the given graphics object.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            Point startPoint = new Point(5, 5);
            Point currentPoint = startPoint;

            foreach (Row row in board.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    Rectangle cellRect = new Rectangle(currentPoint.X, currentPoint.Y, cellSize, cellSize);
                    cell.rectangle = cellRect;
                    if (cell.alive)
                        graphics.FillRectangle(Brushes.Black, cellRect);
                    else if (!cell.alive)
                        graphics.FillRectangle(Brushes.White, cellRect);

                    currentPoint = new Point((currentPoint.X + cellSize + 1), currentPoint.Y);
                }
                currentPoint = new Point(startPoint.X, (currentPoint.Y + cellSize + 1));
            }
        }

        /// <summary>
        /// Handles the mouseclick by locating the cell the mouse is trying to click on and changing the state of the <see cref="Cell"/>.
        /// </summary>
        /// <param name="mouseX">Mouse X value.</param>
        /// <param name="mouseY">Mouse Y value.</param>
        public void Click(int mouseX, int mouseY)
        {
            foreach (Row row in board.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    if (cell.rectangle.Contains(mouseX, mouseY))
                    {
                        cell.alive = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the main game logic. This function will be called once per frame during the game.
        /// </summary>
        public void Step()
        {
            foreach (Row row in board.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    int neighbors = board.getLiveNeighbors(row, cell);
                    if (cell.alive && neighbors < 2)
                        cell.nextAlive = false;
                    else if (cell.alive && neighbors <= 3)
                        cell.nextAlive = true;
                    else if (cell.alive && neighbors > 3)
                        cell.nextAlive = false;
                    else if (!cell.alive && neighbors == 3)
                        cell.nextAlive = true;
                }
            }

            foreach (Row row in board.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    cell.alive = cell.nextAlive;
                }
            }
        }
    }
}
