using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public Transform wall;
    public Transform floor;
    public Sprite spriteb;
    public Sprite spriten;
    public int height;
    public int width;
    int[,] maze;
   
    // Use this for initialization
    void Start()
    {
        maze = new int[height, width];
        maze = generateMaze();
        correctMaze();
        render();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void render()
    {
        bool begining = true;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (maze[x, y] == 1)
                {
                    GameObject wall = (GameObject)Instantiate(Resources.Load("Maze/maze_wall"));
                    wall.transform.position = new Vector3(x, y, 0);
                }
                else
                {
                    GameObject floor = (GameObject)Instantiate(Resources.Load("Maze/maze_floor"));
                    floor.transform.position = new Vector3(x, y, 0);
                    if (begining)
                    {
                        GameObject player = (GameObject)Instantiate(Resources.Load("Maze/Player_Head"));
                        player.transform.position = new Vector3(x, y, 0);
                        begining = false;
                    }

                    GameObject d = GameObject.FindGameObjectWithTag("rock");
                    DestroyImmediate(d);
                    GameObject goal = (GameObject)Instantiate(Resources.Load("Maze/rock"));
                    goal.transform.position = new Vector3(x, y, 0);
                }
            }
        }
    }

    public int[,] generateMaze()
    {
        int[,] maze = new int[height, width];
        // Initialize
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                maze[i, j] = 1;

        // r for row、c for column
        // Generate random r
        int r = Random.Range(0, height);
        while (r % 2 == 0)
        {
            r = Random.Range(0, height);
        }
        // Generate random c
        int c = Random.Range(0, width);
        while (c % 2 == 0)
        {
            c = Random.Range(0, width);
        }
        // Starting cell
        maze[r, c] = 0;

        //　Allocate the maze with recursive method
        maze = recursion(r, c, maze);

        return maze;
    }
    public int[,] recursion(int r, int c, int[,] maze)
    {
        int[,] m = new int[height, width];

        m = maze;

        // 4 random directions
        int[] randDirs = generateRandomDirections();
        // Examine each direction
        for (int i = 0; i < randDirs.Length; i++)
        {

            switch (randDirs[i])
            {
                case 1: // Up
                    //　Whether 2 cells up is out or not
                    if (r - 2 <= 0)
                        continue;
                    if (m[r - 2, c] != 0)
                    {
                        m[r - 2, c] = 0;
                        m[r - 1, c] = 0;
                        recursion(r - 2, c, m);
                    }
                    break;
                case 2: // Right
                    // Whether 2 cells to the right is out or not
                    if (c + 2 >= width - 1)
                        continue;
                    if (m[r, c + 2] != 0)
                    {
                        m[r, c + 2] = 0;
                        m[r, c + 1] = 0;
                        recursion(r, c + 2, m);
                    }
                    break;
                case 3: // Down
                    // Whether 2 cells down is out or not
                    if (r + 2 >= height - 1)
                        continue;
                    if (m[r + 2, c] != 0)
                    {
                        m[r + 2, c] = 0;
                        m[r + 1, c] = 0;
                        recursion(r + 2, c, m);
                    }
                    break;
                case 4: // Left
                    // Whether 2 cells to the left is out or not
                    if (c - 2 <= 0)
                        continue;
                    if (m[r, c - 2] != 0)
                    {
                        m[r, c - 2] = 0;
                        m[r, c - 1] = 0;
                        recursion(r, c - 2, m);
                    }
                    break;
            }
        }
        return m;
    }

    /**
 * Generate an array with random directions 1-4
 * @return Array containing 4 directions in random order
 */
    public int[] generateRandomDirections()
    {
        List<int> randoms = new List<int>();
        while (randoms.Count != 4)
        {
            int i = Random.Range(1, 5);
            if (!randoms.Contains(i))
            {
                randoms.Add(i);
            }
        }
        return randoms.ToArray();

    }

    public void correctMaze()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (y == 0 || x == 0 || y == width-1 || x == height-1)
                {
                    maze[x, y] = 1;
                }
            }
        }
    }
   
}