using UnityEngine;
using System.Collections;

public class ignitionButton : MonoBehaviour {
	public carKeyTimerScript carKeyTimer;
    public moveKeyHand moveKey;
    private bool inTheZone = false;
    public bool buttonPressed = false;
	void OnTriggerStay2D(Collider2D other) {

	}
    public void Ignite()
    {
        buttonPressed = true;
       

        if (inTheZone)
        {
            GameWin();
        }
        moveKey.TurnKey();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        inTheZone = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        inTheZone = false;
    }

    void Update()
    {
      
        if ((Input.GetKeyDown(KeyCode.Space) || buttonPressed) && moveKey.keyTurned == false && inTheZone)
        {
                //Debug.Log ("win");
                //  Debug.Log("TRIGGERED");
                GameWin();
        }
        if (moveKey.keyTurned && carKeyTimer.GameWin == false && !inTheZone)
        {
            moveKey.stopmovement = true;
            moveKey.MissClick.SetActive(true);
            moveKey.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }


    }
  

    public void GameWin()
    {
        carKeyTimer.GameWin = true;
        carKeyTimer.dontPlayCarStartup = false;
    }
}
