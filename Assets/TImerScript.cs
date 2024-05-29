using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Image LinearTimer;
    public float maxTime = 2;
    static public float timeLeft;
    public GameObject GameOverText;
    public bool tamaIsAlive = true;
    


    public float BonusTime = 10;

    public ButtonScript ButtonScript;

    public bool Overstimulation = false;
    public float OverstimulationTimer = 0;
    public float Overstimulatedpoints = 5;
    public float OverSPMax = 15;

    public float TimerReduction = 2;

    public bool Overthink = false;
    public float OverthinkTimer = 0;
    public float Overthinkerpoints = 5;
    public float OverTPMax = 15;

    public TalkScript talkScript;

    public bool Anger = false;
    public float AngerTimer = 0;
    public float AngerPoints = 5;
    public float AngerSPMax = 15;

    public bool isTimerPaused = false;
    public float pauseDuration = 2;
    public bool isGameOver = false;
    private float pauseEndTime;

    public GameObject MusicButton;
    public GameObject TalkButton;
    public GameObject LeaveButton;
    public GameObject VideogameButton;

    // Start is called before the first frame update
    public void Start()
    {
        GameOverText.SetActive(false);
       
        timeLeft = maxTime;
    }

    // Update is called once per frame
    public void Update()
    {
        if (timeLeft <= 0)
        {
            isGameOver = true;
        }


        if (timeLeft > 0 )
        {
            timeLeft = timeLeft - Time.deltaTime;
            LinearTimer.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft<=0 && !isGameOver)
        {
            GameOverText.SetActive (true);
            Time.timeScale = 0;
            tamaIsAlive = false;
            VideogameButton.SetActive (false);
            MusicButton.SetActive (false);
            TalkButton.SetActive (false);
            LeaveButton.SetActive (false);
        }


        
            
        if (timeLeft > maxTime) //variable capada para que no tengas tiempo infinito

        {timeLeft = maxTime;}

        if (Overstimulation == true)//reducci�n de contador x estados
        {
            timeLeft -= Time.deltaTime * TimerReduction;
        }

        if (Overthink == true)//reducci�n de contador x estados
        {
            timeLeft -= Time.deltaTime * TimerReduction/2;
        }
    }

    public void Videogames()
    {
       timeLeft += BonusTime;
        if (Overthink==true)
        {
            Overthink=false;
            OverthinkTimer = 0;
        }
        talkScript.DesactiveImageText();
    }
    public void OverstimulationMechanic ()
    {
        OverstimulationTimer += Overstimulatedpoints;
        if (OverstimulationTimer >= OverSPMax)
        {
            Overstimulation = true;
            OverstimulationTimer = OverSPMax;
        }
    }

    public void Music ()
    {
        timeLeft += BonusTime / 2;
        if (Overstimulation == true)
        {
            Overstimulation = false;
            OverstimulationTimer = 0;
        }

        talkScript.DesactiveImageText();
       
    }
    public void OverThinkingMechanic ()
    {
        OverthinkTimer += Overthinkerpoints;

        if (OverthinkTimer >= OverTPMax)
        {
            Overthink = true;
            OverthinkTimer = OverTPMax;
        }
    }
   
    public void AngerMechanic ()
    {
        timeLeft = 0;
        AngerTimer += AngerPoints;

        if (AngerTimer >= AngerSPMax)
        {
            Anger = true;
            AngerTimer = AngerSPMax;
        }
    }
    public void PauseTimer()
    {
        isTimerPaused = true;
    }

    public void Leave()
    {
        MusicButton.GetComponent<Button>().interactable = false;
        TalkButton.GetComponent<Button>().interactable = false;
        LeaveButton.GetComponent<Button>().interactable = false;
        VideogameButton.GetComponent<Button>().interactable = false;

    }
}

