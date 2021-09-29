using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品栏
/// </summary>
public class ItemBasket : MonoBehaviour
{
    public List<ItemBaseForm> itemsInBasket = new List<ItemBaseForm>();
    public Transform Player;
    public static int itemInHand = 0;


    public void AddItem(Transform transform)
    {
        if(transform != null)
        {
            ItemBaseForm itemForm = new ItemBaseForm();
            itemForm.transform = transform;
            Debug.Log(itemsInBasket == null);
            itemsInBasket.Add(itemForm);
            Debug.Log("enter...");
        }

    }

    public void RemoveItem(Transform transform)
    {
        if (transform != null)
        {
            for (int i = 0; i < itemsInBasket.Count; ++i)
            {
                if (itemsInBasket[i].transform == transform)
                {
                    itemsInBasket.Remove(itemsInBasket[i]);
                }
            }
        }
    }

    public void CheckWhichPressed()
    {
        if(itemsInBasket.Count > 0)
        {
            for (int i = 1; i <= 3; ++i)
            {
                if (i <= itemsInBasket.Count && Input.GetKeyDown(i.ToString()))
                {
                    if (itemInHand == 0)
                    {
                        // 拿取物品
                        Debug.Log("fetch item in basket");
                        PutItemInHand(--i);
                        // 设置按键对应物品的索引
                    }
                }
            }
        }
    }

    public void PutItemInHand(int index)
    {
        //if (itemInHand == 0)
        //{
        //print(index);
        // 放于主角身上
        itemsInBasket[index].transform.position = Player.position + Vector3.up;
        itemsInBasket[index].transform.SetParent(Player);
        itemsInBasket[index].transform.gameObject.SetActive(true);
        itemInHand = index + 1;
    }

    // 收回物品栏
    //public void ItemBack2Basket(int index)
    //{
    //    // 藏在玩家身上，玩家不知道其实就可以了
    //    itemsInBasket[index].transform.gameObject.SetActive(false);
    //    //itemsInBasket[--itemInHand].transform.SetParent(parent);
    //    Debug.Log(index);
    //    itemInHand = 0;
    //}

}
