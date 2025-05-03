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
        if (Input.GetKeyDown(KeyCode.U)) // Sa� t�k
        {
            anim.SetTrigger("attack");
            collier.SetActive(true);
            StartCoroutine(wait());
        }
       

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(playerHealthSystem.stamina < 0)
        {
            playerHealthSystem.stamina = 0;
        }
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
