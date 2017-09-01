using UnityEngine;
using System.Collections;

public class BrushTeeth : MonoBehaviour {

	string prevKeyboardSetting = "Right";
	int count; //Count for how many times buttons have been pressed
	float tCount; //Count of real seconds
	int textCount;
	bool what, failed;
	float cCount;
	public GameObject text;
	public GameObject fired;

	public GameObject fail;
	public GameObject leftArrowFilled, rightArrowFilled; 
	public GameObject toothBrush; //Toothbrush
	public GameObject cleanTeeth; //Cleen teeth
	Vector3 ty, tx, cy; //The amount to move the toothbrush by each key stroke
	public GameObject winPanel;
	public TimerTeeth timerTeeth;

	public AudioSource vibrate;
	public AudioSource gameWinSound;
    public GameObject winSound;
    public TimerTeeth teethTimer;

    public float overBrushTimer = 0f;
    public float overBrushTimerThreshold = 1f;

    private bool timerActive = true;
    private bool gameWon = false;
    public bool gameReallyWon = false;

    private bool leftButtonClicked = false;
    private bool rightButtonClicked = false;

	void Start()
	{
		failed = false;
        teethTimer = this.GetComponent<TimerTeeth>();
	}

	void Update ()
    {
		if (what)
        {
			what = false;
			text.SetActive(false);
		}
        if (timerTeeth.GameWin == false )
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || leftButtonClicked) && prevKeyboardSetting != "Left")
            {
                leftButtonClicked = false;
                ty = new Vector3(0, -4, 0);
                toothBrush.GetComponentInParent<Transform>().position += ty;
                cy = toothBrush.GetComponentInParent<Transform>().position;
                cy += new Vector3(2.7f, 4.75f, 3.5f);
                Instantiate(cleanTeeth, cy, Quaternion.identity);
                prevKeyboardSetting = "Left";
                leftArrowFilled.SetActive(false);
                rightArrowFilled.SetActive(true);
                cCount = 0.0f;
                vibrate.Play();
                count++;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || rightButtonClicked) && prevKeyboardSetting != "Right")
            {
                rightButtonClicked = false;
                ty = new Vector3(0, 4, 0);
                toothBrush.GetComponentInParent<Transform>().position += ty;
                tx = new Vector3(2, 0, 0);
                toothBrush.GetComponentInParent<Transform>().position += tx;
                prevKeyboardSetting = "Right";
                leftArrowFilled.SetActive(false);
                rightArrowFilled.SetActive(true);
                cCount = 0.0f;
                vibrate.Play();
                count++;
            }
        }
		if (count == 17) {
			what = true;
            timerActive = false;
            overBrushTimer += Time.deltaTime;  
            gameWon = true;
        }
		if (count >= 18 && !gameWon) {
			failed = true;
            timerActive = false;  
		}
		if (overBrushTimer >= overBrushTimerThreshold && !failed && gameWon) {
            Debug.Log("Teeth clean");
            winSound.SetActive (true);
			tCount = 0.0f;
			winPanel.SetActive(true);
			text.SetActive(false);
			timerTeeth.GameWin = true;
            gameWon = false;
            gameReallyWon = true;

		} else if (count >= 18) {
		
			tCount = 0.0f;
			fired.SetActive(true);
			text.SetActive(false);
		} else if(tCount >= 4.0f && failed){
			fail.SetActive(true);
			tCount = 0.0f;
			text.SetActive(false);
		}
		
        if (timerActive && !failed)
        {
            cCount += Time.deltaTime;
            tCount += Time.deltaTime;
        }
	}

    public void LeftButtonClicked()
    {
        leftButtonClicked = true;
    }
    public void RightButtonClicked()
    {
        rightButtonClicked = true;
    }
}