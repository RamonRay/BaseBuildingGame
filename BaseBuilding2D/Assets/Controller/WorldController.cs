using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldController : MonoBehaviour
{
    
    public static WorldController Instance { get; protected set; }

    [SerializeField]
    Sprite floorSprite;
    public World world { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance!=null)
        {
            Debug.Log("There should not be 2 world controllers");
        }
        Instance = this;
        world = new World();
        for (int x = 0; x < world.Width; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                GameObject tile_go = new GameObject();
                tile_go.name="Tile_"+x+"_"+ y;
                tile_go.transform.position = new Vector3(x, y, 0);
                tile_go.transform.SetParent(this.transform,true);
                tile_go.AddComponent<SpriteRenderer>();
                Tile tile_data = world.GetTileAt(x, y);
                tile_data.RegisterCallBack((Tile tile) => { OnTileTypeChanged(tile, tile_go); });
                
            }
        }
        world.RandomizeWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTileTypeChanged(Tile tile_data, GameObject tile_go)
    {
        SpriteRenderer _sr = tile_go.GetComponent<SpriteRenderer>();
        if (tile_data.Type == Tile.TileType.Floor)
        {
            _sr.sprite = floorSprite;
        }
        else if (tile_data.Type == Tile.TileType.Empty)
        {
            _sr.sprite = null;
        }
        else
        {
            _sr.sprite = null;
            Debug.LogError("FloorTypeWentWrong");
        }
    }
}
