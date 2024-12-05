
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MiniBullet : Bullet
{
    // ПЕРЕМЕННЫЕ
    [SerializeField] private Rigidbody2D rb; // физика
    [SerializeField] private BoxCollider2D col; // коллизии

   

    
    /// <summary>
    /// Переопределённая логика стрельбы малыми снарядами
    /// </summary>
    /// <param name="direction"></param>
    internal void Shoot(Vector2 d)
    {
        col.enabled = true;
        rb.AddForce(d, ForceMode2D.Force);

    }

 

}
