using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class JumpscareAxe : MonoBehaviour
    {
        [SerializeField] private GameObject waiter;
        [SerializeField] private AudioSource door;
        [SerializeField] private AudioSource disappear;
        [SerializeField] private GameObject trigger;
        [SerializeField] private GameObject protect;

        private void Start()
        {
            waiter.SetActive(false);
            protect.SetActive(false);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(trigger.tag))
            {
                waiter.SetActive(true);
                door.Play();
                protect.SetActive(true);
                Invoke(nameof(Disappear), 5);
            }
        }
        private void Disappear()
        {
            waiter.SetActive(false);
            disappear.Play();
            protect.SetActive(false);
        }
    }
}