using UnityEngine;

public class MovementOfBodyParts : MonoBehaviour
{
    private GameObject player;
    private float playerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPosition = player.GetComponent<Movement>().historyBefore;
    }
    
    // Update is called once per frame
    void Update()
    {

        if(player.GetComponent<Movement>().historyBefore != player.GetComponent<Movement>().history)
        {
            float distance = player.GetComponent<Movement>().history - player.GetComponent<Movement>().historyBefore;
            transform.position = new Vector2(transform.position.x, transform.position.y + distance);
            
            //Vector2 playerDistance = player.GetComponent<Movement>().history - player.GetComponent<Movement>().historyBefore;
            playerPosition = player.GetComponent<Movement>().history;

        }
        //if (player.defaultPosition == (0,0,0))
        //{
        //    transform.position = player.defaultPosition;
        //}
    }
}
