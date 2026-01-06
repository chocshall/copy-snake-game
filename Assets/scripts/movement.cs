using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public char currentDirection = 'S';

    private Vector2 movementDirection = Vector2.down;

    void Update()
    {
        // Always move in the current direction
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
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
            movementDirection = Vector2.down;
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
}