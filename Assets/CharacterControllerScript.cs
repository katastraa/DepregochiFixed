using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private Animator animator;
    public TimerScript timerScript;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerScript.Overstimulation == true)
        {
            animator.SetBool("isStressed", true);
        }
        else
        {
            animator.SetBool("isStressed", false);
        }

        if (timerScript.Overthink== true)
        {
            animator.SetBool("isOverthinking", true);
        }
        else
        {
            animator.SetBool("isOverthinking", false);
        }
    }
}
