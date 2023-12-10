using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction onScoreTaken = delegate { };
        public UnityAction onDeathScoreTaken = delegate { };
    }
}