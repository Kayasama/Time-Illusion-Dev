using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIDebug : MonoBehaviour
{
    public GameObject panel;
    public Text text;

    public void click()
    {
        Animator animator = panel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("open");
        animator.SetBool("open", !isOpen);

        // if (!isOpen) animator.speed = -1.0f;
        
    }

    public void TextDisplay()
    {
        Animator animator = text.GetComponent<Animator>();
        bool isOpen = animator.GetBool("openText");
        animator.SetBool("openText", !isOpen);

    }

}
