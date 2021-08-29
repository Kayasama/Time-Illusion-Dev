using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun_fetch : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setItemPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Terrain")
            {
                //basket.ItemsInBasket[curChoiseItemIndex].getMousePoint(hit.point);
                transform.position = hit.point + transform.localScale/2;
                Debug.Log("hhhh");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        setItemPos();
    }
}
