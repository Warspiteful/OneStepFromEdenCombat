using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Alignment alignment;

    [SerializeField] private bool occupied;

    public VariableUpdated valueUpdated;


    public void AssignAlignment(Alignment alignment)
    {
        this.alignment = alignment;
        valueUpdated.Invoke();
    }

    public Alignment GetAlignment()
    {
        return alignment;
    }
}
