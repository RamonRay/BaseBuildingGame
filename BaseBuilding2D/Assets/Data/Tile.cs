using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile 
{
    public enum TileType
    {
        Empty,
        Floor
    }
    TileType type = TileType.Empty;
    public TileType Type
    {
        get
        {
            return type;
        }
        set
        {
            TileType oldType = type;
            type = value;
            if(callback!=null&&oldType!=type)
                callback(this);
        }
    }

    

    int x;
    int y;
    public int X { get { return x; } protected set {x=value; } }
    public int Y { get { return y; } protected set {y=value; } }

    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
    }



    Action<Tile> callback;
    public void RegisterCallBack(Action<Tile> _callback)
    {
        callback += _callback;
    }
}
