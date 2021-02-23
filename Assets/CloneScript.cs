using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 direction;
    Rigidbody2D body;
    public float speed = 1f;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
    }

    void FixedUpdate() {
        body.MovePosition(transform.position + direction.normalized * speed * Time.fixedDeltaTime);
    }
}
