using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMove : TacticsMove 
{
    

	// Use this for initialization
	void Start () 
	{
        Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            if (state == 0)
            {
                FindSelectableTiles(actualMove);
            }
            else
            {
                FindSelectableTiles(range);
            }
            CheckMouse();
        }
        else
        {
            anim.Play("walklSpear",0);
            Move();
            
            
        }
	}

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        switch (state)
                        {
                            case 0:
                                MoveToTile(t);
                                break;
                            default:
                                TurnManager.Hit(state,t);
                                break;
                        }
                    }
                }
            }
        }
    }
}
