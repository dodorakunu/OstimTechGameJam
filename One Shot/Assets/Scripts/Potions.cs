using UnityEngine;

public class Potions : MonoBehaviour
{
    private PlayerHealthSystem healthSystem;
    void Start()
    {
        healthSystem = GetComponent<PlayerHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
