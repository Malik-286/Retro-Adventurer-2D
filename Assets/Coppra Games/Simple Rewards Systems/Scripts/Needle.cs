using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoppraGames
{
    public class Needle : MonoBehaviour
    {
        public RectTransform RectTransform;
        private Collider2D _lastCollider;
        private bool _rotationStarted;
        private bool _returnStarted;

        private float _upAngle = 45.0f;
        private float _downAngle = 0.0f;

        private void LateUpdate()
        {
            float val = RectTransform.localEulerAngles.z;
            if (_returnStarted)
            {
                val = Mathf.Lerp(val, _downAngle, Time.deltaTime * 4.0f);
                if (val <= _downAngle + 5.0f)
                {
                    val = _downAngle;
                }
            }
            else if (_rotationStarted)
            {
                val = Mathf.Lerp(val, _upAngle, Time.deltaTime * 6.0f);
                if (val >= _upAngle - 5.0f)
                {
                    val = _upAngle;
                }
            }

            if (_returnStarted || _rotationStarted)
            {
                Vector3 eulerAngles = RectTransform.localEulerAngles;
                eulerAngles.z = val;
                RectTransform.localEulerAngles = eulerAngles;
            }

            if (val == _upAngle)
            {
                _Return();
            }
            else if (val == _downAngle)
            {
                _rotationStarted = false;
                _returnStarted = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision == _lastCollider)
                return;

            _StartRotation();

            _lastCollider = collision;
        }

        private void _StartRotation()
        {
            _returnStarted = false;
            _rotationStarted = true;

            GetComponentInParent<SpinWheelController>().OnTriggerNeedle();
        }

        private void _Return()
        {
            _returnStarted = true;
        }

    }
}
