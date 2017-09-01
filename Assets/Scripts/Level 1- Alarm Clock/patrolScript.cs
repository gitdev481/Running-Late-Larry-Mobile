using UnityEngine;
using System.Collections;

public class patrolScript : MonoBehaviour {

	public float Speed;
	public int curWayPoint;
	public bool doPatrol = true;

	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;

    public Transform[] Waypoints;
    public Animator handAnimator;
	public GameObject winPanel;
	public alarmClockTimer timer;
    public GameObject winSoundObject;

    void Update ()
    {
        SetHandBool();
        ControlHandMovement();
    }

    void SetHandBool()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handAnimator.SetBool("spacebarHeld", true);
        }
        else
        {
            handAnimator.SetBool("spacebarHeld", false);
        }

        #if UNITY_ANDROID || UNITY_IOS
        for (int i = 0; i < Input.touchCount; ++i)
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
    }

    void ControlHandMovement()
    {
        if (curWayPoint < Waypoints.Length)
        {
            Target = Waypoints[curWayPoint].position;
            MoveDirection = Target - transform.position;
            Velocity = GetComponent<Rigidbody2D>().velocity;

            if (MoveDirection.magnitude < 7.5)
            {
                curWayPoint++;
            }
            else
            {
                Velocity = MoveDirection.normalized * Speed;
            }
        }
        else
        {
            if (doPatrol)
            {
                curWayPoint = 0;
            }
            else
            {
                Velocity = Vector3.zero;
            }
        }
        GetComponent<Rigidbody2D>().velocity = Velocity;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                winSoundObject.SetActive(true);
                winPanel.SetActive(true);
                timer.GameWin = true;
            }
        #if UNITY_ANDROID || UNITY_IOS
        for (int i=0; i < Input.touchCount; ++i) {
            if ( (Input.GetTouch(i).phase == TouchPhase.Began))
                {
                    winSoundObject.SetActive(true);
                    winPanel.SetActive(true);
                    timer.GameWin = true;
                }
        }
        #endif
    }
}