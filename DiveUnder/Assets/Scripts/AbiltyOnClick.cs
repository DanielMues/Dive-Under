using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiltyOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public AbilityCounter.ability ability;
    private AbilityEventHandler abilityEventHandler;
    private void Start()
    {
        abilityEventHandler = AbilityEventHandler.instance;
    }

    private void OnMouseDown()
    {
        abilityEventHandler.upCountAbility(ability);
    }
}
