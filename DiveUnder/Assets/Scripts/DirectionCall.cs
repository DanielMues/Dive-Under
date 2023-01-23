using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCall : MonoBehaviour
{
    public string player;
    public DirectionEventHandler.direction direction;
    DirectionEventHandler directionEventHandler;
    private void Start()
    {
        directionEventHandler = DirectionEventHandler.instance;
    }

    public void OnMouseDown()
    {
        directionEventHandler.CallDirection(direction, player);
    }
}
