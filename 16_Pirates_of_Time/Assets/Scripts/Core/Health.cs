using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{

    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        [SerializeField] Animator animator;
        [SerializeField] AudioClip impactSoundFX;

        AudioSource audioSource;

        bool isDead = false;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {            
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            audioSource.PlayOneShot(impactSoundFX, 0.7F);
            Debug.Log(gameObject.name + "Hit! Health = " + healthPoints);
            if (healthPoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;
            Debug.Log(gameObject.name + "Is Dead!");
            isDead = true;
            animator.SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
            DisableColliders();
            Destroy(gameObject, 2f);
        }

        private void DisableColliders()
        {
            Collider[] colliders = GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
        }


        // === SAVING ===
        // object ISaveable.CaptureState()
        // {
        //     return healthPoints;
        // }


        // void ISaveable.RestoreState(object state)
        // {
        //     healthPoints = (float)state;
        //     if (healthPoints == 0)
        //     {
        //         Die();
        //     }
        // }
    }
}
