using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public char currentDirection = 'S';
    public Vector2 defaultPosition;
    public Vector2 historyBefore;
    public Vector2 history;


    public Vector2 movementDirection = Vector2.down;
    public Vector2 historyDirection;
    public Vector2 defaultDirection;

    public Vector2 historyMovementBefore;
    public Vector2 historyMovement;
    

    void Start()
    {
      
            InvokeRepeating(nameof(MovementBy35), 0f, 1.0f);
    }
    void Update()
    {
        // Always move in the current direction
        historyDirection = movementDirection;

        
        if (transform.position.y < -3.6f || transform.position.y > 4.8f || transform.position.x < -2f || transform.position.x > 2f)
        {
            ResetToDefault();

        }
        historyBefore = transform.position;


        //transform.Translate(movementDirection * moveSpeed * Time.deltaTime);



        history = transform.position;


    }


    public void SetDirectionUp()
    {

        if (movementDirection != Vector2.down)
        {
            movementDirection = Vector2.up;
            moveSpeed = 3f;
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
            moveSpeed = 1f;
        }
        else
        {
            movementDirection = Vector2.up;
        }

    }

    public void SetDirectionLeft()
    {
        if (movementDirection != Vector2.right)
        {
            movementDirection = Vector2.left;
            moveSpeed = 2f;
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
            moveSpeed = 4f;
        }
        else
        {
            movementDirection = Vector2.left;
        }

    }

    private void Awake()
    {
        defaultPosition = transform.position;
        defaultDirection = movementDirection;



    }

    private void ResetToDefault()
    {
        transform.position = defaultPosition;
        moveSpeed = 0f;
    }

    private void MovementBy35()
    {
        Vector2 movementBefore = transform.position;

        // Store all children
        List<Transform> children = new List<Transform>();
        List<Vector2> childPositions = new List<Vector2>();
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
            childPositions.Add(transform.GetChild(i).position);
        }
        foreach (Transform child in children)
        {
            child.SetParent(null);
        }
        if (moveSpeed == 1f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.35f);
        }
        
        if (moveSpeed == 2f)
        {
            transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y);
        }

        if (moveSpeed == 3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.35f);
        }

        if (moveSpeed == 4f)
        {
           transform.position = new Vector2(transform.position.x + 0.35f, transform.position.y);
        }



        Vector2 nextPosition = movementBefore;

        for (int i = 0; i < children.Count; i++)
        {
            children[i].position = childPositions[i];
            children[i].SetParent(transform);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector2 childOldPosition = child.transform.position;

            // Move this child to the previous position in the chain
            //Vector2 localPos = transform.InverseTransformPoint(nextPosition);
            child.transform.position = nextPosition;
            //child.localPosition = localPos;

            // Next child will go to this child's old position
            nextPosition = childOldPosition;
        }



    }



}