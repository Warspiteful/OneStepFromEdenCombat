
using UnityEngine;



public class TilerRenderer : MonoBehaviour
{
   [SerializeField] private Tile tile;

   [SerializeField] private SpriteRenderer tileImage;

   [SerializeField] private Color playerColor;
   
   [SerializeField] private Color enemyColor;

   private void OnEnable()
   {
      tile.valueUpdated += UpdateDisplay;
   }
   
   private void OnDisable()
   {
      tile.valueUpdated -= UpdateDisplay;
   }

   private void UpdateDisplay()
   {
      Alignment tileAlignment = tile.GetAlignment();
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
