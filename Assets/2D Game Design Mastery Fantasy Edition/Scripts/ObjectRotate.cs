using UnityEngine;

namespace Helios.GUI {
    public class ObjectRotate : MonoBehaviour {
        public Vector3 Rotation = Vector3.one;

        private Transform _transform;

        void Awake() {
            _transform = transform;
        }

        void LateUpdate() {
            _transform.Rotate(Rotation);
        }
    }
}