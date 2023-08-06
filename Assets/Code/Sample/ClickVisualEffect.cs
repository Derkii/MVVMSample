using System;
using TMPro;
using UnityEngine;

namespace Code.Sample
{
    public class ClickVisualEffect : MonoBehaviour
    {
        [SerializeField]
        private float _time;
        [SerializeField] private TextMeshProUGUI _text;
        private float _timer;
        [SerializeField] private float _speed = 5f;

        public void SetText(string text)
        {
            _text.text = text;
        }

        private void Awake()
        {
            _timer = _time;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                Destroy(gameObject);
            }

            transform.position += new Vector3(0, _speed, 0f) * Time.deltaTime;
        }
    }
}