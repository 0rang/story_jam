using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform theTransform;

    //unit vector2 that'll be updated with the player's direction input
    public Vector2 Direction { get; set; }
    //private Rigidbody2D player_rigidbody;

    public float speed;
    private float speedDiagComponent;
    private BoxCollider2D colliderChan;

    public bool LockedInput { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        LockedInput = false;
        //player_rigidbody = GetComponent<Rigidbody2D>();
/*        if (player_rigidbody == null)
        {
            Debug.LogError("oh god no rigidbody");
        }*/
        theTransform = gameObject.GetComponent<Transform>();
        colliderChan = GetComponent<BoxCollider2D>();
        if (!colliderChan)
        {
            Debug.LogError("oh god");
        }
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
        bool canMoveHorizontal = true;
        bool canMoveVertical = true;

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            Vector2 current_velocity = new Vector2(
                speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
                speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime);


            if (inputHorizontal != 0)//transform.scale.x/2
            {
                Vector2 HorizontalOffset = new Vector2(theTransform.position.x + colliderChan.size.x/2 * inputHorizontal,
                                                        theTransform.position.y);
                RaycastHit2D raybois = Physics2D.Raycast(HorizontalOffset, Vector2.right * inputHorizontal,
                    speed * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime);
                if (raybois.collider)
                {
                    canMoveHorizontal = raybois.collider.gameObject.layer == 2;
                    Debug.Log("Found Horizontal Collider owo at " + raybois.collider.gameObject.name);
                }
                else { Debug.Log("Not hit horizontal"); }
                //canMoveHorizontal = raybois.collider == null || raybois.collider.gameObject.layer == 2;
            }

            if (inputVertical != 0)
            {
                Vector2 VerticalOffset = new Vector2(theTransform.position.x, theTransform.position.y + colliderChan.size.y / 2 * inputVertical);
                RaycastHit2D raybois = Physics2D.Raycast(VerticalOffset, Vector2.up * inputVertical,
                    speed * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime);
                if (raybois.collider)
                {
                    canMoveVertical = raybois.collider.gameObject.layer == 2;
                    Debug.Log("Found vertical Collider uwu");
                }
            }
           // RaycastHit2D ray = Physics2D.Raycast()
            //RaycastHit2D ray = Physics.Raycast 
/*            player_rigidbody.AddForce(new Vector2(
                speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
                speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime));*/
            /*            player_rigidbody.velocity = new Vector2(
                            speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
                            speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime);*/



            if (!canMoveHorizontal)
            {
                Debug.Log("Can't Move Horizontal");
            }
            if (!canMoveVertical)
            {
                Debug.Log("Can't Move Verically");
            }
            

            theTransform.position = new Vector3(theTransform.position.x + (canMoveHorizontal?1:0)*speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.y + (canMoveVertical ? 1 : 0) * speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.z);

            
        }

    }
}
