using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class alarmClockTimer : MonoBehaviour {
	
	public float  levelTimer;
	public float timepassed;
    public float winTimer = 0.0f;
    public float introTimer = 0.0f;

    public bool startTimer = false;
	public bool GameOver = false;
	public bool GameWin = false;
           bool introOver = false;

    private const int MaxSceneLoaded = 10;
    public Text TimerFormat;
    public GameObject introPanel;
	public AudioSource annoyingAlarm;
	
	void Start ()
    {
		startTimer = true;
	}

    void Update()
    {
        ManageGameOver();
        ManageIntroTimer();
        ManageMainTimer();
        ManageWinTimer();
    }

    void ManageGameOver()
    {
        if (GameOver == true)
        {
            Application.LoadLevel("GameOverScene");
        }
    }

    void ManageIntroTimer()
    {
        if (introOver == false)
        {
            introTimer += Time.deltaTime;
        }
        if (introTimer >= 0.7f)
        {
            introPanel.SetActive(false);
            introOver = true;
        }
    }

    void ManageMainTimer()
    {
        if (startTimer == true)
        {
            if (GameWin == false)
            {
                levelTimer = 5.0f;
                timepassed += Time.deltaTime;
                System.TimeSpan t = (System.TimeSpan.FromSeconds(levelTimer)) - (System.TimeSpan.FromSeconds(timepassed));
                TimerFormat.text = string.Format("{0:D2}:{1:D2}", t.Seconds, t.Milliseconds);

                if (t.Seconds <= 0 && t.Milliseconds <= 0)
                {
                    TimerFormat.text = "0:00";
                    GameOver = true;

                }
            }
        }
    }

    void ManageWinTimer()
    {
        if (GameWin == true)
        {
            annoyingAlarm.Stop();
            introPanel.SetActive(false);
            winTimer += Time.deltaTime;
        }
        if (winTimer >= 1.5f)
        {
            Application.LoadLevel(2);
        }
    }
}