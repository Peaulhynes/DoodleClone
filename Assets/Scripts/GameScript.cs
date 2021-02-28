using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject player;
    private GameObject clone;
    public GameObject clonePrefab;
    private Queue<Vector3> playerPositions = new Queue<Vector3>();
    public Text startText;
    private bool start = false;
    public float minX = -3f;
    public float maxX = 3f;
    private float smooth = 5f;

    // Update is called once per frame
    void Update()
    {
        /* Start game with Enter */
        if(Input.GetButtonDown("Submit") && !start)
        {
            start = true;
            startText.gameObject.SetActive(false);
            player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        /* Game loop */
        if (start){
            StartCoroutine(SavePosition());
            StartCoroutine(MoveClone());
            player.GetComponent<PlayerScript>().GetInput();
            SetBoundaries();
        }
    }

    /* Save player current position to move clone */
    private IEnumerator SavePosition(){
        yield return new WaitForSeconds(0.1f);
        playerPositions.Enqueue(player.transform.position);
    }

    /* Move clone depending on player saved positions */
    private IEnumerator MoveClone(){
        yield return new WaitForSeconds(1.5f);

        /* Instantiate clone 1.5 second after player first movement */
        if (clone == null)
            clone = (GameObject)Instantiate(clonePrefab, playerPositions.Peek(), Quaternion.identity);
            
        /* Interpolation between clone's actual position and next player saved position */
        else
            clone.transform.position = Vector2.Lerp(clone.transform.position, new Vector2(playerPositions.Peek().x, playerPositions.Peek().y), smooth);
        playerPositions.Dequeue();
    }

    /* Set player boundaries */
    private void SetBoundaries(){
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minX, maxX), player.transform.position.y, player.transform.position.z);
    }
}
