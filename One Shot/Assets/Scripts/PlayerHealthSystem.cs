using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float maxTime = 120f; // Oyuncunun ba�lang�� s�resi (saniye cinsinden)
    public float currentTime;
    public bool isDead = false;
    public float damageMult = 1;
    public bool posioned = false;
    public float stamina = 100f;

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
        else
        {
            currentTime = maxTime;
        }


        if (currentTime <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Zaman doldu! Oyuncu �ld�.");
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

