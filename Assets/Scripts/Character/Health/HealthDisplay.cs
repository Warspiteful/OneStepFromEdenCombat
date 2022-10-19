using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Unit unit;
    
    [SerializeField]
    private Text healthVal;
    
    private void Awake()
    {
        unit = GetComponent<Unit>();
        unit.onHealthChange += UpdateDisplay;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthVal.text = unit.GetHealth().ToString();
    }
}
