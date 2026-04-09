using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsSetting physicsSetting;
    private PlayerControls playerControls;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsSetting = GetComponent <PhysicsSetting>();
        playerControls = GetComponent<PlayerControls>();
    }

    private void Update()
    {
        SetAnimation();//启用动画状态
    }

    public void SetAnimation()
    {
        anim.SetFloat("inputX", Mathf.Abs(rb.velocity.x));//提取X轴速度的绝对值用于动画条件检测
        anim.SetFloat("inputY", rb.velocity.y);//提取Y轴速度用于动画条件
        anim.SetBool("isGrounded", physicsSetting.isGrounded);
        anim.SetBool("isDead", playerControls.isDead);
        anim.SetBool("isAttack", playerControls.isAttack);
        anim.SetBool("isDash",playerControls.isDash);
        anim.SetBool("isWalled", physicsSetting.isWalled);
    }
    //触发动画状态机中的trigger
    public void Hurt()
    {
        anim.SetTrigger("Hurt");
    }
    
    public void PlayerAttack()
    {
        anim.SetTrigger("Attack");
    }

}
