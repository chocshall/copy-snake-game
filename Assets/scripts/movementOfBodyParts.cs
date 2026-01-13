using UnityEngine;

public class MovementOfBodyParts : MonoBehaviour
{
    private GameObject player;
    private (float, float) playerPosition;
    private Vector2 startDirection;
    private Movement movementScript;

    private Vector2 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movementScript = player.GetComponent<Movement>();
        
        startDirection = player.GetComponent<Movement>().defaultDirection;
        position = transform.position;

        InvokeRepeating(nameof(ApplyPositionChange), 0f, 1.0f);

    }
    
    // Update is called once per frame
    void Update()
    {
        //transform.position = movementScript.historyMovementBefore;
        
        //float distance = Vector2.Distance(movementScript.historyBefore, movementScript.history);

        //transform.Translate(movementScript.historyDirection * distance);

        if (player.GetComponent<Movement>().moveSpeed == 0f)
        {
            transform.position = new Vector2(0, 0.35f);
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("body"))
        {
            collision.gameObject.SendMessage("ApplyPositionChange", 0.35f);
        }
    }

    public void ApplyPositionChange(float  position)
    {
        if (movementScript.moveSpeed == 1f)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - 0.35f);
            transform.localPosition = new Vector2(0, 0 + 0.35f);
        }

        if (movementScript.moveSpeed == 2f)
        {
            //transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y);
            transform.localPosition = new Vector2(0 + 0.35f,0);
        }

        if (movementScript.moveSpeed == 3f)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + 0.35f);
            transform.localPosition = new Vector2(0, 0 - 0.35f);
        }

        if (movementScript.moveSpeed == 4f)
        {
            //transform.position = new Vector2(transform.position.x + 0.35f, transform.position.y);
            transform.localPosition = new Vector2(0 - 0.35f, 0);
        }
        
    }
}
