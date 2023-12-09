using UnityEngine;

namespace Runtime.Commands
{
    public class LevelLoaderCommand : MonoBehaviour
    {
        public void Execute(int levelID, Transform levelHolder)
        {
            Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/Level {levelID}"), levelHolder);
        }
    }
}