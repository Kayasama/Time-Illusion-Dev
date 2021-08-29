using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏总管理
/// </summary>
/// 
public enum NearState
{
    nothing,
    item,
    door,
    Doc
}
public class GameManager : MonoBehaviour
{
    
    // 场景物品
    public List<ItemBaseForm> Items = new List<ItemBaseForm>(0);
    public Transform Player;
    public static NearState curNearState = NearState.nothing;
    
    // 物品栏物品
    public ItemBasket basket;

    private PlayerController controller;
    public SceneManager sceneManager;
    public CameraManager camManager;
    public UiManager uiManager;
    //public AudioClip clip;
    private AudioSource source;
    //public StateMachineBehaviour eventTrigger;

   
    private void Start()
    {
        source = GetComponent<AudioSource>();
        controller = Player.GetComponent<PlayerController>();
        Transform[] allItemChild = GetComponentsInChildren<Transform>(true);
        //print(allItemChild[0]);
        for (int i = 0; i <= allItemChild.Length - 1; ++i)
        {
            if (Items.Count < allItemChild.Length - 1)
                Items.Add(new ItemBaseForm());

            if (allItemChild[i] != this.gameObject.transform)
                Items[--i].transform = allItemChild[++i];
        }
        // 跳过2_Doc
        Debug.Log(Items[4].transform.name);
    }


    //private void ItemCanTake()
    //{
    //    foreach(var i in Items)
    //    {
    //        i.NearPlayerCheck(i.transform, Player);
    //    }
    //}

    public void SetItemsParent(int index)
    {
        for (int i = 0; i < sceneManager.scenes.Count; ++i)
        {
            if (sceneManager.scenes[i].gameObject.active)
            {
                basket.itemsInBasket[index].transform.SetParent(sceneManager.scenes[i]);
                basket.itemsInBasket[index].transform.gameObject.SetActive(true);
            }
        }
    }

    // 设置物品栏物品在场景中的位置
    void setItemPos(int index)
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 主角位置与任务要求位置距离不超过5m
                if (hit.transform.tag == "Terrain"/* && Vector3.Distance(Player.position, hit.transform.position) < 5f*/)
                {
                    basket.itemsInBasket[--index].transform.position = hit.point;
                    //basket.itemsInBasket[index].transform.gameObject.SetActive(true);
                    Debug.Log("hhhh");
                    SetItemsParent(index);
                    Items.Add(basket.itemsInBasket[index]);
                    //Items[Items.Count - 1].transform.gameObject.SetActive(true);
                    basket.RemoveItem(basket.itemsInBasket[index].transform);
                    ItemBasket.itemInHand = 0;
                }
            }

        }
    }

    public void GetItem()
    {
        if(basket.itemsInBasket.Count < 3 && ItemBasket.itemInHand == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("fafaf");

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Item")
                    {
                        basket.AddItem(hit.transform);
                        Debug.Log(basket.itemsInBasket[0]);
                        hit.transform.gameObject.SetActive(false);
                        // 删除场景物品列表里对应的物品
                        Items.Remove(basket.itemsInBasket[basket.itemsInBasket.Count-1]);
                        //Items[Items.Count-1].ThisItemImage
                        //itemChoise = true;
                    }
                }
            }

        }
    }

    bool isChanging = false;
    
    public void AllThingsChange()
    {
        sceneManager.SceneChange(SceneManager.currScene, SceneManager.currScene+1);
        camManager.ModifyCamera(SceneManager.currScene, SceneManager.currScene + 1);
        SceneManager.currScene++;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.0f);
        AllThingsChange();
    }

    private float maxTouchVal = 10f, curTouchVal = 0f;

    // 长按完成刻录事件
    public void BurnInfo()
    {
        for(int i = 0; i < basket.itemsInBasket.Count; ++i)
        {
            if (basket.itemsInBasket[i].transform.name == "Token" && i + 1 == ItemBasket.itemInHand)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("changanzhong...");
                    if (curTouchVal < maxTouchVal)
                    {
                        curTouchVal += Time.deltaTime * 10f;
                        uiManager.sliderScroll(curTouchVal);
                    }
                    else
                        curTouchVal = maxTouchVal;
                }
                else
                {
                    curTouchVal = 0;
                }
            }
        }
    }
    public void FunctionalPos(NearState m_curNearState)
    {
        controller.checkItemInScene();
        basket.CheckWhichPressed();
        //if (ItemBasket.itemInHand > 0)
        //{
        //    Debug.Log("has sth in hand...");
        //    setItemPos(ItemBasket.itemInHand);
        //}
        switch (m_curNearState)
        {
            case NearState.nothing:
                uiManager.HideRequestForToken();
                isChanging = false;
                break;
            case NearState.item:
                //uiManager.HideRequestForToken();
                // 可放地上，也有对应任务
                if (ItemBasket.itemInHand > 0)
                {
                    Debug.Log("has sth in hand...");
                    setItemPos(ItemBasket.itemInHand);
                }
                else
                {
                    GetItem();
                }
                break;
            case NearState.door:
                // 可跳场景
                if (Input.GetKeyDown(KeyCode.E) && !isChanging)
                {
                    uiManager.ani.SetTrigger("FadeOut");
                    Debug.Log("切换中。。");
                    StartCoroutine(Timer());
                    isChanging = true;
                }
                break;
            case NearState.Doc:
                // 可完成刻录
                uiManager.requestForToken();
                if (ItemBasket.itemInHand > 0)
                {
                    Debug.Log("has sth in hand...");

                    BurnInfo();
                    if (curTouchVal == maxTouchVal) uiManager.requestText.text = "恭喜你，完成信息刻录";
                }
                    break;
        }
    }

    // 游戏主循环
    public void FixedUpdate()
    {
        #region 残余代码
        //if (ItemBasket.itemInHand > 0)
        //{
        //    basket.ItemBack2Basket();

        //    //    //print(Items.Count);
        //    //    //物品栏有物品
        //    if (basket.itemsInBasket.Count != 0)
        //    {
        //        Debug.Log("has sth in hand...");
        //        if (curNearState == NearState.Doc)
        //        {
        //            Debug.Log("放东西。");
        //            uiManager.requestForToken();
        //            BurnInfo();
        //            if (curTouchVal == maxTouchVal) Debug.Log("完成");
        //        }

        //        // 待处理
        //        else
        //        setItemPos(ItemBasket.itemInHand);
        //    }

        //}
        //else
        //{

        //    basket.CheckWhichPressed();
        //    ItemCanTake();
        //    GetItem();
        //}
        //if(curNearState == NearState.door && Input.GetKeyDown(KeyCode.E))
        //{
        //    uiManager.ani.SetTrigger("FadeOut");
        //    Debug.Log("切换中。。");
        //    StartCoroutine(Timer());
        //}
        #endregion
        //Debug.Log(Items[4].transform.name);
        source.Play();


        Debug.Log(curNearState);
        FunctionalPos(curNearState);


    }
}


/*
1 初始房间玩家自带物品，在第一场景归位（A→A）提交船员证明（和其他人的放在一起）
2 第一场景拾取物品在第三场景归位（A→A）放置机器人（似乎有一只落单的机器人）
3 第三场景拾取物品在第二场景归位（A→A）温室花朵（它也出现错了地方）
4 去冷冻室休眠（可以进入隔壁的房间6也可以不进），转场进入时间线B

 */
