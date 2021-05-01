using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DefaultNamespace
{
    public class IncreaseVignette : MonoBehaviour
    {
        [SerializeField] private GameObject trigger1;
        [SerializeField] private GameObject trigger2;
        [SerializeField] private GameObject trigger3;
        [SerializeField] private GameObject trigger4;

        private Vignette _vignette;

        private void Start()
        {
            _vignette = ScriptableObject.CreateInstance<Vignette>();
            _vignette.intensity.value = 0f;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(trigger1.tag))
            {
                _vignette.intensity.value = 0.3f;
            }
            else if (other.CompareTag(trigger2.tag))
            {
                _vignette.intensity.value = 0.6f;
            }
            else if (other.CompareTag(trigger3.tag))
            {
                _vignette.intensity.value = 0.9f;
            }
            else if (other.CompareTag(trigger4.tag))
            {
                _vignette.intensity.value = 1.5f;
            }
        }
    }
}