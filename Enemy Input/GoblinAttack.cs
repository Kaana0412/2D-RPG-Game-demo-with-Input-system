using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : BaseState
{
    public override void OnEnter(EnemyInput enemy)
    {
        currentEnemy = enemy;
        currentEnemy.anim.SetBool("isMove", false);
        currentEnemy.rb.velocity = Vector2.zero;
        currentEnemy.anim.SetTrigger("Attack");
        currentEnemy.isAttack = true;
        currentEnemy.attackCDCounter = currentEnemy.attackCD;
    }

    public override void LogicUpdate()
    {

    }


    public override void OnExit()
    {

    }

    public override void PhysicUpdate()
    {

    }
}
