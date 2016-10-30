using UnityEngine;
using System.Collections;

public class ignitionButton : MonoBehaviour {
	public carKeyTimerScript carKeyTimer;
    public moveKeyHand moveKey;
	void OnTriggerStay2D(Collider2D other) {
		
	
		if (Input.GetKeyDown (KeyCode.Space) && moveKey.keyTurned == false) {
            //Debug.Log ("win");
           // Debug.Log("TRIGGERED");
			carKeyTimer.GameWin = true;
			carKeyTimer.dontPlayCarStartup = false;
		}
	}
}
