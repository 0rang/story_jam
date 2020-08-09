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
        if (!LockedInput && !EventHandler.isBusy)
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
                for (int Count = 0;Count<3;Count++)
                {
                    Vector2 HorizontalOffset = new Vector2(theTransform.position.x +  theTransform.localScale.x * colliderChan.size.x / 2 * inputHorizontal,
                                    theTransform.position.y + (Count - 1)* theTransform.localScale.y * colliderChan.size.y / 2);
                    RaycastHit2D[] raybois = Physics2D.RaycastAll (HorizontalOffset, Vector2.right * inputHorizontal,
                        speed * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime);
                    foreach(RaycastHit2D rayboi in raybois)
                    {
                        if (rayboi.collider)
                        {
                            canMoveHorizontal = rayboi.collider.gameObject.layer == 2 || rayboi.collider.isTrigger;
                            if (!canMoveHorizontal)
                            {
                                break;
                            }
                        }
                    }
                    if (!canMoveHorizontal)
                    {
                        break;
                    }


                }

            }

            if (inputVertical != 0)
            {

                for (int Count = 0; Count < 3; Count++)
                {
                                   
                    Vector2 VerticalOffset = new Vector2(theTransform.position.x + (Count - 1) * theTransform.localScale.x * colliderChan.size.x / 2,
                                        theTransform.position.y + theTransform.localScale.y * colliderChan.size.y / 2 * inputVertical);
                    RaycastHit2D[] raybois = Physics2D.RaycastAll(VerticalOffset, Vector2.up * inputVertical,
                                    speed * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime);
                    foreach(RaycastHit2D rayboi in raybois)
                    {
                        if (rayboi.collider)
                        {
                            canMoveVertical = rayboi.collider.gameObject.layer == 2 || rayboi.collider.isTrigger;
                            if (!canMoveVertical)
                            {
                                break;
                            }
                        }

                    }
                    if (!canMoveVertical)
                    {
                        break;
                    }


                }
            }


            theTransform.position = new Vector3(theTransform.position.x + (canMoveHorizontal?1:0)*speed * inputHorizontal * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.y + (canMoveVertical ? 1 : 0) * speed * inputVertical * (movingOnBothAxes ? speedDiagComponent : 1) * Time.deltaTime,
            theTransform.position.z);

            
        }

    }
}
