using UnityEngine;
using UnityEngine.UI;

public class DamagableObject : MonoBehaviour
{
    public int ColOfDead = 0;
    public int HealthNum = 10;
    private int Health;

    public Text CountOfDead;

    public Image HealthBar;
    private float fill;

    [SerializeField] private GameObject canvas;

    private Quaternion rotationToCamera;

    // �����, ���������� ��������, ���� ���������� � ���������� ������
    void Start()
    {
        rotationToCamera = Camera.main.transform.rotation;
        fill = 1f;
        Health = HealthNum;
    }

    // ������� ������� � ������, ������� ���� HP <= 0 � ����� ��� �� �����������
    void Update()
    {
        if (canvas.transform.rotation != rotationToCamera)
        {
            canvas.transform.rotation = rotationToCamera;
        }
        HealthBar.fillAmount = fill;
        if (Health <= 0)
        {
            Death();
        }
    }

    // ������� ��������� �����
    public void Attack(int Damage)
    {
        Health = Health - Damage;
        fill = (float)Health / HealthNum;
    }

    // ������� ������, �������� ������ ������� � ��������� �����������, ���������� ������� �������, � ����� ������, ���������� �������
    private void Death()
    {
        ColOfDead += 1;
        CountOfDead.text = (" " + ColOfDead.ToString());
        fill = 1f;
        gameObject.SetActive(false);
        Health = HealthNum;
        GameObject bullet = ObjectPooler.instance.SpawnTarget();
        if (bullet != null)
        {
            bullet.transform.position = new Vector3(UnityEngine.Random.Range(-23, 24), 0, UnityEngine.Random.Range(-23, 24));
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

}
