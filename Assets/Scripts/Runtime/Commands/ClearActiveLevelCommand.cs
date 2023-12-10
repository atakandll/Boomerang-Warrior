using UnityEngine;

namespace Runtime.Commands
{
    public class ClearActiveLevelCommand : MonoBehaviour
    {
        public void ClearActiveLevel(Transform levelHolder)
        {
            Destroy(levelHolder.GetChild(0).gameObject);
        }
    }
}