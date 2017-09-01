using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoffeeFilling : MonoBehaviour {

	public SpriteRenderer CoffeeEmpty;

	public Image CoffeeFull;
	public Image CoffeePour;

	float timeToFill = 4.0f;
	float currentFillTime = 0.0f;
	float timeElapsed;

	public GameObject winningText;
	public GameObject losingText;
	public GameObject poop;
	public GameObject fartGameObject;
	public GameObject notEnoughCoffeePanel;
    public GameObject theCoffeePour;

    public AudioSource winSound;
    public AudioSource fartSound;
    public AudioSource coffeePourSound;

	public TimerCoffee timercoffee;

    public  bool terribleCoffee = false;
    private bool notEnoughCoffee;
    public  bool pourTheCoffee = true;
    private bool levelComplete = false;
    private bool mainButtonClicked = false;

   
    void Update ()
    {
        FillCoffeeCup();
        UpdateGlobalTime();
        CheckInput();
        CheckForLevelCompletion();
        CheckTimeElapsed();
    }
    private void FillCoffeeCup()
    {
        if (pourTheCoffee)
        {
            CoffeeFull.fillAmount += Mathf.Lerp(0.0f, 1.0f, currentFillTime * Time.deltaTime);
            CoffeePour.fillMethod = Image.FillMethod.Vertical;
        }
    }
    private void UpdateGlobalTime()
    {
        currentFillTime += Time.deltaTime / timeToFill;
        timeElapsed += Time.deltaTime;
    }
    private void CheckInput()
    {
        if ((Input.GetKey(KeyCode.Space) || mainButtonClicked) && timeElapsed >= 2.5f && timeElapsed <= 3.5f && !notEnoughCoffee)
        {
            if (levelComplete == false)
            {
                CoffeeFull.fillAmount = 1.0f;
                winSound.Play();
                winningText.SetActive(true);
                levelComplete = true;
                timercoffee.GameWin = true;
            }
        }
        if ((Input.GetKey(KeyCode.Space) || mainButtonClicked) && timeElapsed < 2.5f)
        {
            pourTheCoffee = false;
            notEnoughCoffee = true;
            notEnoughCoffeePanel.SetActive(true);
            coffeePourSound.Stop();
            theCoffeePour.SetActive(false);
        }
    }
    private void CheckForLevelCompletion()
    {
        if (levelComplete == true)
        {
            if (timeElapsed >= 4.5f)
            {
                Application.LoadLevel(4);
            }
        }
        if (timeElapsed >= 5.0f)
        {
            Application.LoadLevel("GameOverScene");
        }
    }

    private void CheckTimeElapsed()
    {
        if (timeElapsed >= 1.25f && pourTheCoffee)
        {
            CoffeePour.fillAmount -= Mathf.Lerp(0.0f, 0.54f, currentFillTime * Time.deltaTime * 1.4f);
        }
        if (timeElapsed >= 4.0f)
        {
            if (levelComplete == false)
            {
                losingText.SetActive(true);
                poop.SetActive(true);
                fartGameObject.SetActive(true);
            }
        }
    }

    public void ScreenButtonClicked()
    {
        mainButtonClicked = true;
    }
}