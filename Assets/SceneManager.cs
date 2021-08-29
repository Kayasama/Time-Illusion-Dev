using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // 当前场景
    public static int currScene = 0;

    //public List<Transform> scene1Item;
    //public List<Transform> scene2Item;
    public List<Transform> scenes;

    // 不同的门跳到不同的地方
    // 场景切换，将上个场景取消，下个场景开启
    public void SceneChange(int preScene, int nextScene)
    {
        scenes[preScene].gameObject.SetActive(false);
        scenes[nextScene].gameObject.SetActive(true);
        //HideScene1Item();
    }

    #region 隐藏相应场景物体
    //public void HideScene1Item()
    //{
    //    for(int i = 0; i < scene1Item.Count; ++i)
    //    {
    //        scene1Item[i].gameObject.SetActive(false);
    //    }
    //}

    //public void HideScene2Item()
    //{
    //    for (int i = 0; i < scene2Item.Count; ++i)
    //    {
    //        scene2Item[i].gameObject.SetActive(false);
    //    }
    //}
    #endregion

    // 玩家位置设置在门口

    // 控制玩家不能飞出某区域
}
