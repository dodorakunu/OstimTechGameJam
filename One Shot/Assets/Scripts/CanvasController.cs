using UnityEngine;
using TMPro;
public class CanvasController : MonoBehaviour
{
    public TMP_Text infoText;
    public TMP_Text stamina;
    public TMP_Text mult;
    private PlayerHealthSystem playerHealthSystem;
    public GameObject player;
    void Start()
    {
        playerHealthSystem = player.gameObject.GetComponent<PlayerHealthSystem>();
    }


    void Update()
    {
        mult.text = playerHealthSystem.damageMult.ToString("F1");
        infoText.text = playerHealthSystem.currentTime.ToString("F1");
        stamina.text  = playerHealthSystem.stamina.ToString("F1");
    }
}
