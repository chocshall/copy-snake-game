using UnityEngine;
using System.Collections.Generic;
public class Movement : MonoBehaviour
{
    public int movement = 2;
    
    public Vector2 defaultPosition;
    public Vector2 historyBefore;
   
    public Vector2 movementDirection = Vector2.down;
    public Vector2 historyDirection;
    public Vector2 defaultDirection;


    public GameObject myPrefab;
    public int count = 1;
    public int applesEaten = 0;


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

    }

    public void SetDirectionUp()
    {

        if (movementDirection != Vector2.down)
        {
            movementDirection = Vector2.up;
            movement = (int)MovementType.Up;
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
            movement = (int)MovementType.Down;
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
            movement = (int)MovementType.Left;
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
            movement = (int)MovementType.Right;
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
        movement = (int)MovementType.Unknown;
    }

    private void MovementBy35()
    {

        Vector2 movementBefore = transform.position;
        // Store all children
        List<Transform> children = new List<Transform>();
        List<Vector2> childPositions = new List<Vector2>();

        // this only checks when it eats an apple
        if (count == applesEaten)
        {

            GameObject newObject = Instantiate(myPrefab, movementBefore, Quaternion.identity);
            children.Add(newObject.transform);
            childPositions.Add(newObject.transform.position);
            count++;
        }
        // still need the for loop because this check always on movement the positions of children
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
            childPositions.Add(transform.GetChild(i).position);
        }
        
        foreach (Transform child in children)
        {
            child.SetParent(null);
        }
        float distanceToMove = 0.35f;
        if (movement == (int)MovementType.Up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + distanceToMove);
        }
        
        if (movement == (int)MovementType.Down)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - distanceToMove);
        }

        if (movement == (int)MovementType.Left)
        {
            transform.position = new Vector2(transform.position.x - distanceToMove, transform.position.y);
        }

        if (movement == (int)MovementType.Right)
        {
           transform.position = new Vector2(transform.position.x + distanceToMove, transform.position.y);
        }

        for (int i = 0; i < children.Count; i++)
        {
            children[i].position = childPositions[i];
            children[i].SetParent(transform);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            // need to use not chil.transform, but child.transform.position to work with the transform component of the bodypart gameobject
            // not the gameobject position
            Transform child = transform.GetChild(i);
            Vector2 childOldPosition = child.transform.position;

            child.transform.position = movementBefore;
           
            // Next child will go to this child's old position
            movementBefore = childOldPosition;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // needed to make player rigidbody use Full kinematic contacts, otherwise it doesnt call
        Debug.Log("wow");
        if (collision.collider.CompareTag("food"))
        {
            applesEaten++;
           
            foreach (var item in GameObject.FindGameObjectsWithTag("food"))
            {
                Destroy(item);
            }
           
        }
    }

    enum MovementType
    {
        Unknown = 0,
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4,
    }
}