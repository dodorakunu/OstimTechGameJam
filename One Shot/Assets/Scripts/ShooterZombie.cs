using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ShooterZombie : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    private float shootTimer;
    public float ARROWzombieSpeed = 10f;
    public int a = 0;
    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * ARROWzombieSpeed * Time.deltaTime);

        if (player == null) return;
        firePoint.position = player.position;

        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleToPlayer + 90f);
    }

    void Shoot()
    {
        if (a == 0)
        {
            Vector2 direction = (firePoint.position - transform.position).normalized;
            Quaternion rotation = transform.rotation;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * 10f; // H�z burada ayarlan�yor
            }
            StartCoroutine(wait());
            a++;
        }
        
    
    }

    public float escapeSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 dirToPlayer1 = (player.position - transform.position).normalized;

        if (collision.CompareTag("Player"))
        {
            // Mermiyi fırlat
            

            // Oyuncu çok yakınsa kaç
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= 5f)
            {
                Debug.Log("Çok yakın! Kaçıyorum!");

                // Tam tersi yöne dön
                Vector2 oppositeDir = -dirToPlayer1;
                float escapeAngle = Mathf.Atan2(oppositeDir.y, oppositeDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, escapeAngle+90);

                // Hareket etmeye başla
                rb.linearVelocity = oppositeDir * escapeSpeed;
            }
            else{
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)(direction * ARROWzombieSpeed * Time.deltaTime);
            }
            Shoot();
            
            

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        a--;
    }

}
