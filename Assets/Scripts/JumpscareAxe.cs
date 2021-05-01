using System;
using UnityEngine;
using LightType = Lights.LightType;

namespace DefaultNamespace
{
    public class JumpscareAxe : MonoBehaviour
    {
        [SerializeField] private GameObject waiter;
        [SerializeField] private AudioSource door;
        [SerializeField] private AudioSource disappear;
        [SerializeField] private GameObject trigger;
        [SerializeField] private GameObject protect;
        [SerializeField] private Light[] lighting;
        [SerializeField] private AudioSource turnOn;
        [SerializeField] private AudioSource turnOff;
        private float[] _constLighting = new float[256];

        public void Turn(LightType type)
        {
            switch (type)
            {
                case LightType.On:
                    TurnOn();
                    break;
                case LightType.Off:
                    TurnOff();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void TurnOff()
        {
            foreach (Light light1 in lighting)
            {
                light1.intensity = 0f;
            }
            turnOff.Play();
        }

        private void TurnOn()
        {
            for (int i = 0; i < lighting.Length; i++)
            {
                lighting[i].intensity = _constLighting[i];
            }
            turnOn.Play();
        }
        private void Start()
        {
            waiter.SetActive(false);
            protect.SetActive(false);
        for (int i = 0; i < lighting.Length; i++)
        {
            _constLighting[i] = lighting[i].intensity;
        }
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
            Turn(LightType.Off);
            waiter.SetActive(false);
            disappear.Play();
            protect.SetActive(false);
            Invoke(nameof(TurnOn), 2);
        }
    }
}