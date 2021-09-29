using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemUIAnim : MonoBehaviour
{
    private Image self;
    public Animator panelAnimator;
    private static bool animStop = false;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Image>();
        self.CrossFadeAlpha(0, 0f, true);
    }

    private void okkk()
    {
        animStop = true;
    }

    private void Update()
    {
        if(panelAnimator.GetBool("open") && !isOpen)
        {
            
            self.CrossFadeAlpha(1, 0.8f, false);
            isOpen = true;
            
            
        }
        if(!panelAnimator.GetBool("open") && isOpen)
        {
            self.CrossFadeAlpha(0, 0.8f, false);
            isOpen = false;
            
        }
    }


}
