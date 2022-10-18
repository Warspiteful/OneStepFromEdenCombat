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
        
        [SerializeField] private int timeToDecide;

        [SerializeField] private Alignment _alignment;

        [SerializeField] private bool isFinished;
        

        public void SetStart(int x, int y)
        {
            transform.localPosition = grid.TranslateToCoord(x, y);
            this.x = x;
            this.y = y;
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
            isFinished = false;

            switch (dir)
            {
                case Direction.UP:
                    
                    if (y+1 < grid.height && grid.GetAlignment(x,y+1) == _alignment)
                    {
                        y += 1;
                    }
                    break;
                case Direction.DOWN:
                    if (y - 1 >= 0 && grid.GetAlignment(x,y-1) == _alignment)
                    {
                        y -= 1;
                    }
                    break;
                case Direction.LEFT:
                    if (x - 1 >= 0 && grid.GetAlignment(x-1,y) == _alignment)
                    {
                        x -= 1;
                    }
                    break;
                case Direction.RIGHT:
                    if (x + 1 < grid.width && grid.GetAlignment(x+1, y) == _alignment)
                    {
                        x += 1;
                    }
                    break;
            }
        }
        
        public void Attack()
        {
            Debug.Log("Attack");
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