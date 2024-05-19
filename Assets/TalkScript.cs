using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkScript : MonoBehaviour
{
    int i;
    public TMPro.TextMeshProUGUI displayText;
    public GameObject ImageText;
    public float velocidadLetras;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        velocidadLetras = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            ChangeText("'Al siguiente truco lo llamaré Megapedo");
        if (i == 1)
            ChangeText("Party, he gomitao");
        if (i == 2)
            ChangeText("Es como si no llevara nada");
        if (i == 3)
            ChangeText(":)");
        if (i == 4)
            ChangeText("lolo");
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
