using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionEventHandler : MonoBehaviour
{
    public static DirectionEventHandler instance;
    private void Start()
    {
        instance = this;
    }

    public enum direction { north, south, west ,east }

    public class DirectionArguments : EventArgs
    {
        public direction direction;
        public string player;
    }

    public event EventHandler<DirectionArguments> setDirection;

    public void CallDirection(direction direction, string player)
    {
        setDirection?.Invoke(this, new DirectionArguments { direction = direction, player = player });
    }
}
