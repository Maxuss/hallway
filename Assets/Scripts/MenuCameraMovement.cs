using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MenuCameraMovement : MonoBehaviour
    {
        [SerializeField] private new GameObject camera;
        [SerializeField] private float verticalSpeed = 0.5f;
        [SerializeField] private float horizontalSpeed = 0.5f;
        private float _x;
        private float _y;
        private void Update()
        {
            var vInput = Input.GetAxis("Mouse Y") * verticalSpeed;
            var hInput = Input.GetAxis("Mouse X") * horizontalSpeed;
            _x += vInput;
            _y -= hInput;
            _x = Mathf.Clamp(_x, -90, 90);
            camera.transform.eulerAngles = new Vector3(-_x, -_y, 0.0f);
        }
    }
}