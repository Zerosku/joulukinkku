using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    private ButtonController attackButton;


    public Collider2D attackTrigger;

    private Animator anim;

    void Awake ()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        attackButton = GameObject.Find("AttackButton").GetComponent<ButtonController>();

    }
    void Update ()
    {
        if((Input.GetKeyDown("z")||attackButton.pressed) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;

        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("attack", attacking);
    }
}
