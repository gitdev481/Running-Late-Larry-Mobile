using UnityEngine;
using System.Collections;

public class moveKeyHand : MonoBehaviour {

	public float speed =10f;
	public Animator handAnimator;


	public float vibrateSpeed = 1f;
	public int state = 0;
	public float vibrateAmount = 30;
	public float moveAmount = 0.001f;
	public static int attempt = 1;
	
	public carKeyTimerScript carKeyTimer;
	
	public GameObject MissClick;
	
	public bool stopmovement = false;

    public bool keyTurned = false;


	void Start(){
	//	Vector3 randomDirection = new Vector3 (Random.value, Random.value, 0);
		
		attempt = 1;
		
		carKeyTimer.GameWin = false;

	}

	void Update ()
	{ 
		if ( carKeyTimer.GameWin == true)
		{
			
			//GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed);
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			handAnimator.SetBool ("turnKey", true);
			//GetComponent<Rigidbody2D>().angularVelocity = Vector3.zero; 
		}
        if(keyTurned && carKeyTimer.GameWin == false)
        {
            stopmovement = true;
            MissClick.SetActive(true);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
		
	if(carKeyTimer.GameWin == false)
	 {

            //if (attempt == 0)
            //{
            //    Debug.Log("LOSE");
            //    stopmovement = true;
            //    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //    //  Debug.Log (" madonna");
            //    MissClick.SetActive(true);
            //}
            if (stopmovement == false)
	           {
		        MoveRandomDirection ();
		
		

			        //changes the hand sprite/animation
			        if (Input.GetKeyDown (KeyCode.Space)/* && attempt > 0*/) {
			
			    
				        handAnimator.SetBool ("turnKey", true);
                    // attempt -= 1;
                    keyTurned = true;  
                    //Debug.Log("spacebar test");
			        } else {
				        handAnimator.SetBool ("turnKey", false);
			        }
	
			        //for moving hand up, down, left and right.
			        if (Input.GetKey(KeyCode.LeftArrow))
			        {
				        GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed);
			        }
			        if (Input.GetKey(KeyCode.RightArrow))
			        {
				        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
			        }
			        if (Input.GetKey(KeyCode.UpArrow))
			        {
				        GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
			        }
			        if (Input.GetKey(KeyCode.DownArrow))
			        {
				        GetComponent<Rigidbody2D>().AddForce(-Vector2.up * speed);
			        }
		        }
		
		
		}
		
		
	}

	void MoveRandomDirection(){
		state = Random.Range (1, 4);

		if (state == 1) {
			transform.position +=  new Vector3(0,vibrateAmount,0) * vibrateSpeed * Time.deltaTime;
		} else if (state == 2) {
			transform.position += new Vector3(0,-vibrateAmount,0) * vibrateSpeed * Time.deltaTime;
		} else if (state == 3) {
			transform.position += new Vector3(-vibrateAmount,0,0) * vibrateSpeed * Time.deltaTime;
		} else {
			transform.position += new Vector3(vibrateAmount,0,0) * vibrateSpeed * Time.deltaTime;
		}

	
	}
}
