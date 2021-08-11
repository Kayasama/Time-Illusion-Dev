using UnityEngine;
using ScriptableObjectArchitecture;

public class GravityController : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection = Vector3.up;

    [SerializeField] float moveSpeed = 0f;

    [SerializeField] bool forceEnabled = false;

    [SerializeField]
    private GameObjectCollection _targetSet = default(GameObjectCollection);

    void FixedUpdate()
    {
        if (!forceEnabled)
            return;
        foreach (GameObject item in _targetSet)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.AddForce(moveDirection * moveSpeed);
        }
    }
    public void ChangeGravity(float speed = 5f)
    {
        moveSpeed = speed;
        if (forceEnabled)
            return;

        foreach (GameObject item in _targetSet)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
        forceEnabled = true;
    }
}