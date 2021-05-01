using UnityEngine;
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
        private Animation _talk;
        private void Start()
        {
            waiter.SetActive(false);
            protect.SetActive(false);
            _talk = waiter.GetComponent<Animation>();
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