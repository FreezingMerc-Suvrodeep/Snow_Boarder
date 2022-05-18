using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float TorqueAmt=3f;
    [SerializeField] float BoostSpeed=30f;
    [SerializeField] float BaseSpeed=20f;
    [SerializeField] float BrakeSpeed=5f;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb2d;
    bool canMove=true;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
        RotatePlayer();
        RespondToBoost();
        }
    
    }


    public void DisableControl()
    {
        canMove=false;
    }
    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed=BoostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed=BrakeSpeed;
        }
        else
        {
            surfaceEffector2D.speed=BaseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-TorqueAmt);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(TorqueAmt);
        }
    }
}
