using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
#if DOTWEEN
using DG.Tweening;
#endif

namespace Helios.GUI {
    public class FakeLoadingBar : MonoBehaviour {
        [SerializeField] private Slider _sdLoadingBar;
        [SerializeField] private GameObject _objNextScreen;
        [SerializeField] private TMPro.TMP_Text _txtLoadingPercent;
        [SerializeField] private GameObject[] _arrNextPopup;

        private void OnEnable() {
            _sdLoadingBar.value = 0;
            _txtLoadingPercent.text = "0";

            StartCoroutine(FakeLoading());
        }

        private IEnumerator FakeLoading() {
            yield return new WaitForSeconds(Random.Range(0.3f, 1f));

            var currentValue = _sdLoadingBar.value;
            currentValue += Random.Range(10, 21);
            if(currentValue >= 100) {
                currentValue = 100;
            }
#if DOTWEEN
            _sdLoadingBar.DOValue(currentValue, 0.3f);
#else
            _sdLoadingBar.value = currentValue;
#endif
            _txtLoadingPercent.text = $"{currentValue}%";

            if(currentValue >= 100) {
                yield return new WaitForSeconds(Random.Range(0.3f, 1f));

                GameManager.Instance.Back();
                GameManager.Instance.LoadPopup(_objNextScreen);
                foreach(var item in _arrNextPopup) {
                    GameManager.Instance.LoadPopup(item);
                }

                StopAllCoroutines();
            }
            else {
                StartCoroutine(FakeLoading());
            }
        }
    }
}
