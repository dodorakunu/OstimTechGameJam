using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float maxTime = 120f; // Oyuncunun ba�lang�� s�resi (saniye cinsinden)
    public float currentTime;
    public bool isDead = false;
    public float damageMult = 1;
    public bool posioned = false;
    public float stamina = 100f;
    public GameObject DeadScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (posioned == true) 
        {
            currentTime -= Time.deltaTime * damageMult;
        }
        if (currentTime <= 0f)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space)) //potion sistemi i�in tu� 
        {
            posioned = false;
            currentTime = maxTime + (damageMult * 2);
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Zaman doldu! Oyuncu �ld�.");
        Destroy(gameObject);
        DeadScene.SetActive(true);
        
        // Buraya �l�m animasyonu, sahne ge�i�i vs. ekleyebilirsin.
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        Debug.Log("S�re eklendi! Yeni s�re: " + currentTime.ToString("F2"));
    }

    public void SubtractTime(float amount)
    {
        currentTime -= amount;
        Debug.Log("S�re azalt�ld�! Yeni s�re: " + currentTime.ToString("F2"));


    }

    public float GetTimeRemaining()
    {
        return currentTime;
    }

}

