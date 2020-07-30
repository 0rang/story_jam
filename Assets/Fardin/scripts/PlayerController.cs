using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Transform theTransform;

    public float speed;

    protected Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        theTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {

    }

    // void move()
    // {
    //     switch ()
    //     {

    //         default:
    //     }
    //     theTransform.position.x += velocity
    // }
}
