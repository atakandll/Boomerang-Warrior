using System;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class InputManager : MonoBehaviour
    {
        private bool _isFirstTouchTaken;

        [SerializeField]
        private FloatingJoystick floatingJoystick;

        private bool _hasTouch;

        private bool _isRelease;
        private bool _isClick;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {

            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void FixedUpdate()
        {
            if (true/*_isFirstTouchTaken*/)
            {
                float directionAngel = Mathf.Rad2Deg * Mathf.Atan2(floatingJoystick.Horizontal, floatingJoystick.Vertical);

                Vector3 joystickDirection = new Vector3(floatingJoystick.Horizontal,0, floatingJoystick.Vertical);
                


                if (joystickDirection.magnitude>0)
                {
                    _isClick = false;
                }

                if (Input.GetMouseButton(0) && !_isClick)
                {
                    _hasTouch = true;
                }
                else
                {
                    _hasTouch = false;
                }

                if (_hasTouch)
                {
                    InputSignals.Instance.onInputTouch?.Invoke(directionAngel, joystickDirection);
                }
                else
                {
                    InputSignals.Instance.onInputReleased?.Invoke();
                }
            }
        }

        private void OnPlay() => StartToInput();

        private void OnReset() => StopToInput();

        private void StartToInput() => _isFirstTouchTaken = true;

        private void StopToInput() => _isFirstTouchTaken = false;


    }
}