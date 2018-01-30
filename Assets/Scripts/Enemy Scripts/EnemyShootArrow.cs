using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootArrow : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject target;

    private Rigidbody2D targetRB;

    private void Start()
    {
        targetRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;

        pointToTarget.Normalize();

        float value = Vector3.Cross(pointToTarget, transform.right).z;

        targetRB.angularVelocity = rotationSpeed * value;

        targetRB.velocity = -transform.right * speed;

    }
}
