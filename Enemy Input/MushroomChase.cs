using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomChase : BaseState
{

    public override void OnEnter(EnemyInput enemy)
    {
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.speed;
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.isHurt || currentEnemy.isDead) 
            return;
        if (currentEnemy.FoundPlayer())
        {
            currentEnemy.SwitchState(NpcStates.Battle);
        }

        if (!currentEnemy.physicsSetting.isGrounded || currentEnemy.physicsSetting.isWalled)
        {
            currentEnemy.isWait = true;
            currentEnemy.anim.SetBool("isMove", false);
            currentEnemy.rb.velocity = new Vector2(0,currentEnemy.rb.velocity.y);
        }
        else
        {
            currentEnemy.anim.SetBool("isMove",true);
        }
    }
    public override void PhysicUpdate()
    {

    }

    public override void OnExit()
    {
        currentEnemy.anim.SetBool("isMove", false);
    }

}
