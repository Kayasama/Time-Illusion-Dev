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
    public Transform transform;
    public Image ThisItemImage;

    public ItemBaseForm()
    {
        
    }

    // 接口实现
    public void getMousePoint(Vector3 PosWant)
    {
        if (PosWant != null)
            transform.position = PosWant;
    }
}
