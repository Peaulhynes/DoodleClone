using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1,8) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springPrefab, new Vector2(Random.Range(-3, 3), player.transform.position.y + 7 + Random.Range(0.5f,1f)), Quaternion.identity);
            }
            else
                collision.gameObject.transform.position = new Vector2(Random.Range(-3, 3), player.transform.position.y + 7 + Random.Range(0.5f,1f));
            
        }
        else if (collision.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1,8) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-3, 3), player.transform.position.y + 7 + Random.Range(0.5f,1f));
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-3, 3), player.transform.position.y + 7 + Random.Range(0.5f,1f)), Quaternion.identity);
            }   
        }
    }
}
