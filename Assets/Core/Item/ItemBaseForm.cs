using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 物品基类
/// </summary>
/// 

[SerializeField]
public enum ItemLabel
{
    door = 0,
    sceneItem = 1
}

[SerializeField]
public class ItemBaseForm : ICommon
{
    //private bool canTake = false;
    //public Vector3 wantPos;
    public Transform transform;
    public Image ThisItemImage;
    //private string ItemName;

    // 临时代码
    public UiManager uiManager;

    public ItemBaseForm()
    {
        
    }

    #region 遗弃代码

    // 玩家检测，是给物品自身调用的
    //public void NearPlayerCheck(Transform self, Transform player)
    //{
    //    if (player == null)
    //        return;
    //    float curDistance = Vector3.Distance(player.position, self.position);
    //    float curAngle = Mathf.Abs(Vector3.Angle(self.forward, player.position - self.position));

    //    if (curDistance < checkDistance && curAngle < checkAngle)
    //    {
    //        Debug.Log("Player is near...");
    //        InfoDisplay(self.tag);
    //        Debug.Log(self.tag);
    //        //return true;
    //    }
    //    //else
    //    //    GameManager.curNearState = NearState.nothing;
    //    /*return false*/
    //}
    #endregion

    // 接口实现
    public void getMousePoint(Vector3 PosWant)
    {
        if (PosWant != null)
            transform.position = PosWant;
    }
    #region 遗弃代码
    // 物品可获取信息显示
    //public void InfoDisplay(string IdTag)
    //{
    //    if(IdTag == "door")
    //    {
    //        Debug.Log("按e键切场景");
    //        GameManager.curNearState = NearState.door;
    //    }
    //    else if(IdTag == "Item")
    //    {
    //        Debug.Log("可获取");
    //        GameManager.curNearState = NearState.item;
    //    }
    //    else if(IdTag == "DocumentEquip")
    //    {
    //        GameManager.curNearState = NearState.Doc;
    //        Debug.Log("档案装置");
    //    }

    //}
    #endregion
}
