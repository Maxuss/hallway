using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class LightFlicker : MonoBehaviour
    {
        [SerializeField] private Light light;

        private IEnumerator Flicker()
        {
            float minFlickerSpeed = 0.1f;
            float maxFlickerSpeed = 1.0f;
            while (true)
            {
                light.enabled = true;
                yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
                light.enabled = false;
                yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            }
        }

        private void Start()
        {
            StartCoroutine(Flicker());
        }
    }
}