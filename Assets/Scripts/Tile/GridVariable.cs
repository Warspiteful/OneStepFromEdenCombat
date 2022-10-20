using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GridVariable : ScriptableObject
{
   public Tile[,] TileGrid;
   
   public int playerTiles;


   public int width;
   public int height;
   
   public VariableUpdated valueUpdated;
   
   public VariableUpdated onCreation;
   
   public int playerX;
   public int playerY;

   public float distance;

   
   public void AssignAlignment(int x, int y, Alignment alignment)
   {
      TileGrid[x,y].alignment = alignment;
      valueUpdated.Invoke();
   }

   public Alignment GetAlignment(int x, int y)
   {
      return TileGrid[x,y].alignment;
   }
   

   public void SetCoords(int x, int y, Vector3 position)
   {
      TileGrid[x,y].SetCoords(position);
   }
   
   public Vector2 TranslateToCoord(int x, int y)
   {
      if (x > width || x < 0 || y > height || y < 0)
      {
         throw new Exception("Invalid Coordinates");
      }
      return TileGrid[x,y].coord;
   }

    
   public void SetOccupied(int x, int y, bool occupied)
   {
      TileGrid[x,y].occupied = occupied;
      valueUpdated.Invoke();
   }
    
   public bool GetOccupied(int x, int y)
   {
      return TileGrid[x,y].occupied;
   }
   
  
}
