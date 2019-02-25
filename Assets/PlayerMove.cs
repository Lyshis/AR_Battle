using System;
using UnityEngine;

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
	    if (tricks.GetComponent<MeshRenderer>().enabled)
	    {
		    if (health <= 0)
	        {
	            if (name == "Player")
	            {
	                victoryScreen.text = "Player 2 Wins";

	            }
	            else
	            {
	                victoryScreen.text = "Player 1 Wins";
	            }
	        }
	        
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
	                            Vector3 vector = transform.position - t.transform.position;
	                            actualMove -= (int)Math.Abs(vector.magnitude);
	                            transform.position = new Vector3(t.transform.position.x,transform.position.y, t.transform.position.z);
                                
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
