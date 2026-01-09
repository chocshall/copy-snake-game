using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public char currentDirection = 'S';
    public Vector2 defaultPosition;
    public float historyBefore;
    public float history;
   
    private Vector2 movementDirection = Vector2.down;

    void Update()
    {
        // Always move in the current direction
        
        if(transform.position.y < -3.6f || transform.position.y > 4.8f || transform.position.x < -2f || transform.position.x > 2f)
        {
            ResetToDefault();
            
        }
        historyBefore = transform.position.y;
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        history = transform.position.y;


    }

    
    public void SetDirectionUp()
    {
        if (movementDirection != Vector2.down)
        {
            movementDirection = Vector2.up;
        }
        else
        {
            movementDirection = Vector2.down;
        }
        
    }

    public void SetDirectionDown()
    {
        if (movementDirection != Vector2.up)
        {
            movementDirection = Vector2.down;
        }
        else
        {
            movementDirection = Vector2.up;
        }
        
    }

    public void SetDirectionLeft()
    {
        if(movementDirection != Vector2.right)
        {
            movementDirection = Vector2.left;
        }
        else
        {
            movementDirection = Vector2.right;
        }
        
    }

    public void SetDirectionRight()
    {
        if (movementDirection != Vector2.left)
        {
            movementDirection = Vector2.right;
        }
        else
        {
            movementDirection = Vector2.left;
        }
        
    }

    private void Awake()
    {
        defaultPosition = transform.position;
       
    }

    private void ResetToDefault()
    {
        transform.position = defaultPosition;
        moveSpeed = 0f;
    }
}