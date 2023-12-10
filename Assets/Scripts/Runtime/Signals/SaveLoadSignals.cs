using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class SaveLoadSignals : MonoSingleton<SaveLoadSignals>
    {
        public UnityAction onSave = delegate { };

        public UnityAction onLoad = delegate { };
    }
}