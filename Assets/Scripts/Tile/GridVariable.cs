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
   
   public Vector2 playerPosition;

   
   public void AssignAlignment(int x, int y, Alignment alignment)
   {
      TileGrid[x,y].alignment = alignment;
      valueUpdated.Invoke();
   }

   public Alignment GetAlignment(int x, int y)
   {
      return TileGrid[x,y].alignment;
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
