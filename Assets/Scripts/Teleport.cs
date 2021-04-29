using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private GameObject trigger;
        [SerializeField] private float[] coordinates = new float[3];
        [SerializeField] private AudioSource door;
        [SerializeField] private AudioSource deepBreathe;
        [SerializeField] private Text gameOver;
        [SerializeField] private Text timeT;
        [SerializeField] private Text extra;
        [SerializeField] private AudioSource music;
        private Vignette _vignette;

        private void Start()
        {
            _vignette = ScriptableObject.CreateInstance<Vignette>();
            _vignette.intensity.value = 0f;
            timeT.CrossFadeAlpha(0f, 0, true);
            extra.CrossFadeAlpha(0f, 0, true);
            gameOver.CrossFadeAlpha(0f, 0, true);
        }
        private void TeleportSpook()
        {
            gameObject.transform.position = new Vector3(coordinates[0], coordinates[1], coordinates[2]);
            door.Play();
            _vignette.intensity.value = 1f;
            _vignette.opacity.value = 1f;
            deepBreathe.Play();
            timeT.CrossFadeAlpha(1f, 4, true);
            extra.CrossFadeAlpha(1f, 5, true);
            gameOver.CrossFadeAlpha(1f, 2, true);
            music.Play();
            Time.timeScale = 0;
        }

        private void Update()
        {
            int layerMask = ~(1 << 8);
            RaycastHit hit;
            if (Input.GetKeyDown(KeyCode.E))
                if (
                    Physics.Raycast(
                        transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, layerMask
                    )
                    &&
                    hit.transform.gameObject.CompareTag(trigger.tag)
                    )
                {
                        TeleportSpook();
                }
        }
    }
}