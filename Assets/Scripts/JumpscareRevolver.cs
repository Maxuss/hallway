using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DefaultNamespace
{
    class JumpscareRevolver : MonoBehaviour
    {
        [SerializeField] private GameObject waiter;
        [SerializeField] private AudioSource spook;
        [SerializeField] private AudioSource breath;
        [SerializeField] private AudioSource disappear;
        [SerializeField] private GameObject triggerEnter;
        [SerializeField] private GameObject triggerExit;
        [SerializeField] private GameObject protect;

        private void Start()
        {
            waiter.SetActive(false);
            protect.SetActive(false);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(triggerEnter.tag))
            {
                triggerEnter.SetActive(false);
                spook.Play();
                waiter.SetActive(true);
                protect.SetActive(true);
            }
            else if (other.CompareTag(triggerExit.tag))
            {
                triggerExit.SetActive(false);
                waiter.SetActive(false);
                protect.SetActive(false);
                disappear.Play();
                breath.Play();
            }
        }
    }
}