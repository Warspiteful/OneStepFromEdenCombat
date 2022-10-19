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
            Debug.Log("Enemy Input Created");
            this.timeForDecision = timeForDecision;
        }
        private UnitCommand[] potentialMoves;
        
        // Start is called before the first frame update
        public override void Initialize()
        {
            Debug.Log("Enemy Moves Initialized");
            potentialMoves = new [] {MoveUp,MoveDown,MoveRight,MoveLeft, Attack};
            
        }

        public  override IEnumerator StartBrain()
        {
            Debug.Log("Enemy Brain Started");
            while (true)
            {
                AddCommand(potentialMoves[Random.Range(0, potentialMoves.Length)]);
                yield return new WaitForSeconds(timeForDecision);
            }
        }
    }
}
