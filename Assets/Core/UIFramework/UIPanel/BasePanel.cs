using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    public CanvasGroup CanvasGroupValue
    {
        get
        {
	  return canvasGroup;
        }
        set
        {
	  canvasGroup = value;
        }
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //UI面板显示时调用
    public virtual void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    //暂停UI面板时调用
    public virtual void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    //恢复UI面板交互时调用
    public virtual void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }

    //隐藏UI面板时调用
    public virtual void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void OnClose()
    {
        UIManager.Instance.PopPanel();
    }
}
