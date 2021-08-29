using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIDebug : MonoBehaviour
{
    public GameObject panel;

    public void click()
    {
        Animator animator = panel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("open");
        animator.SetBool("open", !isOpen);

        // if (!isOpen) animator.speed = -1.0f;
        
    }
}
