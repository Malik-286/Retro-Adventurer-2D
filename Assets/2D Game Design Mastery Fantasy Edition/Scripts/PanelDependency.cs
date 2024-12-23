using UnityEngine;

namespace Helios.GUI {
    public class PanelDependency : MonoBehaviour {
        [SerializeField] private GameObject[] otherPanels;

        public void OnEnable() {
            foreach(var panel in otherPanels) {
                if(panel == null) {
                    continue;
                }

                panel.SetActive(true);
            }
        }

        public void OnDisable() {
            foreach(GameObject panel in otherPanels) {
                if(panel == null) {
                    continue;
                }

                panel.SetActive(false);
            }
        }
    }
}
