﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform theTransform;

    public float speed;
    private float speedDiagComponent;

    protected Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        theTransform = gameObject.GetComponent<Transform>();
        speedDiagComponent = Mathf.Sqrt(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        bool movingOnBothAxes = inputHorizontal * inputVertical != 0;

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            // theTransform.position.Set(theTransform.position.x + speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1),
            // theTransform.position.y + speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1),
            // theTransform.position.z);

            // theTransform.position.Set(theTransform.position.x + 5, theTransform.position.y + 5,
            // theTransform.position.z);

            theTransform.position = new Vector3(theTransform.position.x + speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.y + speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.z);
        }
    }

    void FixedUpdate()
    {

    }

    void move()
    {

    }
}
