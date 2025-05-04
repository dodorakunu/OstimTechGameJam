using TMPro;
using UnityEngine;

public class ZombiesHealthSystem : MonoBehaviour
{
    public float Zombiehealth;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Zombiehealth -= (100f / 3f);
            
        }
        if (Zombiehealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
