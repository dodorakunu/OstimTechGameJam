using UnityEngine;

public class CombatAnimEvent : MonoBehaviour
{
        public GameObject swordHitbox;

        public void EnableHitbox()
        {
            swordHitbox.SetActive(true);
        }

        public void DisableHitbox()
        {
            swordHitbox.SetActive(false);
        }
 }

