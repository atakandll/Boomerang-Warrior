using Runtime.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction<float, Vector3> onInputTouch = delegate { };
        public UnityAction onInputReleased = delegate { };
    }
}