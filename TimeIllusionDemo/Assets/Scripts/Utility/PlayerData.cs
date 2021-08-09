using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject {
    //[SerializeField] SessionData sessionData;

    public Vector3 position;
    public void Reset() {
        position = Vector3.zero;
    }
}
