using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoatMovement : MonoBehaviour
{
    public Vector3 originPosition;
    public int mapSizeX = 20;
    public int mapSizeY = 20;
    private int cellSize = 1;
    public GameObject tile;

    private Map map;
    private DirectionEventHandler directionEventHandler;
    // Start is called before the first frame update
    void Start()
    {
        directionEventHandler = DirectionEventHandler.instance;
        directionEventHandler.setDirection += Movement;
        map = new Map(originPosition, mapSizeX, mapSizeY, cellSize, cellSize);
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                GameObject tempTile = GameObject.Instantiate(tile);
                tempTile.transform.position =  map.mapGrid[x, y].centerPosition;
            }
        }
    }

    private void Movement(object sender, DirectionEventHandler.DirectionArguments args)
    {
        switch (args.direction)
        {
            case DirectionEventHandler.direction.north:
                Debug.Log("north");
                break;
            case DirectionEventHandler.direction.south:
                Debug.Log("south");
                break;
            case DirectionEventHandler.direction.east:
                Debug.Log("east");
                break;
            case DirectionEventHandler.direction.west:
                Debug.Log("west");
                break;
        }
    }
}
