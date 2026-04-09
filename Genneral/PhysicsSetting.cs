using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsSetting : MonoBehaviour
{
    public float checkRadius;
    public LayerMask Ground;
    public bool isGrounded;
    public bool isWalled;
    public Transform GroundCheck;
    public Transform WallCheck;

    private void Update()
    {
        Check();
    }
    public void Check()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);//在人物位置创建圆形区域用作检测
        isWalled = Physics2D.OverlapCircle(WallCheck.position, checkRadius, Ground);
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(GroundCheck.position, checkRadius);//绘制圆形区域范围用作调整
        Gizmos.DrawWireSphere(WallCheck.position, checkRadius);
    }
}
