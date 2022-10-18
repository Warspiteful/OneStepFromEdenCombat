
using System;
using UnityEngine;

[Serializable]
public class Tile
{
    public Vector2 coord;

    public Alignment alignment;

    public bool occupied;


    public void SetCoords(Vector2 coord)
    {
        this.coord = coord;
    }
    public Tile(Alignment alignment)
    {
        occupied = false;
        this.alignment = alignment;
    }
    
}
