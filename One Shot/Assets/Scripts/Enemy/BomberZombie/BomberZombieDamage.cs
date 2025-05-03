using UnityEngine;

public class BomberZombieDamage : MonoBehaviour
{
    public GameObject projectilePrefab;
    private ZombiesHealthSystem zombieshealthSystem;
    void Start()
    {
        zombieshealthSystem = GetComponent<ZombiesHealthSystem>();
        zombieshealthSystem.Zombiehealth = 100f; //zombie caný
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }
}
