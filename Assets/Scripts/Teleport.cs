using UnityEngine;
using UnityEngine.Video;

namespace DefaultNamespace
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private GameObject trigger;
        [SerializeField] private float[] coordinates = new float[3];
        [SerializeField] private AudioSource glitchSound;
        [SerializeField] private VideoPlayer glitchEffect;
        private void OnTriggerEnter(Collider tCollider)
        {
            if (tCollider.CompareTag(trigger.tag))
            {
                gameObject.transform.position = new Vector3(coordinates[0], coordinates[1], coordinates[2]);
                glitchSound.Play();
                glitchEffect.Play();
            }
        }
    }
}