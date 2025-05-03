using System.Collections;
using UnityEngine;

public class ShooterZombie : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    private float shootTimer;
    public float ARROWzombieSpeed = 10f;
    public float escapeSpeed = 2f;
    private ZombiesHealthSystem zombiesHealthSystem;

    private Rigidbody2D rb;
    private bool isEscaping = false;
    private int a = 0;

    void Start()
    {
        zombiesHealthSystem = GetComponent<ZombiesHealthSystem>();
        zombiesHealthSystem.Zombiehealth = 200f; //zombie canı  
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        // ROTATION
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleToPlayer + 90f);

        // MOVEMENT
        if (!isEscaping)
        {
            if (distance > 15f)
            {
                // Oyuncuya yaklaş
                rb.linearVelocity = directionToPlayer * ARROWzombieSpeed;
            }
            else if (distance < 10f)
            {
                // Oyuncudan uzaklaş (kaçma modu)
                Vector2 escapeDir = -directionToPlayer;
                rb.linearVelocity = escapeDir * escapeSpeed;
                isEscaping = true;

                // Kaçma modunu bir süre sonra kapat
                StartCoroutine(StopEscape());
            }
            else
            {
                // Mesafe aralıkta, dur
                rb.linearVelocity = Vector2.zero;
            }
        }

        // ATEŞ
        Shoot();
    }

    void Shoot()
    {
        if (a == 0)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Quaternion rotation = transform.rotation;

            GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);

            


            Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
            if (rbProjectile != null)
            {
                rbProjectile.linearVelocity = direction * 10f;
            }

            a++;
            StartCoroutine(ResetShoot());
        }
    }

    IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(shootInterval);
        a = 0;
    }

    IEnumerator StopEscape()
    {
        yield return new WaitForSeconds(1f); // 1 saniye kaçtıktan sonra normal moda dön
        isEscaping = false;
    }
}
