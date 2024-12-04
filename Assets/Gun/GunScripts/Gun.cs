
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    // ПЕРЕМЕННЫЕ
   
    private float buffAngle = 0; // счетчик углового поворота
    private float frameDelay = 0.05f;// время оного кадра
    private float buffTime = 0;// счетчик времени
    private float muzzleSpeed = 20; // скорость вращения дула: чем больше, тем быстрей
    [SerializeField] private Transform start; // начало и конец дула для направления
    [SerializeField] private Transform end;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Slider forceSlider;


    // МЕТОДЫ
    void Update()
    {
        if (buffTime < frameDelay)
        {
            buffTime += Time.deltaTime;
        }
        else
        {

            RotateMuzzle(transform);
            buffTime = 0;
            
        }
    }

    /// <summary>
    /// Поворачивает дуло машины
    /// </summary>
    /// <param name="muzzle">трансформ пушки</param>
   private void RotateMuzzle(Transform muzzle)
    {
        buffAngle += ((muzzleSpeed * Time.deltaTime));
        muzzle.localRotation = Quaternion.Euler(0, 0, Mathf.Cos(buffAngle) * Mathf.Rad2Deg);
        
    }

    /// <summary>
    /// Выстрел больым снарядом
    /// </summary>
    public void Shoot()
    {
      
        Bullet bull = Instantiate(bulletPrefab,end.transform.position,transform.rotation);
        Vector2 direction = end.position - start.position;
        direction.Normalize();
        bull.Shoot(direction);
    
    }
    /// <summary>
    /// меняем громкость через подписку на событие
    /// </summary>
    public void ChangeForce()
    {
        Bullet.bulletForce = forceSlider.value;

    }


}
