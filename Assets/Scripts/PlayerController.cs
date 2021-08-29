using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    // 鼠标点指向对应的方块
    // Engine.SendCameraLookEvent , Range

    public float speed;
    public float CheckRadius;
    //public int itemInHand = 0;


    //private Vector3 distanceWithPlayer;
    //private void Start()
    //{
    //    distanceWithPlayer = Camera.main.transform.position - this.transform.position;
    //}
    // 人物检测
    public void checkItemInScene()
    {
        RaycastHit hit;
        string[] layerName = { "Item", "Door", "Doc" };

        //Physics.SphereCast(this.transform.position, CheckRadius, transform.forward, out hit, 0.1f, ~LayerMask.GetMask("Terrain"))

        Collider[] cols = Physics.OverlapSphere(this.transform.position, CheckRadius, LayerMask.GetMask(layerName));
        if (cols.Length > 0)
        {
            Debug.Log("检测中");
            InfoDisplay(cols[0].transform.tag);// 只传物品的
        }
        else
        {
            GameManager.curNearState = NearState.nothing;
        }
    }

    public void InfoDisplay(string IdTag)
    {
        if (IdTag == "door")
        {
            Debug.Log("按e键切场景");
            GameManager.curNearState = NearState.door;
        }
        else if (IdTag == "Item")
        {
            Debug.Log("可获取");
            GameManager.curNearState = NearState.item;
        }
        else if (IdTag == "DocumentEquip")
        {
            GameManager.curNearState = NearState.Doc;
            Debug.Log("档案装置");
        }

    }

    private void Update()
    {
        
        transform.Translate(Input.GetAxis("Vertical") * Time.deltaTime * speed, 0, -Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        #region 摄像机代码
        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, this.transform.position + distanceWithPlayer, Time.deltaTime);

        //Camera.main.transform.forward = -distanceWithPlayer.normalized;
        #endregion
    }

}
