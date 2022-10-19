using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

public abstract class InputControlType : ScriptableObject
{
    private InputHandler input;

    public void Setup(InputHandler input)
    {
        this.input = input;
    }

    protected abstract void Initialize();

}
