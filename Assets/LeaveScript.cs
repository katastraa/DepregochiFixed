using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LeaveScript : MonoBehaviour
{
    public TimerScript timerScript;
    public Audiomanager audiomanager;
    public AudioClip puerta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            timerScript.Leave();
            timerScript.LeavingMechanic();
            audiomanager.ReproducirSonido(puerta);

        }
       
    }

}
