using Runtime.Enums.UI;
using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanelTypes> onOpenPanel = delegate { };

        public UnityAction<UIPanelTypes> onClosePanel = delegate { };

        public UnityAction<int> onPrintLastGoldScore = delegate { };

        public UnityAction<float> onHealthDecrase = delegate { };

        internal UnityAction<int> onPrintLastDeathScore = delegate { };
    }
}