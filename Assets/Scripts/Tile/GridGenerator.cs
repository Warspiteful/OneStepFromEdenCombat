using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{


    
    [SerializeField] private GridVariable grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        int playerTileNum = grid.playerTiles;
        
        grid.TileGrid = new Tile[grid.width,grid.height];

        
        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                
                if (playerTileNum > 0)
                {
                    grid.TileGrid[x, y] = new Tile(Alignment.PLAYER);
                    playerTileNum -= 1;
                }
                else
                {
                    grid.TileGrid[x, y] = new Tile(Alignment.ENEMY);
                }
            }
        }
        grid.onCreation?.Invoke();
    }
    
}
