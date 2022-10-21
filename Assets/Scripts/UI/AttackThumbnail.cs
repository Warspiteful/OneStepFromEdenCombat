using System;
using System.Collections;
using System.Collections.Generic;
using Character.Actions;
using UnityEngine;
using UnityEngine.UI;

public class AttackThumbnail : MonoBehaviour
{
    [SerializeField] private Attack _attack;
    // Start is called before the first frame update

    [SerializeField] private Image thumbnail;
    

    public void SetAttack(Attack attack)
    {
        _attack = attack;
        _attack.activeChange += UpdateDisplay;
        thumbnail.sprite = _attack.thumbnail;
        UpdateDisplay();   
    }

    private void UpdateDisplay()
    {
        if(_attack.isActive){
            thumbnail.color = Color.red;
        }
        else
        {
            thumbnail.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
