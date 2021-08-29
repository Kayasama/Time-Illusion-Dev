using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHandle : MonoBehaviour
{
    public Camera rtCamera;
    public LineRenderer lineBrush;
    RenderTexture renderTexture;
    public Material renderMaterial;

    private void Start()
    {
        renderTexture = rtCamera.targetTexture;
        renderMaterial.SetTexture("BlitTex", renderTexture);
        renderMaterial.SetMatrix("paintCameraVP", rtCamera.nonJitteredProjectionMatrix * rtCamera.worldToCameraMatrix);
        print("fafa");

    }

    Vector3 prePos = Vector3.one * 10000;
    Vector3[] linePosArr = new Vector3[2];
    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
	  if (prePos == Vector3.one * 10000)
	  {
	      prePos = hitInfo.point;
	  }
	  lineBrush.positionCount = 2;
	  linePosArr[0] = prePos;
	  linePosArr[1] = hitInfo.point;
	  lineBrush.SetPositions(linePosArr);
	  lineBrush.startWidth = 1f;
	  lineBrush.endWidth = 1f;
	  rtCamera.Render();
	  prePos = hitInfo.point;
            Debug.DrawLine(Camera.main.transform.position, prePos);
            Debug.Log("sasds");

        }
    }

    void OnMouseUp()
    {
        prePos = Vector3.one * 10000;
    }

    public void Update()
    {
        OnMouseDrag();
        OnMouseUp();

    }
}
