using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBattle : BaseState
{
    public override void OnEnter(EnemyInput enemy)
    {
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.battleSpeed;
        currentEnemy.anim.SetBool("isMove", true);
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.isHurt || currentEnemy.isDead) 
            return;
        if (currentEnemy.lostTimeCounter <= 0)
        {
            currentEnemy.SwitchState(NpcStates.Chase);
        }

        currentEnemy.FaceToPlayer();

        if (currentEnemy.AttackPlayer() && currentEnemy.attackCDCounter<=0)
        {
            currentEnemy.SwitchState(NpcStates.Attack);
        }

        if (currentEnemy.DistanceToPlayer() <= currentEnemy.stopChaseDistence)
        {
            currentEnemy.currentSpeed = 0;
            currentEnemy.anim.SetBool("isMove", false);
        }
        else
        {
            currentEnemy.currentSpeed = currentEnemy.battleSpeed;
            currentEnemy.anim.SetBool("isMove", true);
        }
    }
    public override void PhysicUpdate()
    {
     
    }


    public override void OnExit()
    {
        currentEnemy.lostTimeCounter = currentEnemy.lostTime;
    }

}
