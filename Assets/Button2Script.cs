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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            timerScript.OverThinkingMechanic();
            timerScript.Music();
            animator.SetTrigger("PlayingMusic");
            StartCoroutine(PauseMusicAnimation());
        }

        IEnumerator PauseMusicAnimation()
        {
            animator.SetBool("isMusic", true);
            yield return new WaitForSeconds(length);
            animator.SetBool("isMusic", false);
        }

    }
}
