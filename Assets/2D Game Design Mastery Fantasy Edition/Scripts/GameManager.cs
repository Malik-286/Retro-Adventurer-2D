using System.Collections.Generic;
#if DOTWEEN
using DG.Tweening;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helios.GUI {
    public class GameManager : SingletonPersistent<GameManager> {
        [SerializeField] private GameObject _goRoot;
        [SerializeField] private Transform _tfParent;

        private Stack<GameObject> _stScenes = new Stack<GameObject>();

        void Start() {
            _stScenes.Push(_goRoot);
        }

        public void LoadGameObject(GameObject go) {
            if(SceneManager.GetActiveScene().name.Equals("DemoScene")) {
                return;
            }

            if(_stScenes.Count > 0) {
                var currentObj = _stScenes.Pop();
                currentObj.SetActive(false);
                _stScenes.Push(currentObj);
            }

            LoadPopup(go);
        }

        public void LoadPopup(GameObject go) {
            if(SceneManager.GetActiveScene().name.Equals("DemoScene")) {
                return;
            }

            var instance = Instantiate(go);
            instance.transform.SetParent(_tfParent);
            instance.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            instance.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            instance.transform.localScale = Vector3.one;
            instance.SetActive(true);
            _stScenes.Push(instance);
        }

        public void Back() {
            if(SceneManager.GetActiveScene().name.Equals("DemoScene")) {
                return;
            }

            if(_stScenes.Count == 0) {
                return;
            }

            GameObject obj = _stScenes.Pop();
            TweenFading(obj);

            if(_stScenes.Count == 0) {
                return;
            }

            var item = _stScenes.Pop();
            item.SetActive(true);
            _stScenes.Push(item);
        }

        private void TweenFading(GameObject obj) {
            if(obj.TryGetComponent(out CanvasGroup _cgFadeComponent)) {
                _cgFadeComponent.blocksRaycasts = false;
                void HIdeAndDestroy() {
                    obj.SetActive(false);
                    Destroy(obj, 3f);
                }
#if DOTWEEN
                _cgFadeComponent.DOFade(0, 0.3f).OnComplete(HIdeAndDestroy);
#else
                _cgFadeComponent.alpha = 0;
                HIdeAndDestroy();
#endif
            }
        }

        public void BackHome() {
            while(_stScenes.Count > 1) {
                Back();
            }
        }
    }
}
