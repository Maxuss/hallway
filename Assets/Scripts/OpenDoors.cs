using UnityEngine;

namespace DefaultNamespace
{
    public class OpenDoors : MonoBehaviour
    {
        [SerializeField] private string doorName = "Door";
        [SerializeField] private AudioSource doorSound;
        private void Update()
        {
            int layerMask = ~(1 << 8);
            RaycastHit hit;
            if (Input.GetKeyDown(KeyCode.E))
                if (
                    Physics.Raycast(
                        transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerMask
                    )
                    &&
                    hit.transform.gameObject.name == doorName
                )
                {
                    doorSound.Play();
                }
        }
    }
}