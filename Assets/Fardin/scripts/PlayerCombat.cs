using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombat : MonoBehaviour
{
    private PlayerController moveInfo;
    public bool LockedAttack { get; set; }

    private float characterHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        moveInfo = gameObject.GetComponent<PlayerController>();
        characterHealth = 10f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!moveInfo.LockedInput && !LockedAttack && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    protected virtual void TakeDamage(float dmg)
    {
        characterHealth -= dmg;
    }

    protected abstract void Attack();

    // Start is called before the first frame update
}
