using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public TimerScript timerScript;
    public Animator animator;
    public float length;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update() //pa que funcione con el teclao
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        { 
            timerScript.OverstimulationMechanic();
            timerScript.Videogames();
            animator.SetTrigger("PlayingVideogames");
            StartCoroutine(PauseVideogameAnimation());
            FadeToColor(_button.colors.pressedColor);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            FadeToColor(_button.colors.normalColor);
        }

        IEnumerator PauseVideogameAnimation()
        {
            animator.SetBool("isPlaying", true);
            yield return new WaitForSeconds(length);
            animator.SetBool("isPlaying", false);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }
    

}
