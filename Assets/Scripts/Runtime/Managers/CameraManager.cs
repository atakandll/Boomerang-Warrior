using System;
using Cinemachine;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CameraSignals.Instance.onSpawnPlayer += OnSpawnPlayer;
        }

        private void UnsubscribeEvents()
        {
            CameraSignals.Instance.onSpawnPlayer -= OnSpawnPlayer;
            
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private float OnSpawnPlayer(GameObject player)
        {
            virtualCamera.Follow = player.transform;
            return virtualCamera.transform.rotation.eulerAngles.y;
        }
    }
}