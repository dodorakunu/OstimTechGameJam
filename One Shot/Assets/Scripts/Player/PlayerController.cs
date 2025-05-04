using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public PlayerHealthSystem playerHealthSystem;
    public GameObject collier;

    private float nextAllowedTime = 0f;
    public float cooldownTime = 2f;//sonraki U harfine basýþ
    public GameObject capsule;
    public Animator anim;
    void Start()
    {
        


        anim = capsule.GetComponent<Animator>();
        

       playerHealthSystem = GetComponent<PlayerHealthSystem>();
    rb = GetComponent<Rigidbody2D>();
}

    // Update is called once per frame
    void Update()
    {

        RotateToMouse();
        if(playerHealthSystem.stamina >= 20)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextAllowedTime) // Sað týk
            {
                nextAllowedTime = Time.time + cooldownTime;
                playerHealthSystem.stamina -= 20f;
                anim.SetTrigger("attack");
                collier.SetActive(true);
                StartCoroutine(wait());
            }
        }
       
       

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(playerHealthSystem.stamina < 0)
        {
            playerHealthSystem.stamina = 0;
        }
    }


    void RotateToMouse()
    {
        // Mouse pozisyonunu dünya koordinatýna çevir
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;

        // Açý hesapla
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Sprite yukarýya bakýyorsa +90 veya -90 derecelik düzeltme gerekebilir
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    void FixedUpdate()
    {
        if (playerHealthSystem.stamina <100 && !Input.GetKey(KeyCode.LeftShift))
        {
            playerHealthSystem.stamina += 0.5f;
        }
       
        if (playerHealthSystem.stamina > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed += sprintMultiplier;
                playerHealthSystem.stamina -= 2f;
            }
            else
            {
                moveSpeed = 5f;
            }
        }
        else
        {
            moveSpeed = 5f;
        }
        
        // Hareket ettirme
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

   IEnumerator wait()
    {
        yield return new WaitForSeconds(1.28f);
        collier.SetActive(false);
    }
}
