using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class moveKeyHand : MonoBehaviour {

	public int state = 0;
	public int attempt;

	private float speed =2.5f;
    private float mobileSpeed = 2.5f;
    public  float vibrateSpeed = 1f;
	public  float vibrateAmount = 30;
	public  float moveAmount = 0.001f;
	
	public carKeyTimerScript carKeyTimer;
	public GameObject MissClick;
    public Animator handAnimator;
    public ignitionButton ignitionScript;

    public bool powerButtonPressed = false;
	public bool stopmovement = false;
    public bool keyTurned = false;

	void Start()
    {
		attempt = 1;
		carKeyTimer.GameWin = false;
    }

    void Update()
    {
        ManageGameWin();
        ManageHandMovement();
    }

    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * mobileSpeed;
        GetComponent<Rigidbody2D>().AddForce(moveVec);
    }

    void ManageGameWin()
    {
        if (carKeyTimer.GameWin == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            handAnimator.SetBool("turnKey", true);
        }
    }

    void ManageHandMovement()
    {
        if (carKeyTimer.GameWin == false)
        {
            if (stopmovement == false)
            {
                MoveRandomDirection();

                if (Input.GetKeyDown(KeyCode.Space) || powerButtonPressed)
                {
                    TurnKey();
                }
                else
                {
                    handAnimator.SetBool("turnKey", false);
                }

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

    public void TurnKey()
    {
        handAnimator.SetBool("turnKey", true);
        powerButtonPressed = true;
        keyTurned = true;
    }

	void MoveRandomDirection()
    {
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