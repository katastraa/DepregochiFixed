using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkScript : MonoBehaviour
{
    public TimerScript timerscript;
    public int i;
    public TMPro.TextMeshProUGUI displayText;
    public GameObject ImageText;
    public float velocidadLetras;
    public Button Talkbutton;
   

    // Start is called before the first frame update
    public void Start()
    {
        i = 0;
        velocidadLetras = 0.1f;
        
    }

    // Update is called once per frame
    void Update()
    {

        // Detect if the Alpha 3 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Call the method that is linked to the button press
            ActiveImageText();
            timerscript.AngerMechanic();
            
        }
    }

    public void ChangeText(string newText)
    {
        StopAllCoroutines();
        //displayText.text = newText;
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
        displayText.text = ""; // Clear the text field
        foreach (char c in text)
        {
            displayText.text += c; // Add the next character
            yield return new WaitForSeconds(velocidadLetras); // Wait before adding the next character
        }
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
}
