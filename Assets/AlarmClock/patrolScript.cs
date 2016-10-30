using UnityEngine;
using System.Collections;

public class patrolScript : MonoBehaviour {

	public Transform[] Waypoints;
	public float Speed;
	public int curWayPoint;
	public bool doPatrol = true;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;

	public Animator handAnimator;

	public GameObject winPanel;
	public alarmClockTimer timer;
	//public AudioSource winSound;
    public GameObject winSoundObject;

	
	// Update is called once per frame

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			handAnimator.SetBool ("spacebarHeld", true);
			//Debug.Log("spacebar test");
		} else
        {
			handAnimator.SetBool ("spacebarHeld", false);
        }

#if UNITY_ANDROID
        for(int i = 0; i < Input.touchCount; ++i)
        {
            if ((Input.GetTouch(i).phase == TouchPhase.Began))
            {
                handAnimator.SetBool("spacebarHeld", true);
              
            }
            else
            {
                handAnimator.SetBool("spacebarHeld", false);
            }
        }
       

#endif


        //Debug.Log (MoveDirection.magnitude);

        if (curWayPoint < Waypoints.Length) {
			Target = Waypoints [curWayPoint].position;
			MoveDirection = Target - transform.position;
			Velocity = GetComponent<Rigidbody2D>().velocity;

			if (MoveDirection.magnitude < 7.5) {
				curWayPoint++;
			} else {
				Velocity = MoveDirection.normalized * Speed;
			}
		} else {
			if (doPatrol) {
				curWayPoint = 0;
			} else {
				Velocity = Vector3.zero;
			}
		}

	GetComponent<Rigidbody2D>().velocity = Velocity;
	
		//get the farmer to look at the current waypoint.
		//float angle = Mathf.Atan2 (MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);


	}


	void OnTriggerStay2D(Collider2D other) {
		//Debug.Log ("collided");
        for(int i=0; i < Input.touchCount; ++i) {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(i).phase == TouchPhase.Began))
        {
            //Debug.Log ("win");
            //winSound.Play ();
            winSoundObject.SetActive(true);
            winPanel.SetActive(true);
            timer.GameWin = true;
        }
        }

    }
}
