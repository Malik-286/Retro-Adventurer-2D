using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI {
    public class ControlPanel : MonoBehaviour {
        private int _nbPage = 0;
        private bool _isReady = false;
        private TextMeshProUGUI _textTitle;

        [SerializeField] private List<GameObject> _lsPanel = new List<GameObject>();
        [SerializeField] private Transform _tfPanel;
        [SerializeField] private Button _btnPrev;
        [SerializeField] private Button _btnNext;

        private void Start() {
            _textTitle = transform.GetComponentInChildren<TextMeshProUGUI>();
            _btnPrev.onClick.AddListener(Click_Prev);
            _btnNext.onClick.AddListener(Click_Next);

            foreach(Transform t in _tfPanel) {
                _lsPanel.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }

            _lsPanel[_nbPage].SetActive(true);
            _isReady = true;

            CheckControl();
        }

        void Update() {
            if(_lsPanel.Count <= 0 || !_isReady) return;

            if(Input.GetKeyDown(KeyCode.LeftArrow))
                Click_Prev();
            else if(Input.GetKeyDown(KeyCode.RightArrow))
                Click_Next();
        }

        //Click_Prev
        public void Click_Prev() {
            if(_nbPage <= 0 || !_isReady) return;

            _lsPanel[_nbPage].SetActive(false);
            _lsPanel[_nbPage -= 1].SetActive(true);
            _textTitle.text = _lsPanel[_nbPage].name;
            CheckControl();
        }

        //Click_Next
        public void Click_Next() {
            if(_nbPage >= _lsPanel.Count - 1) return;

            _lsPanel[_nbPage].SetActive(false);
            _lsPanel[_nbPage += 1].SetActive(true);
            CheckControl();
        }

        void SetArrowActive() {
            _btnPrev.gameObject.SetActive(_nbPage > 0);
            _btnNext.gameObject.SetActive(_nbPage < _lsPanel.Count - 1);
        }

        //SetTitle, SetArrow Active
        private void CheckControl() {
            _textTitle.text = _lsPanel[_nbPage].name.Replace("_", " ");
            SetArrowActive();
        }
    }
}
