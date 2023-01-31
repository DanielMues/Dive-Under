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

    public event EventHandler<AbilityArguments> increaseAbility;

    public class AbilityArguments : EventArgs
    {
        public AbilityCounter.ability ability;
    }

    public void upCountAbility(AbilityCounter.ability ability)
    {
        increaseAbility?.Invoke(this, new AbilityArguments { ability = ability });
    }
}
