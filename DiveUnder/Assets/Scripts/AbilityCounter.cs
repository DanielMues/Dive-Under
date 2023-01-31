using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityCounter : MonoBehaviour
{
    
    public enum ability {mine, radar}
    private ability selectedAbility;

    private int minMine = 0;
    private int currentMine;
    [SerializeField]
    private int maxMine = 3;

    private int minRadar = 0;
    private int currentRadar;
    [SerializeField]
    private int maxRadar = 4;

    private AbilityEventHandler abilityEventHandler;
    // Start is called before the first frame update
    void Start()
    {
        currentMine = 0;
        currentRadar = 0;
        selectedAbility = ability.radar;
        abilityEventHandler = AbilityEventHandler.instance;
        abilityEventHandler.increaseAbility += increaseCounterAbility;
    }

    public void increaseCounterAbility(object sender, AbilityEventHandler.AbilityArguments args)
    {
        switch (args.ability)
        {
            case ability.mine:
                if(currentMine <= maxMine)
                {
                    currentMine += 1;
                }
                break;
            case ability.radar:
                if(currentRadar <= maxRadar)
                {
                    currentRadar += 1;
                }
                Debug.Log(currentRadar);
                break;
        }
    }

    public void resetCounterMine()
    {
        currentMine = 0;
    }

    public void resetCounterRadar()
    {
        currentRadar = 0;
    }
}
