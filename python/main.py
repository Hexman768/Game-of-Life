import os
from random import randrange

def create_board(rows, cols):
    """Creates and returns a grid based on the given number of rows and columns.

    Args:
    rows -- Number of rows for the grid
    cols -- Number of columns for the grid
    """
    grid = []
    for i in range(rows):
        row = []
        for j in range(cols):
            cell = randrange(2)
            row.append(cell)
        grid.append(row)
    return grid

def print_board(board, cols):
    for i in range(len(board)):
        for j in range(cols):
            print(" {} ".format(board[i][j]), end=" ")
        print("\n")
    
def main():
    board = create_board(10, 10)
    print_board(board, 10)

if __name__ == "__main__":
    main()
