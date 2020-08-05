using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombat : MonoBehaviour
{
    private PlayerController moveInfo;
    public bool LockedAttack { get; set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        moveInfo = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!moveInfo.LockedInput && !LockedAttack && Input.GetKeyDown("Jump"))
        {
            Attack();
        }
    }

    protected abstract void Attack();



}
