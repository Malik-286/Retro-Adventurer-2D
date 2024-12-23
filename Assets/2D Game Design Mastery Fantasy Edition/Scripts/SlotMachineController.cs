using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI {
    public class SlotMachineController : MonoBehaviour {
        [SerializeField] Animator[] _animators;
        [SerializeField] float _nbAnimationTime = 15f;
        [SerializeField] Button _btnTurnSlotMachine;
        [SerializeField] Image _imgTurnDownHandle;

        private void OnEnable() {
            _btnTurnSlotMachine.onClick.AddListener(TurnSlotMachine);
        }

        private void OnDisable() {
            _btnTurnSlotMachine.onClick.RemoveAllListeners();
        }

        private void TurnSlotMachine() {
            _btnTurnSlotMachine.targetGraphic.gameObject.SetActive(false);
            _imgTurnDownHandle.gameObject.SetActive(true);

            foreach(var animator in _animators) {
                animator.SetTrigger("Start");
            }

            var stopTime = _nbAnimationTime / 3;
            Invoke(nameof(StopLeftSlotAnimation), stopTime);
            Invoke(nameof(StopMiddleSlotAnimation), stopTime * 2);
            Invoke(nameof(StopRightSlotAnimation), _nbAnimationTime);
        }

        void StopLeftSlotAnimation() {
            _animators[0].SetTrigger("Stop");
        }

        void StopMiddleSlotAnimation() {
            _animators[1].SetTrigger("Stop");
        }

        void StopRightSlotAnimation() {
            _animators[2].SetTrigger("Stop");

            _btnTurnSlotMachine.targetGraphic.gameObject.SetActive(true);
            _imgTurnDownHandle.gameObject.SetActive(false);
        }
    }
}
