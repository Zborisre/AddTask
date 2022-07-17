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

    // Старт, назначение здоровья, поля заполнения и напраления камеры
    void Start()
    {
        rotationToCamera = Camera.main.transform.rotation;
        fill = 1f;
        Health = HealthNum;
    }

    // Поворот канваса к камере, функция если HP <= 0 и показ его на изображении
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

    // Функция получения урона
    public void Attack(int Damage)
    {
        Health = Health - Damage;
        fill = (float)Health / HealthNum;
    }

    // Функция смерти, создание нового объекта в рандомных координатах, отключение данного объекта, и показ текста, количества смертей
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
