using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] private int _width, _height;

    [SerializeField] private int playerTiles;
    
    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform TileParent;

    void Start()
    {
        GenerateGrid();
    }
    // Start is called before the first frame update
    void GenerateGrid()
    {
        int playerTileNum = playerTiles;
        

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
        
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, TileParent);
                spawnedTile.name = $"Tile {x} {y}";
                if (playerTileNum > 0)
                {
                    spawnedTile.AssignAlignment(Alignment.PLAYER);
                    playerTileNum -= 1;
                }
                else
                {
                    spawnedTile.AssignAlignment(Alignment.ENEMY);
                }
            }
        }
        TileParent.position = new Vector3(- _width / 2, - _height / 2);

    }
}
