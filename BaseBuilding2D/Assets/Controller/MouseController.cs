using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] GameObject cursor;
    Vector3 lastFramePosition;
    Vector3 dragStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentFramePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Update the circle cursor position
        
        
        //Handle Mouse dragging
        if (Input.GetMouseButton(1)|| Input.GetMouseButton(2))//Right or Middle mouse button
        {
            Vector3 diff = lastFramePosition - currentFramePosition;
            Camera.main.transform.Translate(diff);
        }
        lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Get the position on near clip

        Tile tileUnderMouse = GetTileAtWorldCoord(currentFramePosition);
        if (tileUnderMouse != null)
        {
            cursor.SetActive(true);
            cursor.transform.position = new Vector3(tileUnderMouse.X, tileUnderMouse.Y, 0);
        }
        else
        {
            cursor.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            dragStart = lastFramePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            int start_x = Mathf.FloorToInt(dragStart.x+0.5f);
            int end_x = Mathf.FloorToInt(lastFramePosition.x + 0.5f);
            if(end_x<start_x)
            {
                int tmp = end_x;
                end_x = start_x;
                start_x = tmp;
            }

            int start_y = Mathf.FloorToInt(dragStart.y + 0.5f);
            int end_y = Mathf.FloorToInt(lastFramePosition.y + 0.5f);
            if (end_y < start_y)
            {
                int tmp = end_y;
                end_y = start_y;
                start_y = tmp;
            }

            for (int x = start_x; x <= end_x; x++)
            {
                for (int y = start_y; y <=end_y; y++)
                {
                    Tile _t = WorldController.Instance.world.GetTileAt(x, y);
                    _t.Type = Tile.TileType.Floor;
                }
            }
            
        }
    }


    Tile GetTileAtWorldCoord(Vector3 coord)
    {
        int x = Mathf.FloorToInt(coord.x+0.5f);
        int y = Mathf.FloorToInt(coord.y+0.5f);

        return  WorldController.Instance.world.GetTileAt(x,y);

    }
}
