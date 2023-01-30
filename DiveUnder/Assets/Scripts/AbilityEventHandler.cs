using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityEventHandler : MonoBehaviour
{
    public static AbilityEventHandler instance;
    private void Start()
    {
        instance = this;
    }

    public event EventHandler<EventArgs> increaseAbility;

    public void upCountAbility()
    {
        increaseAbility?.Invoke(this, new EventArgs());
    }
}
