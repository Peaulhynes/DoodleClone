using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesScript : MonoBehaviour
{
    /*
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x, -(screenBounds.x));
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y, -(screenBounds.y));
        transform.position = viewPosition;
    }
    */
    void Update(){
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 3f), transform.position.y, transform.position.z);
    }
}
