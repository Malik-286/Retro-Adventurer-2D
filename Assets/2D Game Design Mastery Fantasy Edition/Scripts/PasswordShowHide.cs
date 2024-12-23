using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI {
    public class PasswordShowHide : MonoBehaviour {
        [SerializeField] private Toggle _tgShowPassword;
        [SerializeField] private TMPro.TMP_InputField _ipPasswordInput;

        public void ShowPassword(bool activate) {
            _ipPasswordInput.contentType = activate ? TMPro.TMP_InputField.ContentType.Standard :
                TMPro.TMP_InputField.ContentType.Password;
            _ipPasswordInput.ForceLabelUpdate();
        }
    }
}
