using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public TimerScript timerScript;
    public Animator animator;
    public float length;

    // Update is called once per frame
    void Update() //pa que funcione con el teclao
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            timerScript.OverstimulationMechanic();
            timerScript.Videogames();
            animator.SetTrigger("PlayingVideogames");
            StartCoroutine(PauseVideogameAnimation());
        }

        IEnumerator PauseVideogameAnimation()
        {
            animator.SetBool("isPlaying", true);
            yield return new WaitForSeconds(length);
            animator.SetBool("isPlaying", false);
        }
    }

    

}
