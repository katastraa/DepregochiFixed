using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button2Script : MonoBehaviour
{
    public Animator animator;
    public TimerScript timerScript;
    public float length;
    private UnityEngine.UI.Button _button2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        _button2 = GetComponent<UnityEngine.UI.Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            timerScript.OverThinkingMechanic();
            timerScript.Music();
            animator.SetTrigger("PlayingMusic");
            StartCoroutine(PauseMusicAnimation());
            
            FadeToColor2(_button2.colors.pressedColor);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            FadeToColor2(_button2.colors.normalColor);
        }

       

        IEnumerator PauseMusicAnimation()
        {
            
            animator.SetBool("isMusic", true);
            yield return new WaitForSeconds(length);
            animator.SetBool("isMusic", false);
        }
    }

    void FadeToColor2(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button2.colors.fadeDuration, true, true);
    }
}
