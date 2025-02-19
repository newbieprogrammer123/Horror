using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField] private Text countBulletText;
    [SerializeField] private GameObject bulletPrefab, spawnBulletPosition;
    [SerializeField] private float bulletForce;

    private float timeShoot = 0.3f, currentTimeShoot;
    private float timeReload = 2f, currentTimeReload;
    private int countBullet = 90, currentCountBullet, maxCountBullet = 30;

    private Animator animator;

    private TypeGunAnim prevAnim = TypeGunAnim.Walk;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentCountBullet = maxCountBullet;
        currentTimeReload = 0;

        UpdateBulletText();
        PlayAnimation(TypeGunAnim.Idle);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && currentTimeShoot <= 0 
            && currentCountBullet > 0 && currentTimeReload <= 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && currentTimeShoot <= 0 
            && currentTimeReload <= 0 && currentCountBullet < countBullet)
        {
            Reload();
            currentCountBullet = maxCountBullet;

            UpdateBulletText();
        }

        if (currentTimeShoot > 0)
        {
            currentTimeShoot -= Time.deltaTime;
        }

        if(currentTimeReload > 0)
        {
            currentTimeReload -= Time.deltaTime;
        }
    }

    public void AddBullets(int count)
    {
        countBullet += count;
    }

    private void Shoot()
    {
        currentCountBullet--;
        UpdateBulletText();

        currentTimeShoot = timeShoot;

        PlayAnimation(TypeGunAnim.Shoot);

        GameObject bullet = Instantiate(bulletPrefab, spawnBulletPosition.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(spawnBulletPosition.transform.forward * bulletForce, ForceMode.Impulse);

        Destroy(bullet, 3f);
    }

    private void Reload()
    {
        if (countBullet > 0)
        {
            PlayAnimation(TypeGunAnim.Reload);

            currentTimeReload = timeReload;

            Invoke(nameof(WaitReload), timeReload);
        }
    }

    private void WaitReload()
    {
        int count;

        if(30 > countBullet)
        {
            count = countBullet;
        }
        else
        {
            count = 30;
        }

        countBullet -= count;


        currentCountBullet = count;
        UpdateBulletText();
    }

    public void PlayAnimation(TypeGunAnim type)
    {
        if (prevAnim != type && currentTimeReload <= 0)
        {
            prevAnim = type;
            animator.SetTrigger(type.ToString());
        }
    }

    private void UpdateBulletText()
    {
        countBulletText.text = $"{currentCountBullet}/{countBullet}";
    }
}

public enum TypeGunAnim
{
    Idle,
    Walk,
    Reload,
    Shoot
}
