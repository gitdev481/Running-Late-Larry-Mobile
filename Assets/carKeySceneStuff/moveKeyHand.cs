using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class moveKeyHand : MonoBehaviour {

	private float speed =2.5f;
    private float mobileSpeed = 2.5f;
	public Animator handAnimator;

    public ignitionButton ignitionScript;
	public float vibrateSpeed = 1f;
	public int state = 0;
	public float vibrateAmount = 30;
	public float moveAmount = 0.001f;
	public static int attempt = 1;
    public bool powerButtonPressed = false;
	
	public carKeyTimerScript carKeyTimer;
	
	public GameObject MissClick;
	
	public bool stopmovement = false;

    public bool keyTurned = false;

 
	void Start(){
		attempt = 1;
		
		carKeyTimer.GameWin = false;
       
    }

    public void TurnKey()
    {
        handAnimator.SetBool("turnKey", true);
        powerButtonPressed = true;
        keyTurned = true;
       
    }

    void Update()
    {
        if (carKeyTimer.GameWin == true)
        {

            //GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            handAnimator.SetBool("turnKey", true);
            //GetComponent<Rigidbody2D>().angularVelocity = Vector3.zero; 
        }
    

        if (carKeyTimer.GameWin == false)
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
                MoveRandomDirection();



                //changes the hand sprite/animation
                if (Input.GetKeyDown(KeyCode.Space) || powerButtonPressed)
                {
                    TurnKey();
                    //Debug.Log("spacebar test");
                }
                else
                {
                    handAnimator.SetBool("turnKey", false);
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

    void LateUpdate()
    {
        //if (keyTurned && carKeyTimer.GameWin == false)
        //{
        //    stopmovement = true;
        //    MissClick.SetActive(true);
        //    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //}
    }
    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * mobileSpeed;
        GetComponent<Rigidbody2D>().AddForce(moveVec) ;
        Debug.Log(moveVec);
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
