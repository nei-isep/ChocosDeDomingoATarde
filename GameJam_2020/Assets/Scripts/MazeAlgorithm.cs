using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeAlgorithm : MonoBehaviour
{

    private const int NORTH = 1;
    private const int SOUTH = 2;
    private const int EAST = 3;
    private const int WEST = 4;

    private int currentRow = 0, currentColumn = 0;

    private bool isFinished = false;

    // Labirinto em matriz
    MazeCell[,] cells;
    // Tamanho em colunas e linhas
    int columns, rows;

    // construtor
    public MazeAlgorithm(MazeCell[,] matrix) 
    {
        cells = matrix;
        columns = matrix.GetLength(0);
        rows = matrix.GetLength(1);
    }

    public void CreateMaze()
    {
        HuntAndKill();
    }

    public void HuntAndKill()
    {
        cells[currentRow, currentColumn].visited = true;
        while (!isFinished)
        {
            Kill();
            Hunt();
        }
    }

    private void Kill()
    {
        while (RouteIsAvailable(currentRow, currentColumn))
        {
            int direction = DirectionGenerator();
            switch (direction)
            {
                case NORTH:
                    if (CellIsAvailable(currentRow - 1, currentColumn))
                    {
                        DestroyWall(cells[currentRow, currentColumn].north);
                        DestroyWall(cells[currentRow - 1, currentColumn].south);
                        currentRow--;
                    }
                    break;
                case SOUTH:
                    if (CellIsAvailable(currentRow + 1, currentColumn))
                    {
                        DestroyWall(cells[currentRow, currentColumn].south);
                        DestroyWall(cells[currentRow + 1, currentColumn].north);
                        currentRow++;
                    }
                    break;
                case EAST:
                    if (CellIsAvailable(currentRow, currentColumn + 1))
                    {
                        DestroyWall(cells[currentRow, currentColumn].east);
                        DestroyWall(cells[currentRow, currentColumn + 1].west);
                        currentColumn++;
                    }
                    break;
                case WEST:
                    if (CellIsAvailable(currentRow, currentColumn - 1))
                    {
                        DestroyWall(cells[currentRow, currentColumn].east);
                        DestroyWall(cells[currentRow, currentColumn - 1].west);
                        currentColumn--;
                    }
                    break;
            }
            cells[currentRow, currentColumn].visited = true;
        }
    }

    private void Hunt()
    {
        isFinished = true;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (!cells[r, c].visited && CellHasAdjacentVisitedCell(r,c))
                {
                    isFinished = false;
                    currentRow = r;
                    currentColumn = c;
                    DestroyAdjacentWall(currentRow, currentColumn);
                    cells[currentRow, currentColumn].visited = true;
                    return;
                }
            }
        }
    }

    private bool CellHasAdjacentVisitedCell(int row, int column)
    {
        return (row > 0 && cells[row - 1, column].visited) 
            || (row < (rows - 2) && cells[row + 1, column].visited) 
            || (column > 0 && cells[row, column - 1].visited)
            || (column < (columns - 2) && cells[row, column + 1].visited);
    }

    private bool CellIsAvailable(int row, int column)
    {
        return (row >= 0 && row < rows && column >= 0 && column < columns && !cells[row, column].visited);
    }

    private bool RouteIsAvailable(int row, int column)
    {
        return (row > 0 && !cells[row - 1, column].visited) 
            || (row < rows - 1 && !cells[row + 1, column].visited) 
            || (column > 0 && !cells[row, column - 1].visited) 
            || (column < columns - 1 && !cells[row, column + 1].visited);
    }

    private void DestroyWall(GameObject wall)
    {
        if (wall != null) GameObject.Destroy(wall);
    }

    private void DestroyAdjacentWall(int row, int column)
    {
        bool wallDestroyed = false;

        while (!wallDestroyed)
        {
            int direction = DirectionGenerator();
            switch (direction)
            {
                case NORTH:
                    if (row > 0 && cells[row - 1, column].visited)
                    {
                        DestroyWall(cells[currentRow, currentColumn].north);
                        DestroyWall(cells[currentRow - 1, currentColumn].south);
                        wallDestroyed = true;
                    }
                    break;
                case SOUTH:
                    if (row < (rows - 2) && cells[row + 1, column].visited)
                    {
                        DestroyWall(cells[currentRow, currentColumn].south);
                        DestroyWall(cells[currentRow + 1, currentColumn].north);
                        wallDestroyed = true;
                    }
                    break;
                case EAST:
                    if (column > 0 && cells[row, column - 1].visited)
                    {
                        DestroyWall(cells[currentRow, currentColumn].east);
                        DestroyWall(cells[currentRow, currentColumn + 1].west);
                        wallDestroyed = true;
                    }
                    break;
                case WEST:
                    if (column < (columns - 2) && cells[row, column + 1].visited)
                    {
                        DestroyWall(cells[currentRow, currentColumn].east);
                        DestroyWall(cells[currentRow, currentColumn - 1].west);
                        wallDestroyed = true;
                    }
                    break;
            }
        }
    }

    //TODO: Check if right
    private int DirectionGenerator()
    {
        System.Random random = new System.Random();
        return random.Next(1,4);
    }

}
