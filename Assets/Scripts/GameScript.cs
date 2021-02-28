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
    private bool spawnClone = false;
    public float minX;
    public float maxX;
    private float smooth;
    private Vector2 clonePosition;

    /* Get screen boundaries */
    void Start()
    {
        float cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, cameraDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, cameraDistance));
        minX = bottomCorner.x;
        maxX = topCorner.x;
    }
    
    void Update()
    {
        /* Start game with Enter */
        if(Input.GetButtonDown("Submit") && !start)
        {
            start = true;
            startText.gameObject.SetActive(false);
            player.GetComponent<Rigidbody2D>().gravityScale = 1f;
            StartCoroutine(SpawnClone());
        }

        /* Game loop */
        if (start){

            /* Spawn clone */
            if (spawnClone){
                clone = (GameObject)Instantiate(clonePrefab, playerPositions.Peek(), Quaternion.identity);
                spawnClone = false;
            }
            
            /* Clone movements */
            StartCoroutine(SavePosition());
            if (clone != null)
                MoveClone();

            /* Player movements */
            player.GetComponent<PlayerScript>().GetInput();
            SetBoundaries();
        }
    }

    /* Save player current position to move clone */
    private IEnumerator SavePosition(){
        yield return new WaitForSeconds(0.1f);
        playerPositions.Enqueue(player.transform.position);
        if (clone != null){
            clonePosition = clone.transform.position;
            playerPositions.Dequeue();
        }   
    }

    /* Spawn clone */
    private IEnumerator SpawnClone(){
        yield return new WaitForSeconds(1.5f);
        spawnClone = true;
    }

    /* Interpolation between clone position and player saved position */
    private void MoveClone(){
        smooth = (float)(Time.time % 0.1 * 10);
        clone.transform.position = Vector2.Lerp(clonePosition, new Vector2(playerPositions.Peek().x, playerPositions.Peek().y), smooth);
    }

    /* Teleport player at the other side of screen */
    private void SetBoundaries(){
        if (player.transform.position.x < minX)
            player.transform.position = new Vector3(maxX, player.transform.position.y, player.transform.position.z);
        if (player.transform.position.x > maxX)
            player.transform.position = new Vector3(minX, player.transform.position.y, player.transform.position.z);
    }
}
