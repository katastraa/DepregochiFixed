using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndtextScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI displayText;
    public GameObject ImageText;
    public float velocidadLetras, velocidadExtra, auxTimeLeft, clickCount;
    public int i;

    

    // Start is called before the first frame update
    void Start()
    {
        ActiveImageText();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText(string newText)
    {
        StopAllCoroutines();
        StartCoroutine(TypeText(newText));
    }

    public void AttackText()
    {
        if (i == 0)
            ChangeText("Al final lo que queda es que lo has intentado");
    }

    IEnumerator TypeText(string text)
    {
        
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
