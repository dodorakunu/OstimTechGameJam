using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    public ZombiesHealthSystem ZombiesHealthSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ZombiesHealthSystem = GetComponent<ZombiesHealthSystem>();
        ZombiesHealthSystem.Zombiehealth = 300f;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // D��man ile oyuncu aras�ndaki y�n� hesapla
            Vector2 direction = (player.position - transform.position).normalized;

            // Hareket ettir
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
}
