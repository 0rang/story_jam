using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitbox : MonoBehaviour
{
    public PlayerController player;
    private TarenCombat taren;

    Transform theTransform;
    public float rotationSpeed;
    public float startupLag;

    private float initRotation;
    private float totalRotation;
    private float initTime;

    // Start is called before the first frame update
    void Start()
    {
        theTransform = gameObject.GetComponent<Transform>();
        player = gameObject.GetComponentInParent<PlayerController>();
        initTime = Time.time;
        player.LockedInput = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > initTime + startupLag)
        {

            float rotateSizeThisframe = rotationSpeed * Time.deltaTime;

            totalRotation += rotateSizeThisframe;
            theTransform.RotateAround(theTransform.parent.position, Vector3.forward, rotateSizeThisframe);

            if (totalRotation > 360f)
            {
                player.LockedInput = false;
                GameObject.Destroy(this.gameObject);
            }

        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Axe Trigger Entered");
        GameObject.Destroy(other.collider.gameObject);
    }
}
