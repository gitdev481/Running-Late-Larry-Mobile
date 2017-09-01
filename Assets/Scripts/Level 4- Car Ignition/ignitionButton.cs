using UnityEngine;
using System.Collections;

public class ignitionButton : MonoBehaviour {

    private bool handInTheZone = false;
    public  bool buttonPressed = false;

    public carKeyTimerScript carKeyTimer;
    public moveKeyHand moveKey;
   
    void Update()
    {
        CheckIfLevelFinished();
        CheckIfPlayerMissed();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        handInTheZone = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        handInTheZone = false;
    }

    void CheckIfLevelFinished()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || buttonPressed) && moveKey.keyTurned == false && handInTheZone)
            GameWin();
    }
    void CheckIfPlayerMissed()
    {
        if (moveKey.keyTurned && carKeyTimer.GameWin == false && !handInTheZone)
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

    public void Ignite()
    {
        buttonPressed = true;

        if (handInTheZone)
        {
            GameWin();
        }
        moveKey.TurnKey();
    }
}