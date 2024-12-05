
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MiniBullet : Bullet
{
    // ����������
    [SerializeField] private Rigidbody2D rb; // ������
    [SerializeField] private BoxCollider2D col; // ��������

   

    
    /// <summary>
    /// ��������������� ������ �������� ������ ���������
    /// </summary>
    /// <param name="direction"></param>
    internal void Shoot(Vector2 d)
    {
        col.enabled = true;
        rb.AddForce(d, ForceMode2D.Force);

    }

 

}
