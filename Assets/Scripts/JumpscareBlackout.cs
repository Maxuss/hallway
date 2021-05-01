using UnityEngine;

namespace DefaultNamespace
{
    public class JumpscareBlackout : MonoBehaviour
    {
        [SerializeField] private GameObject triggerEnter;
        [SerializeField] private GameObject waiter;
        [SerializeField] private AudioSource spook;

        private void Start()
        {
            waiter.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(triggerEnter.tag))
            {
                RopeSpook();
            }
        }

        private void RopeSpook()
        {
            spook.Play();
            waiter.SetActive(true);
            Invoke(nameof(RopeStop), 4);
        }

        private void RopeStop()
        {
            waiter.SetActive(false);
        }
    }
}