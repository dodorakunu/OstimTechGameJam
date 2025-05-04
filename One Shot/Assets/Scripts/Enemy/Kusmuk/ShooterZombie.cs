using System.Collections;
using UnityEngine;

public class ShooterZombie : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    private float shootTimer;

    public float moveSpeed = 2f;         // Oyuncuya yaklaşma hızı
    public float escapeSpeed = 2f;       // Oyuncudan kaçma hızı
    public float maxChaseDistance = 15f;
    public float minEscapeDistance = 10f;

    private Transform player;
    private ZombiesHealthSystem zombiesHealthSystem;
    private Rigidbody2D rb;

    private bool isEscaping = false;
    private bool canShoot = true;

    void Start()
    {
        zombiesHealthSystem = GetComponent<ZombiesHealthSystem>();
        zombiesHealthSystem.Zombiehealth = 200f;
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        // ROTATE TO FACE PLAYER
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleToPlayer + 90f);

        // MOVE
        if (!isEscaping)
        {
            if (distance > maxChaseDistance)
            {
                // Oyuncuya yaklaş
                rb.linearVelocity = directionToPlayer * moveSpeed;
            }
            else if (distance < minEscapeDistance)
            {
                // Oyuncudan kaç
                rb.linearVelocity = -directionToPlayer * escapeSpeed;
                isEscaping = true;
                StartCoroutine(StopEscape());
            }
            else
            {
                // Dur
                rb.linearVelocity = Vector2.zero;
            }
        }

        // SHOOT
        if (canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;

        Vector2 direction = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction); // yönlü rotation

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, rotation);

        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        if (rbProjectile != null)
        {
            rbProjectile.linearVelocity = direction * 10f;
        }

        StartCoroutine(ResetShoot());
    }

    IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }

    IEnumerator StopEscape()
    {
        yield return new WaitForSeconds(1f); // 1 saniye kaçtıktan sonra normale dön
        isEscaping = false;
    }
}
