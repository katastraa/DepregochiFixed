using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Image LinearTimer, auxImage;
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
    public float timerspeed = 1;

    public GameObject MusicButton;
    public GameObject TalkButton;
    public GameObject LeaveButton;
    public GameObject VideogameButton;

    // Start is called before the first frame update
    public void Start()
    {
        GameOverText.SetActive(false);
       
        timeLeft = maxTime;
        auxImage.fillAmount = 0;
    }

    float previousTimeLeft = -1; //esto es para debbugear, se puede quitar
    // Update is called once per frame
    public void Update()
    {
        if (timeLeft != previousTimeLeft) //esto es para debbugear, se puede quitar
        {
            Debug.Log("<color=green>timeLeft = " + timeLeft + "</color>");
            previousTimeLeft = timeLeft;
        }
        //---------
        
        if (timeLeft > 0)
        {
            timeLeft = timeLeft - timerspeed * Time.deltaTime;
            LinearTimer.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft <= 0 && isTimerPaused == false)
        {
            GameOverText.SetActive (true);
            Time.timeScale = 0;
            tamaIsAlive = false;
            VideogameButton.SetActive (false);
            MusicButton.SetActive (false);
            TalkButton.SetActive (false);
            LeaveButton.SetActive (false);
        }else if (isTimerPaused == true) 
        {
            timeLeft = timeLeft - timerspeed * Time.deltaTime;
            LinearTimer.fillAmount = timeLeft / maxTime;
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

        if (Anger == true)//reducci�n de contador x estados
        {
            timeLeft -= Time.deltaTime * TimerReduction;
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
        Debug.Log("Videogames: timeLeft = " + timeLeft);
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
        Debug.Log("<color=red>Music: timeLeft = " + timeLeft + "</color>");
       
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

    public void LeavingMechanic ()
    {
        if (Anger == true)
        {
            Anger = false;
            AngerTimer = 0;
        }

        if (Anger == false)
        {
            Overthink = true;
        }
    }

/*     public void PauseTimer() //lo he puesto en TalkScript
    {
        auxTimeLeft = timeLeft;
        timerspeed=0;
        isTimerPaused = true;
    } */

    public void Leave()
    {
        //estas dos lineas son para que el contador de tiempo se pare cuando se desactivan los botones, si no lo quieres asi puedes quitarlas
        //TalkScript talkScript = TalkButton.GetComponent<TalkScript>();
        //talkScript.PauseTimer();
        //----------------

        MusicButton.GetComponent<Button>().interactable = false;
        TalkButton.GetComponent<Button>().interactable = false;
        LeaveButton.GetComponent<Button>().interactable = false;
        VideogameButton.GetComponent<Button>().interactable = false;
        StartCoroutine(ResumeButtons());
    }

    IEnumerator ResumeButtons()
    {
        yield return new WaitForSeconds(pauseDuration); //pauseDuration es el tiempo que quieres que los botones esten desactivados
        MusicButton.GetComponent<Button>().interactable = true;
        TalkButton.GetComponent<Button>().interactable = true;
        LeaveButton.GetComponent<Button>().interactable = true;
        VideogameButton.GetComponent<Button>().interactable = true;

        //estas dos lineas son para que el contador de tiempo se reanude cuando se activan los botones, si no lo quieres asi puedes quitarlas
        //TalkScript talkScript = TalkButton.GetComponent<TalkScript>();
        //talkScript.ResumeTimer();
        //----------------
    }
}

