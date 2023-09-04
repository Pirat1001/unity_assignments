using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{


    public Vector2 circlePosition;
    public float diameter = 0.5f;
    public Vector2 circleDirection;
    public Vector2 mousePosition;
    public float movementSpeed = 0.011f;
    public float leftBorder = 0f;
    public float rightBorder = 22.1f;
    public float topBorder = 11.98f;
    public float bottomBorder = 0f;
    public float maxSpeed = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        mousePosition.x = MouseX;
        mousePosition.y = MouseY;


        if (Input.GetMouseButtonDown(0))
        {
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
            
        }
        else if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
            circleDirection = mousePosition - circlePosition;
        }
        else if (!Input.GetMouseButton(0))
        {
            circlePosition += circleDirection * movementSpeed;
        }
        
        
        
        if((circlePosition.x - (diameter * 0.5)) <= 0 || (circlePosition.x + (diameter * 0.5)) >= Width) 
        {
            circleDirection.x = -circleDirection.x;
        }


        if((circlePosition.y + (diameter * 0.5)) >= Height || (circlePosition.y - (diameter * 0.5)) <= 0)
        {
            circleDirection.y = -circleDirection.y;
        }

        if(circleDirection.magnitude > maxSpeed)
        {
            circleDirection.Normalize();
            circleDirection *= maxSpeed;
        }


        Circle(circlePosition.x, circlePosition.y, diameter);




    }
}
