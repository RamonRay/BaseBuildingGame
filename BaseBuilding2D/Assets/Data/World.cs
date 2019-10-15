using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    Tile[,] world;
    int width;
    int height;
    public int Width { get { return width; } }
    public int Height { get { return height;  } }

    public World(int width = 100, int height = 100)
    {
        this.width = width;
        this.height = height;

        world = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                world[x, y] = new Tile(x, y);
            }
        }
    }

    public Tile GetTileAt(int x, int y)
    {
        if (x < 0 || x > width - 1 || y < 0 || y > height - 1)
        {
            Debug.LogError("Tile out of bound");
            return null;
        }
        return world[x, y];
    }

    public void RandomizeWorld()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int randomInt;
                randomInt = Random.Range(0, 2);
                if(randomInt==0)
                {
                    world[x, y].Type = Tile.TileType.Empty;
                }
                else
                {
                    world[x, y].Type = Tile.TileType.Floor;
                }
            }
        }
        Debug.Log("World Randomized");
    }
}
