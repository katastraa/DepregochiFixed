using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public TimerScript timerScript;
   

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update() //pa que funcione con el teclao
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            timerScript.OverstimulationMechanic();
            timerScript.Videogames();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            timerScript.OverThinkingMechanic();
            timerScript.Music();
        }
    }

    

}
