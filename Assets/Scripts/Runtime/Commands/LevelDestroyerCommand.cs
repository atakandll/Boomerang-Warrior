using UnityEngine;

namespace Runtime.Commands
{
    public class LevelDestroyerCommand : MonoBehaviour
    {
        public void Execute(Transform levelHolder)
        {
            Destroy(levelHolder.GetChild(0).gameObject);
        }
    }
}