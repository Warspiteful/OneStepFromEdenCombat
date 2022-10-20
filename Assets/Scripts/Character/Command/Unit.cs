using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Command
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] private GridVariable grid;

        [SerializeField] private int x;
        [SerializeField] private int y;
        
        [SerializeField] private float timeToDecide;

        [SerializeField] private Alignment _alignment;

        [SerializeField] private bool isFinished;

        public DelegateSignal onAttack;
        
        public DelegateSignal onAttackSwitch;

        
        public DelegateSignal onHealthChange;

        public DelegateSignal onDeath;

        [SerializeField] private int maxHealth;
        [SerializeField] private int currHealth;
        
        [SerializeField] private Transform attackTile;
        
        [SerializeField] private int attackOffset;

        

        public void TakeDamage(int dmg)
        {
            currHealth = Mathf.Clamp(currHealth - dmg, 0, maxHealth);
            if (currHealth == 0)
            {
                onDeath?.Invoke();
                
            }
            
            onHealthChange?.Invoke();
        }

        public int GetHealth()
        {
            return currHealth;
        }
        
        public void TakeHeal(int heal)
        {
            currHealth = Mathf.Clamp(currHealth + heal, 0, maxHealth);
            onHealthChange?.Invoke();
        }

        public Vector3 GetAttackTile()
        {
            return attackTile.position;
        }


        public void SetStart(int x, int y)
        {
            attackTile.localPosition = new Vector2(grid.distance*attackOffset, 0);

            if (x > grid.width / 2)
            {
 
                transform.rotation = Quaternion.Euler(0,180,0);
            }
            transform.localPosition = grid.TranslateToCoord(x, y);
            this.x = x;
            this.y = y;

        }
        
        public void SetStart()
        {
            transform.localPosition = grid.TranslateToCoord(x, y);
        }

        public InputHandler GetInputHandler()
        {
            switch (_alignment)
            {
                case Alignment.PLAYER:
                    return new PlayerInputHandler();
                case Alignment.ENEMY:
                    return new EnemyInputHandler(timeToDecide);
                default:
                    return new EnemyInputHandler(timeToDecide);
            }
        }

        public bool isCommandFinished()
        {
            return isFinished;
        }

        public void Move(Direction dir)
        {
            int tempX = x;
            int tempY = y;
            isFinished = false;

            switch (dir)
            {
                case Direction.UP:
                    
                    if (y+1 < grid.height && grid.GetAlignment(x,y+1) == _alignment && !grid.GetOccupied(x,y+1))
                    {
                        y += 1;
                    }
                    break;
                case Direction.DOWN:
                    if (y - 1 >= 0 && grid.GetAlignment(x,y-1) == _alignment && !grid.GetOccupied(x,y-1))
                    {
                        y -= 1;
                    }
                    break;
                case Direction.LEFT:
                    if (x - 1 >= 0 && grid.GetAlignment(x-1,y) == _alignment && !grid.GetOccupied(x-1, y))
                    {
                        x -= 1;
                    }
                    break;
                case Direction.RIGHT:
                    if (x + 1 < grid.width && grid.GetAlignment(x+1, y) == _alignment && !grid.GetOccupied(x+1,y))
                    {
                        x += 1;
                    }
                    break;
            }
            grid.SetOccupied(tempX, tempY, false);
            grid.SetOccupied(x, y, true);
        }
        
        public void Attack()
        {
            onAttack?.Invoke();
        }
        
           public void Switch()
                {
                    onAttackSwitch?.Invoke();
                }
        
        private void Update()
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, grid.TranslateToCoord(x,y),
                Time.deltaTime * speed);
            isFinished = new Vector2(transform.localPosition.x, transform.localPosition.y) ==
                         grid.TranslateToCoord(x, y);

        }
    }
}