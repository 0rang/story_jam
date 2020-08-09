using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitbox : MonoBehaviour
{
    private PlayerController player;
    private TarenCombat taren;

    Transform theTransform;
    public float rotationSpeed;
    public float startupLag;

    private float totalRotation;
    private float initTime;

    public Vector2 hitboxSize;

    // Start is called before the first frame update
    void Start()
    {
        theTransform = gameObject.GetComponent<Transform>();
        player = gameObject.GetComponentInParent<PlayerController>();
        initTime = Time.time;
        player.LockedInput = true;
        totalRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > initTime + startupLag)
        {

            float rotateSizeThisframe = rotationSpeed * Time.deltaTime;

            totalRotation += rotateSizeThisframe;
            theTransform.RotateAround(theTransform.parent.position, Vector3.forward, rotateSizeThisframe);

            Collider2D hitboxOverlap = Physics2D.OverlapBox(this.transform.position, hitboxSize, 0f);
            if (hitboxOverlap != null)
            {
                Debug.Log("Collider Found!!" + hitboxOverlap.ToString());
                if (hitboxOverlap.tag == "Enemy")
                {
                    Debug.Log("Found an enemy");
                    GameObject.Destroy(hitboxOverlap.gameObject);
                }
            }

            if (totalRotation > 360f)
            {
                player.LockedInput = false;
                GameObject.Destroy(this.gameObject);
            }

        }

    }

}
