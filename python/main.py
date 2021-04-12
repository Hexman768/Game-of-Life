from os import system
from random import randrange
from time import sleep

neighbors = [[-1, -1], [0, -1], [1, -1],
             [-1, 0],           [1, 0],
             [-1, 1], [0, 1], [1, 1]]

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
    """Prints the board to the screen.
    
    Args:
    board -- array of cells (integers)
    cols  -- number of columns in the board
    """
    #clear_screen()
    for i in range(len(board)):
        for j in range(cols):
            token = '#'
            if (board[i][j] == 0):
                token = ' '
            print(" {} ".format(token), end=" ")
        print("\n")

def clear_screen():
    system('clear')

def next_generation(board, next_gen, cols):
    for i in range(10):
        for j in range(10):
            nbs = check_neighbors(board, j, i)
            print("Neighbors: {} X: {} Y: {}".format(nbs, j, i))
            if (board[i][j] == 1 and (nbs == 2 or nbs == 3)):
                next_gen[i][j] = 1
            if (board[i][j] == 0 and nbs == 3):
                next_gen[i][j] = 1
            else:
                next_gen[i][j] = 0

def check_neighbors(board, x, y):
    count = 0

    for i in range(len(neighbors)):
        if (get_tile(board, x + neighbors[i][0], y + neighbors[i][1])):
            count += 1
    return count

def get_tile(board, x, y):
    #print("X; {} Y: {}".format(x, y))
    if (x < 0 or y >= 10 or x >= 10 or y < 0):
        return False
    elif (board[x][y] == 1):
        return True
    else:
        return False

def main():
    board = create_board(10, 10)
    next_gen = board
    for i in range(5):
        print_board(board, 10)
        next_generation(board, next_gen, 10)
        board = next_gen
        sleep(0.2)

if __name__ == "__main__":
    main()
