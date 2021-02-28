using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesScript : MonoBehaviour
{
    void Update(){
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 3f), transform.position.y, transform.position.z);
    }
}
