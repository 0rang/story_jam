using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform theTransform;

    //unit vector2 that'll be updated with the player's direction input
    public Vector2 Direction { get; set; }

    public float speed;
    private float speedDiagComponent;

    public bool LockedInput { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        LockedInput = false;
        theTransform = gameObject.GetComponent<Transform>();
        speedDiagComponent = Mathf.Sqrt(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!LockedInput)
        {
            Move();
        }
    }

    void Move()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        Direction = new Vector2(inputHorizontal, inputVertical);

        bool movingOnBothAxes = inputHorizontal * inputVertical != 0;

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            theTransform.position = new Vector3(theTransform.position.x + speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.y + speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.z);
        }
    }
}
