using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	float xspeed = 0f;
	public float power = 0.005f;
	float friction = 0.95f;
	float steering = 2.0f;
	bool forward = false;
	bool backward = false;
	
	
	public float fuel = 2;
	
	
	// Use this for initialization
	void FixedUpdate () {
		
		
		if(forward){
			xspeed += power;
			fuel -= power;
		}
		if(backward){
			xspeed -= power;
			fuel -= power;
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * 2);
               GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((touchPosition.y - transform.position.y), (touchPosition.x - transform.position.x)) * Mathf.Rad2Deg - 180);
            }
        }

       

        if (GetComponent<TimerCoffee>().GameWin == false)
	    {
	
	        float turn = Input.GetAxis("Horizontal")*steering;
		
		    if(Input.GetKeyDown(KeyCode.UpArrow)){
			    forward = true;
		    }
		    if(Input.GetKeyUp(KeyCode.UpArrow)){
			    forward = false;
		    }
		    if(Input.GetKeyDown(KeyCode.DownArrow)){
			    backward = true;
		    }
		    if(Input.GetKeyUp(KeyCode.DownArrow)){
			    backward = false;
		    }
		    if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		    {
		
			    transform.Rotate(0,0,turn);
		    }
		
		}
		
		if(fuel < 0){
			
			xspeed = 0;
			
		}
		
		xspeed *= friction;
		transform.Translate(Vector2.right * -xspeed);
		
	}
}

