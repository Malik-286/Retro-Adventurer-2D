using UnityEngine;

namespace Helios.GUI {
    public class PanelController : MonoBehaviour {
        public void Back() {
            GameManager.Instance.Back();
        }

        public void LoadGameObject(GameObject go) {
            GameManager.Instance.LoadGameObject(go);
        }

        public void LoadPopup(GameObject go) {
            GameManager.Instance.LoadPopup(go);
        }

        public void BackHome() {
            GameManager.Instance.BackHome();
        }
    }
}
