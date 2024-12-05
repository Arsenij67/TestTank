
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    // ����������
   
    private float buffAngle = 0; // ������� �������� ��������
    private float frameDelay = 0.05f;// ����� ����� �����
    private float buffTime = 0;// ������� �������
    private float muzzleSpeed = 40; // �������� �������� ����: ��� ������, ��� �������
    [SerializeField] private Transform start; // ������ � ����� ���� ��� �����������
    [SerializeField] private Transform end;
    [SerializeField] private Bullet bulletPrefab; //������ ����
    [SerializeField] private Slider forceSlider; // ������ �� ������� ����
    [Tooltip("��������� ������ �������������� ����� � ���������: �� 0 �� 1. 1 - 90 ��������, 0 - 0 ��������")]
    [SerializeField] private float rangeRotate = 0.6F; //�������� ��������


    // ������
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
    /// ������������ ���� ������
    /// </summary>
    /// <param name="muzzle">��������� �����</param>
   private void RotateMuzzle(Transform muzzle)
    {
        buffAngle += ((muzzleSpeed * Time.deltaTime));
        muzzle.localRotation = Quaternion.Euler(0, 0, Mathf.Cos(buffAngle) * Mathf.Rad2Deg*rangeRotate);
        
    }

    /// <summary>
    /// ������� ������ ��������
    /// </summary>
    public void Shoot()
    {
      
        Bullet bull = Instantiate(bulletPrefab,end.transform.position,transform.rotation);
        Vector2 direction = end.position - start.position;
        direction.Normalize();
        bull.Shoot(direction);
    
    }
    /// <summary>
    /// ������ ��������� ����� �������� �� �������
    /// </summary>
    public void ChangeForce()
    {
        Bullet.bulletForce = forceSlider.value;

    }


}
