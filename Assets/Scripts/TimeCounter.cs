using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    internal class TimeCounter : MonoBehaviour
    {
        [SerializeField] private Text timeText;
        private float _currentFrame;
        private float _currentSecond;
        private float _currentMinute;
        private void Update()
        {
            _currentFrame += 1;
            _currentSecond = _currentFrame / 60;

            if (_currentSecond >= 60)
            {
                _currentMinute += 1;
                _currentSecond = 0;
            }

            if (Time.timeScale > 0)
            {
                timeText.text = $"Your time:\n{_currentMinute} minutes\n{Mathf.Round(_currentSecond)} seconds";
            }
        }
    }
}