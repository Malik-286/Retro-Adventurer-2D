using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI {
    public class SimpleScrollSnap : MonoBehaviour {
        [SerializeField] private GameObject _goScrollbar;
        [SerializeField] private GameObject _goPagination;
        [SerializeField] private Sprite[] _arrPaginationSprites;

        private int _nbButtonIndex;
        private bool _isTimeToRun = false;
        private float _nbScrollPosition = 0;
        private float _nbTimer;
        private float _nbDistance = 0f;
        private float[] _arrPosition;
        private Button _btnCliked;
        private Scrollbar _scrollbar;

        private void Awake() {
            _arrPosition = new float[transform.childCount];
            _nbDistance = 1f / (_arrPosition.Length - 1f);
            _scrollbar = _goScrollbar.GetComponent<Scrollbar>();
        }

        // Update is called once per frame
        void Update() {
            if(_isTimeToRun) {
                Snap(_nbDistance, _arrPosition, _btnCliked);
                _nbTimer += Time.deltaTime;

                if(_nbTimer > 1f) {
                    _nbTimer = 0;
                    _isTimeToRun = false;
                }
            }

            for(int i = 0; i < _arrPosition.Length; i++) {
                _arrPosition[i] = _nbDistance * i;
            }

            if(Input.GetMouseButton(0)) {
                _nbScrollPosition = _scrollbar.value;
            }
            else {
                for(int i = 0; i < _arrPosition.Length; i++) {
                    if(_nbScrollPosition < _arrPosition[i] + (_nbDistance / 2) && _nbScrollPosition > _arrPosition[i] - (_nbDistance / 2)) {
                        _scrollbar.value = Mathf.Lerp(_scrollbar.value, _arrPosition[i], 0.1f);
                    }
                }
            }


            for(int i = 0; i < _arrPosition.Length; i++) {
                if(_nbScrollPosition < _arrPosition[i] + (_nbDistance / 2) && _nbScrollPosition > _arrPosition[i] - (_nbDistance / 2)) {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                    _goPagination.transform.GetChild(i).localScale = Vector2.Lerp(_goPagination.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                    _goPagination.transform.GetChild(i).GetComponent<Image>().sprite = _arrPaginationSprites[1];
                    for(int j = 0; j < _arrPosition.Length; j++) {
                        if(j != i) {
                            _goPagination.transform.GetChild(j).GetComponent<Image>().sprite = _arrPaginationSprites[0];
                            _goPagination.transform.GetChild(j).localScale = Vector2.Lerp(_goPagination.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                            transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        }
                    }
                }
            }
        }

        private void Snap(float distance, float[] pos, Button btn) {
            for(int i = 0; i < pos.Length; i++) {
                if(_nbScrollPosition < pos[i] + (distance / 2) && _nbScrollPosition > pos[i] - (distance / 2)) {
                    _scrollbar.value = Mathf.Lerp(_scrollbar.value, pos[_nbButtonIndex], 1f * Time.deltaTime);
                }
            }

            for(int i = 0; i < btn.transform.parent.transform.childCount; i++) {
                btn.transform.name = ".";
            }
        }

        public void WhichBtnClicked(Button btn) {
            btn.transform.name = "clicked";
            for(int i = 0; i < btn.transform.parent.transform.childCount; i++) {
                if(btn.transform.parent.transform.GetChild(i).transform.name == "clicked") {
                    _nbButtonIndex = i;
                    _btnCliked = btn;
                    _nbTimer = 0;
                    _nbScrollPosition = _arrPosition[_nbButtonIndex];
                    _isTimeToRun = true;
                }
            }
        }
    }
}