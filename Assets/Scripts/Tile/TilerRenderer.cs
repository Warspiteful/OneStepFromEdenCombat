
using UnityEngine;



public class TilerRenderer : MonoBehaviour
{
   [SerializeField] private GridVariable grid;

   [SerializeField] private SpriteRenderer tileImage;

   [SerializeField] private Color playerColor;
   
   [SerializeField] private Color enemyColor;
   
   [SerializeField] 
   private int x;
   
   [SerializeField] 
   private int y;

   private void OnEnable()
   {
      grid.valueUpdated += UpdateDisplay;
   }
   
   private void OnDisable()
   {
      grid.valueUpdated -= UpdateDisplay;
   }

   public void SetCoordinates(int x, int y)
   {
      this.x = x;
      this.y = y;
      grid.SetCoords(x,y,transform.localPosition);
   }

   private void UpdateDisplay()
   {
      Alignment tileAlignment = grid.GetAlignment(x,y);
      switch (tileAlignment)
      {
         case(Alignment.PLAYER):
            tileImage.color = playerColor;
            break;
         case(Alignment.ENEMY):
            tileImage.color = enemyColor;
            break;
         
      }
   }


}
