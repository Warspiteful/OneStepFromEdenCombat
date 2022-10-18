using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Command
{
    

    public class EnemyInputHandler : InputHandler
    {
        private float timeForDecision;
        public EnemyInputHandler(float timeForDecision)
        {
            this.timeForDecision = timeForDecision;
        }
        private UnitCommand[] potentialMoves;
        
        // Start is called before the first frame update
        public override void Initialize()
        {
            potentialMoves = new UnitCommand[] {MoveUp,MoveDown,MoveRight,MoveLeft};
            
        }

        public  override IEnumerator StartBrain()
        {
            while (true)
            {
                AddCommand(potentialMoves[Random.Range(0, potentialMoves.Length)]);
                yield return new WaitForSeconds(timeForDecision);
            }
        }
    }
}
