
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
    internal override void Shoot(Vector2 direction)
    {
        col.enabled = true;
        transform.up = direction;
        Destroy(gameObject, 2f);

    }

}
