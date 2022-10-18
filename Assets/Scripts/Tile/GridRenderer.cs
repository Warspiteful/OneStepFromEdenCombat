using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Command;
public class GridRenderer : MonoBehaviour
{
    [SerializeField] private GridVariable grid;
    
    [SerializeField] private TilerRenderer _tilePrefab;
    
    [SerializeField] private Transform TileParent;
    
    [SerializeField] private Unit _player;

    private void OnEnable()
    {
        grid.onCreation += RenderGrid;
    }

    private void OnDisable()
    {
        grid.onCreation -= RenderGrid;
    }

    private void RenderGrid()
    {
        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, TileParent);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.SetCoordinates(x, y);
            }
        }
        
        
        grid.AssignAlignment((int)grid.playerX,(int) grid.playerY, Alignment.PLAYER);
        
        var player = Instantiate(_player, TileParent);
        player.SetStart(grid.playerX, grid.playerY);
        

        TileParent.position = new Vector3(- grid.width / 2, - grid.height / 2);

        grid.valueUpdated?.Invoke();
    }
}