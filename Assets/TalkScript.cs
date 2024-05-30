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
    public float velocidadLetras, velocidadExtra, auxTimeLeft;
    public Button Talkbutton;
   

    // Start is called before the first frame update
    public void Start()
    {
        i = 0;
        velocidadLetras = 0.1f;
        velocidadExtra = 2.0f;
        auxTimeLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // Detect if the Alpha 3 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Call the method that is linked to the button press
            ActiveImageText();
            timerScript.AngerMechanic();
            
        }
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
        auxTimeLeft = TimerScript.timeLeft;
        Debug.Log("<color=orange>PauseTimer: auxTimeLeft: " + auxTimeLeft + "</color>"); //esto es para debbugear, se puede quitar
        timerScript.timerspeed=0;
        timerScript.isTimerPaused = true;
    }
    public void ResumeTimer()
    {
        TimerScript.timeLeft = auxTimeLeft;
        timerScript.timerspeed = 1;
        timerScript.isTimerPaused = false;
    }
}
