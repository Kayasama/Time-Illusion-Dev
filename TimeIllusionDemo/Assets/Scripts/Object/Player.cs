using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Consts
    const float MAX_SPEED = 100;
    const float COROUTINE_INTERVAL = 1f;

    // Unity vars
    //[SerializeField] SessionData sessionData;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject collisionPrefab;
    [SerializeField] Rigidbody body;

    void Start() {
        StartCoroutine(SomeRoutine());
    }

    void Update() {
        playerData.position = body.position;
    }

    void FixedUpdate() {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("PlayerHorizontal"), Input.GetAxisRaw("PlayerVertical")).normalized;
        body.AddForce(moveDirection * GetSpeed());
    }

    void LateUpdate() {
    }


    float GetSpeed() {
        return MAX_SPEED;
    }

    IEnumerator SomeRoutine() {
        while (true) {
            yield return new WaitForSeconds(COROUTINE_INTERVAL);
        }
    }

    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
    }
}
