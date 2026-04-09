using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    public PlayerController controller;
    public Vector2 inputDir;
    private Rigidbody2D rb;
    private PhysicsSetting physicsSetting;
    private PlayerAnimation playerAnimation;
    public CapsuleCollider2D coll;
    private Character character;
    private int facingDir = 1;
    private bool facingRight = true;

    [Header ("Basic data")]
    public float Speed;
    public float jumpForce;
    public float hurtForce;
    public float DashSpeed;
    public float DashDurTime;
    public float DashCD;
    public float wallSlideSpeed;
    public float wallJumpX;
    public float wallJumpY;
    public float wallJumpTime = 0.15f;

    [Header ("State")]
    public bool isHurt;
    public bool isDead;
    public bool isAttack;
    public bool isDash;
    public bool isWallSlide;
    public bool isWallJump;
    public bool canDash =true;

    [Header("Material")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D slipy;

    private void Awake()
    {
        controller = new PlayerController();
        rb = GetComponent<Rigidbody2D>();
        physicsSetting = GetComponent<PhysicsSetting>();
        playerAnimation = GetComponent<PlayerAnimation>();
        coll = GetComponent<CapsuleCollider2D>();
        character = GetComponent<Character>();
        controller.GamePlayer.Jump.started += Jump; //input system中单次执行的方法
        controller.GamePlayer.Attack.started += PlayerAttack;
        controller.GamePlayer.Dash.started += Dash;
    }



    private void OnEnable()//启动
    {
        controller.Enable();
    }

    private void OnDisable()//关闭
    {
        controller.Disable();
    }

    private void Update()//每帧更新
    {
        inputDir = controller.GamePlayer.Move.ReadValue<Vector2>();

        if (inputDir.x > 0)
            facingDir = 1;
        if (inputDir.x < 0)
            facingDir= -1;
    }

    private void FixedUpdate()//固定频率更新
    {
        if (!isHurt && !isAttack && !isDash && !isWallJump) 
            Move();
        WallSlide();
    }

    //移动方法
    public void Move()
    {
        rb.velocity = new Vector2(inputDir.x * Speed * Time.deltaTime, rb.velocity.y);//提取input system中的数据

        //翻转方法
        transform.localScale = new Vector3(facingDir*5, 5, 1);

    }

    //跳跃方法
    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsSetting.isGrounded && !isDash) 
            rb.AddForce(transform.up * jumpForce , ForceMode2D.Impulse); //施加一个向上的力，瞬时执行mode
        else if (isWallSlide) 
        {
            isWallSlide = false;
            StartCoroutine(WallJumpDur());
        }
    }

    //玩家攻击方法
    private void PlayerAttack(InputAction.CallbackContext context)
    {
        rb.velocity = Vector2.zero;
        playerAnimation.PlayerAttack();
        isAttack = true;
    }

    //冲刺方法
    private void Dash(InputAction.CallbackContext context)
    {
        if (isDash || !canDash)
            return;
        canDash = false;
        StartCoroutine(DashDur());
    }

    //冲刺流程
    private IEnumerator DashDur()//携程
    {
        character.TriggerInvulnerable();
        isDash = true;
        rb.velocity = new Vector2(facingDir * DashSpeed, 0);
        yield return new WaitForSeconds(DashDurTime);//等待持续时间
        isDash = false;
        yield return new WaitForSeconds(DashCD);//等待CD
        canDash = true;
    }

    //滑墙方法
    private void WallSlide()
    {
        if (isWallJump)
        {
            isWallSlide = false;
            return;
        }
        if (physicsSetting.isWalled && !physicsSetting.isGrounded && inputDir.x ==facingDir && rb.velocity.y<0)
        {
            isWallSlide = true;
            rb.velocity = new Vector2(0, -wallSlideSpeed);
        }
        else 
            isWallSlide = false;
    }

    //蹬墙跳携程
    private IEnumerator WallJumpDur()
    {
        isWallJump = true;
        isWallSlide = false;
        rb.velocity = new Vector2(-facingDir * wallJumpX, wallJumpY);
        facingDir = -facingDir;
        yield return new WaitForSeconds(wallJumpTime);
        isWallJump = false;
    }

    //Unity事件（受伤与死亡）
    #region UnityEvent
    public void GetHurt(Transform attack)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(transform.position.x - attack.position.x, 0).normalized;
        rb.AddForce(dir*hurtForce,ForceMode2D.Impulse);
    }

    public void PlayerDead()
    {
        isDead = true;
        controller.GamePlayer.Disable();
    }
    #endregion

    private void CheckState()
    {
        coll.sharedMaterial = physicsSetting.isGrounded ? normal : slipy;
    }
}
