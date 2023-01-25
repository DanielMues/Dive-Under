using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class BoatMovement : MonoBehaviour
{
    //Map
    [Header("Map")]
    public Vector3 originPosition;
    public int mapSizeX = 20;
    public int mapSizeY = 20;
    private int cellSize = 1;
    private Map map;

    //GameObjects
    [Header("GameObjects")]
    public GameObject tile;
    public GameObject boatPrefab;
    public GameObject pathPrefab;
    private GameObject boat;
    
    // EventHandler
    private DirectionEventHandler directionEventHandler;

    // Tilemap
    public ITilemap Island;

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
        boat = GameObject.Instantiate(boatPrefab);
        boat.transform.position = map.GetCenteredPosition(5, 10);
    }

    private void Movement(object sender, DirectionEventHandler.DirectionArguments args)
    {
        int x, y;
        map.GetXY(out x, out y, boat.transform.position);
        switch (args.direction)
        {
            case DirectionEventHandler.direction.north:
                if (map.CheckIfEmpty(x, y + 1))
                {
                    map.DeleteUnit(x, y);
                    // spawn path
                    GameObject newPath = GameObject.Instantiate(pathPrefab);
                    map.SetUnit(newPath, x, y);
                    newPath.transform.position = map.GetCenteredPosition(x, y);
                    // move boat
                    map.SetUnit(boat, x, y + 1);
                    boat.transform.position = map.GetCenteredPosition(x, y + 1);
                }
                break;
            case DirectionEventHandler.direction.south:
                if (map.CheckIfEmpty(x, y - 1))
                {
                    map.DeleteUnit(x, y);
                    // spawn path
                    GameObject newPath = GameObject.Instantiate(pathPrefab);
                    map.SetUnit(newPath, x, y);
                    newPath.transform.position = map.GetCenteredPosition(x, y);
                    // move boat
                    map.SetUnit(boat, x, y - 1);
                    boat.transform.position = map.GetCenteredPosition(x, y - 1);
                }
                break;
            case DirectionEventHandler.direction.east:
                if (map.CheckIfEmpty(x + 1, y))
                {
                    map.DeleteUnit(x, y);
                    // spawn path
                    GameObject newPath = GameObject.Instantiate(pathPrefab);
                    map.SetUnit(newPath, x, y);
                    newPath.transform.position = map.GetCenteredPosition(x, y);
                    // move boat
                    map.SetUnit(boat, x + 1, y);
                    boat.transform.position = map.GetCenteredPosition(x + 1, y);
                }
                break;
            case DirectionEventHandler.direction.west:
                if (map.CheckIfEmpty(x - 1, y))
                {
                    map.DeleteUnit(x, y);
                    // spawn path
                    GameObject newPath = GameObject.Instantiate(pathPrefab);
                    map.SetUnit(newPath, x, y);
                    newPath.transform.position = map.GetCenteredPosition(x, y);
                    // move boat
                    map.SetUnit(boat, x - 1, y);
                    boat.transform.position = map.GetCenteredPosition(x - 1, y);
                }
                break;
        }
    }
}


