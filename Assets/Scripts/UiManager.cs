using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 管理游戏所有UI
/// </summary>
/// 

public enum UIFormShowMode
{
    Normal,  // 普通模式
    ReverseChange,  // 反向切换
    HideOther   // 隐藏其他界面
}

public class UiManager : MonoBehaviour
{
    // 管理实例
    private static UiManager _instance = null;
    private Dictionary<string, string> _DicUIFormsPaths;
    private Dictionary<string, BaseUiForm> _DicALLUIForms;

    private Stack<BaseUiForm> _currentUiForm;
    public Animator ani;
    

    #region 控制Ui改变
    private Canvas canvas;
    public Slider longTouchSlider;
    public List<Image> itemUiGroup;
    public Text requestText;

    private void Start()
    {
        canvas = this.GetComponentInChildren<Canvas>();
        //Debug.Log(canvas.targetDisplay);
        // 开发风格
        itemUiGroup = new List<Image>(3);
        
    }

    //public static UiManager GetInstance()
    //{
    //    if (_instance == null)
    //        _instance = new GameObject("UiManager").AddComponent<UiManager>();
    //    return _instance;
    //}


    //public void ShowUiForm(string strUiForm)
    //{
    //    //BaseUiForm baseUiForm;

    //    if (string.IsNullOrEmpty(strUiForm)) return;
    //}

    // 改变Ui
    public void ChangeImage()
    {

    }

    // 修改物品栏视图
    public void ModifyView()
    {

    }

    // 要求玩家拿出令牌的信息
    public void requestForToken()
    {
        longTouchSlider.gameObject.SetActive(true);
        requestText.gameObject.SetActive(true);
        requestText.text = "请拿出令牌，并长按空格键";
    }

    public void HideRequestForToken()
    {
        longTouchSlider.gameObject.SetActive(false);
        requestText.gameObject.SetActive(false);
        requestText.text = " ";
    }

    public void sliderScroll(float value)
    {
        longTouchSlider.value = value;
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        ani.SetTrigger("FadeOut");

    //    }

    //}

    #endregion
}
