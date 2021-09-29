using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _move;
    private bool _jump;

    public Vector2 Move
    {
        get
        {
            return _move;
        }
    }

    public bool Jump
    {
        get
        {
            return _jump;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _move.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _jump = Input.GetKey(KeyCode.Space);
    }
}
