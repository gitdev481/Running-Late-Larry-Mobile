using UnityEngine;
using System.Collections;

public class alarmClockButton : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) {

		//Debug.Log ("collided");
		if (Input.GetKeyDown (KeyCode.Space)) {
            //	Debug.Log ("win");

        }
	}
}
