
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region 控制Ui改变
    public Slider longTouchSlider;
    public List<Image> itemUiGroup;
    public Text requestText;
    public Animator ani;

    private void Start()
    {
        // 物品UI容器
        itemUiGroup = new List<Image>(3);

    }



    // 改变物品栏Ui
    public void ChangeImage()
    {
        // TODO
    }


    // 修改物品栏视图
    public void ModifyView()
    {
        // TODO
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

    #endregion
}
