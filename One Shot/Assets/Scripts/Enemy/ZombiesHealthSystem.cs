using UnityEngine;

public class ZombiesHealthSystem : MonoBehaviour
{
    public float Zombiehealth;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Zombiehealth -= 10f;
        }
        if (Zombiehealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
