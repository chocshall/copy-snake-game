using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{
    public float moveSpeed = 1;
    private bool startMove = true;
    public int count = 0;
    private float getTime;

    Rigidbody2D FreezePosition;

    void Start()
    {
        FreezePosition = GetComponent<Rigidbody2D>();
    }
    // update is called every frame so if 60 frames
    void Update()
    {
       

        if (Input.GetKey(KeyCode.RightArrow) && count != 1 && startMove)
        {

            count = 0;
            startMove = false;
            getTime = Time.time;
        }

        if(count == 0)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && count != 0 && startMove)
        {
            
            startMove = false;
            count = 1;
            getTime = Time.time;

        }

        if (count == 1)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) && count != 3 && startMove)
        {
            
            startMove = false;
            count = 2;
            getTime = Time.time;
        }

        if (count == 2)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) && count != 2 && startMove)
        {
           
            startMove = false;
            count = 3;
            getTime = Time.time;
        }

        if (count == 3)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }


        ClickCooldown();

    }

    void ClickCooldown()
    {
        if(!startMove && Time.time - getTime > 0.2f)
        {
            startMove = true;
        }
    }
}
