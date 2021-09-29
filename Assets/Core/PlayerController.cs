using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region 字段
    // 角色控制器
    private CharacterController controller;

    [Header("包围球检测范围")]
    [SerializeField] private float CheckRadius;
    
    [Header("角色位移属性")]
    [SerializeField]private float speed;
    [SerializeField] private float verticalSpeed = 0;
    [SerializeField] private float jumpSpeed = 2f;
    [SerializeField] private float gravity = 5f;

    private Vector3 moveDirection;

    // 玩家输入
    private PlayerInput playerInput;
    #endregion 字段

    #region 生命周期
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void FixedUpdate()
    {
        CalcVerticalSpeed();
        PlayerMove();
    }
    #endregion 生命周期

    #region 方法
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


    // 玩家移动
    private void PlayerMove()
    {
        moveDirection.Set(playerInput.Move.y, 0, -playerInput.Move.x);
        moveDirection *= speed * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection += Vector3.up * verticalSpeed * Time.deltaTime;

        controller.Move(moveDirection);
    }

    // 计算竖直方向的速度
    private void CalcVerticalSpeed()
    {
        if(playerInput.Jump)
        {
            verticalSpeed = jumpSpeed;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
    }

    #endregion 方法

}
