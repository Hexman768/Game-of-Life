import os
from random import randrange


def create_board(rows, cols):
    grid = []
    for i in range(rows):
        row = []
        for j in range(cols):
            cell = randrange(2)
            row.append(cell)
        grid.append(row)
    return grid
    
def main():
    print(create_board(10, 10))

if __name__ == "__main__":
    main()
