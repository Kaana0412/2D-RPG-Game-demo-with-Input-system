using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFarAttack : BaseState
{
    public override void OnEnter(EnemyInput enemy)
    {
        currentEnemy = enemy;
        currentEnemy.anim.SetBool("isMove", false);
        currentEnemy.rb.velocity = Vector2.zero;
        currentEnemy.anim.SetTrigger("FarAttack");
        currentEnemy.isAttack = true;
        currentEnemy.farAttackCDCounter = currentEnemy.farAttackCD;
    }

    public override void LogicUpdate()
    {

    }


    public override void PhysicUpdate()
    {

    }
    public override void OnExit()
    {

    } 
}


