using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform target;

    Vector3 velocity = Vector3.zero;
    Coroutine shakeCoroutine = null;
    Vector3 shakeVector = Vector3.zero;

    public void Shake(float duration = 0.1f, float strength = 4) {
        if (shakeCoroutine != null) {
            StopCoroutine(shakeCoroutine);
        }
        shakeCoroutine = StartCoroutine(ShakeRoutine(duration, strength));
    }

    void FixedUpdate() {
        //Vector3 position = target.position / 2;
        Vector3 position = target.position;
        position.z -= 10;
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, position, ref velocity, 0.15f) + shakeVector;
    }

    IEnumerator ShakeRoutine(float duration, float strength) {
        float t = 0;
        while (t < duration) {
            t += Time.deltaTime;
            shakeVector = MathUtils.PolarToCartesian(Random.value * 360, strength);
            yield return null;
        }
        shakeVector = Vector3.zero;
        shakeCoroutine = null;
    }
}
