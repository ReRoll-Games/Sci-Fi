using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace VG
{
    [RequireComponent(typeof(Button))]
    public abstract class PressedButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button _button;
        private bool _pressed = false;

        public Button button
        {
            get
            {
                _button ??= GetComponent<Button>();
                return _button;
            }
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
            OnPressStart();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
            OnPressFinish();
        }


        private void Update()
        {
            if (_pressed) PressedUpdate();
        }


        protected abstract void OnPressStart();
        protected abstract void PressedUpdate();

        protected abstract void OnPressFinish();

    }
}
