
public class Tile
{
    public int x;
    
    public int y;
 
    public Alignment alignment;

    public bool occupied;


    public Tile(Alignment alignment)
    {
        occupied = false;
        this.alignment = alignment;
    }
    
}
