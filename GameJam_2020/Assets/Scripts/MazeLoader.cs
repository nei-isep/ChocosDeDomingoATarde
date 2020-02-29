using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLoader : MonoBehaviour
{

    public int rows, columns;
    public GameObject wall;
    public float size = 2f;

    private MazeCell [,] cells;

    void Start()
    {
        InitializeMaze();
        MazeAlgorithm algorithm = new MazeAlgorithm(cells);
        algorithm.CreateMaze();
    }

    private void InitializeMaze()
    {
        cells = new MazeCell[rows, columns];
        for (int r = 0; r < rows; r++)
        {
            for( int c = 0; c < columns; c++)
            {
                cells[r, c] = new MazeCell();
                cells[r, c].ground = Instantiate(wall, new Vector3(r * size, -(size / 2f), c * size), Quaternion.identity) as GameObject;
                cells[r, c].ground.transform.Rotate(Vector3.right, 90f);

                if (c == 0)
                {
                    cells[r, c].west = Instantiate(wall, new Vector3(r * size, 0, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
                }

                cells[r, c].east = Instantiate(wall, new Vector3(r * size, 0, (c * size) + (size / 2f)), Quaternion.identity) as GameObject;

                if (r == 0)
                {
                    cells[r, c].north = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                    cells[r, c].north.transform.Rotate(Vector3.up * 90f);
                }
            }
        }
    }
}
