using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> camManager = new List<Camera>(8);

    //public int CurrentCam
    //{
    //    set
    //    {
    //        currentCam = value;
    //    }
    //}

    public IEnumerator traverseCam()
    {
        
        foreach (var cam in camManager)
        {
            yield return cam;
            yield return new WaitForSeconds(1);
            print(cam);
        }
        
    }

    // 修改摄像机
    public void ModifyCamera(int preCam, int nextCam)
    {
        //camManager[nextCam].gameObject.SetActive(true);
        //camManager[preCam].gameObject.SetActive();
        camManager[nextCam].enabled = true;
        camManager[preCam].enabled = false;

        camManager[nextCam].gameObject.SetActive(true);
        camManager[preCam].gameObject.SetActive(false);

        camManager[nextCam].tag = "MainCamera";
        camManager[preCam].tag = "Untagged";

    }


    private void Update()
    {
        //StartCoroutine(traverseCam());
    }

}
