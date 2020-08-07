using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarenCombat : PlayerCombat
{
    public AxeHitbox axe;
    public Vector3 axeSpawnLoc;
    public Vector2 rotationVector;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        Debug.Log("Attacking");
        AxeHitbox newAxe = Instantiate(axe, axeSpawnLoc, Quaternion.identity);
        newAxe.transform.parent = gameObject.transform;
        newAxe.transform.RotateAround(newAxe.transform.position, Vector3.forward, 270);


    }
}
