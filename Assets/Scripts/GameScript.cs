using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject player;
    public GameObject clone;
    public GameObject clonePrefab;
    public Queue<Vector3> playerPositions; 
    public Text startText;
    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        playerPositions = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") && !start)
        {
            start = true;
            startText.gameObject.SetActive(false);
            player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        if (start){
            StartCoroutine(SavePosition());
            StartCoroutine(MoveClone());
            player.GetComponent<PlayerScript>().GetInput();
        }
    }

    public IEnumerator SavePosition(){
        yield return new WaitForSeconds(0.1f);
        playerPositions.Enqueue(player.transform.position);
    }

    public IEnumerator MoveClone(){
        yield return new WaitForSeconds(1.5f);
        if (clone == null)
            clone = (GameObject)Instantiate(clonePrefab, playerPositions.Peek(), Quaternion.identity);
        else
            clone.transform.position = Vector2.Lerp(clone.transform.position, new Vector2(playerPositions.Peek().x, playerPositions.Peek().y), 5f);
        playerPositions.Dequeue();
    }

}
