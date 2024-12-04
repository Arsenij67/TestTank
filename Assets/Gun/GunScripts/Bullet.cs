using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    // ПЕРЕМЕННЫЕ
    internal static float bulletForce = 500f; // скорость пули
    [SerializeField] private MiniBullet[] miniBullets; // массив снарядов
    private AudioSource audioSource; // музыка
    private Rigidbody2D rb; // физика
    [SerializeField] private ParticleSystem exploadBull; // эффект взрыва

    //МЕТОДЫ
    private void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// Реализует выстрел базовой пули
    /// </summary>
    /// <param name="direction">направление базовой пули</param>
    internal virtual void Shoot(Vector2 direction)
    {
        transform.up = direction;
        audioSource.PlayOneShot(audioSource.clip);
        rb.AddForce(direction * bulletForce, ForceMode2D.Force);
        foreach (var miniB in miniBullets)
        {
            miniB.rb?.AddForce(direction * bulletForce, ForceMode2D.Force);
        }
        Destroy(gameObject, 3f);
        StartCoroutine(ShotMiniBullets(direction));

    }
    /// <summary>
    /// Коротина для задержки стрельбы вложенными пулями
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private IEnumerator ShotMiniBullets(Vector2 dir)
    {
        yield return new WaitForSeconds(0.3f);

        foreach (var miniB in miniBullets)
        {
           miniB.transform.SetParent(null,true);
           miniB.Shoot(dir);
        
        }
    }
    /// <summary>
    /// Уничтожение при соприкосновении с землёй
    /// </summary>
    /// <param name="collision"></param>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Bullet"))
        {
            exploadBull.Play();
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject, 0.3f);


        }
    }




}
