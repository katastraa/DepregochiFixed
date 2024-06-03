using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkScript : MonoBehaviour
{
    public TimerScript timerScript;
    public int i;
    public TMPro.TextMeshProUGUI displayText;
    public GameObject ImageText;
    public float velocidadLetras, velocidadExtra, auxTimeLeft, clickCount;
    public Button Talkbutton;
    private Button _button3;

    public Audiomanager audiomanager;
    public AudioClip Voz;


    // Start is called before the first frame update
    public void Start()
    {
        i = 0;
        velocidadLetras = 0.1f;
        velocidadExtra = 2.0f;
        auxTimeLeft = 0;
        clickCount = 1;
    }

    private void Awake()
    {
        Talkbutton = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {

        // Detect if the Alpha 3 key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Call the method that is linked to the button press
            ActiveImageText();
            timerScript.AngerMechanic();
            FadeToColor3(Talkbutton.colors.pressedColor);
            audiomanager.ReproducirSonido(Voz);

        }else if (Input.GetKeyUp(KeyCode.B))
        {
            FadeToColor3(Talkbutton.colors.normalColor);
        }
    }

    void FadeToColor3(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, Talkbutton.colors.fadeDuration, true, true);
    }

    public void ChangeText(string newText)
    {
        StopAllCoroutines();
        StartCoroutine(TypeText(newText));
    }

    public void AttackText()
    {
        if (i == 0)
            ChangeText("No me apetece hablar");
        if (i == 1)
            ChangeText("No creo que tengamos nada de lo que hablar");
        if (i == 2)
            ChangeText("Te estoy diciendo que no necesito nada");
        if (i == 3)
            ChangeText("No necesito ayuda");
        if (i == 4)
            ChangeText("Déjame");
        i++;
        if (i == 5)
            i = 0;
    }

    IEnumerator TypeText(string text)
    {
        PauseTimer();
        displayText.text = ""; // Clear the text field
        foreach (char c in text)
        {
            displayText.text += c; // Add the next character
            yield return new WaitForSeconds(velocidadLetras); // Wait before adding the next character
        }
        //--
        yield return new WaitForSeconds(velocidadExtra); // Esto es para esperar un tiempo extra d lectura y luego se desactive el texto
        DesactiveImageText(); //si quires que funcione como antes que habia que pulsar el boton para que se desactive el texto, quita esta linea
        //--
        ResumeTimer();
    }

    public void ActiveImageText()
    {
        ImageText.SetActive(true);
        AttackText();
    }

    public void DesactiveImageText()
    {
        ImageText.SetActive(false);
    }


    public void PauseTimer()
    {
        if (timerScript.isTimerPaused == false)
        {
            auxTimeLeft = TimerScript.timeLeft;
            timerScript.auxImage.fillAmount = auxTimeLeft / timerScript.maxTime;
            Debug.Log("<color=orange>PauseTimer: auxTimeLeft: " + auxTimeLeft + "</color>"); //esto es para debbugear, se puede quitar
            timerScript.timerspeed=0;
            timerScript.isTimerPaused = true;
        }
        clickCount += 0.0f; //cuanto mas valor le des a esto mas rapido ira el timerLeft cuando se reanude en ResumeTimer
    }
    public void ResumeTimer()
    {
        if (timerScript.isTimerPaused == true)
        {
            timerScript.auxImage.fillAmount = 0;
            TimerScript.timeLeft = auxTimeLeft;
            timerScript.timerspeed = 1 * clickCount;
            //Debug.Log("<color=blue>ResumeTimer: clicksCount: " + timerScript.timerspeed + "</color>");
            timerScript.isTimerPaused = false;
            auxTimeLeft = 0;
        }
        clickCount = 1;
    }

    
}
