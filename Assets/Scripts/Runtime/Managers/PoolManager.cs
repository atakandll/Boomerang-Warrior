using System;
using System.Collections.Generic;
using Runtime.Data.UnityObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Runtime.Managers
{
    public class PoolManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CD_PoolData CD_PoolData;
        [SerializeField] private SerializedDictionary<PoolObjectType, Queue<GameObject>> objectPool;
        [SerializeField] private GameObject poolHolder;
        


        #endregion

        #region Private Variables

        private GameObject _outGoingObject;
        private readonly int _loadPoolCount = Enum.GetNames(typeof(PoolObjectType)).Length;
        private int poolCount = 0;
        

        #endregion

        #endregion
        
        private void Awake()
        {
            objectPool = new SerializedDictionary<PoolObjectType, Queue<GameObject>>();

            for (; poolCount < _loadPoolCount; poolCount++)
            {
                objectPool.Add(CD_PoolData.ObjectData[poolCount].PoolObjectType, new Queue<GameObject>());

                for (int j = 0; j < CD_PoolData.ObjectData[poolCount].PoolCount; j++)
                {
                    var poolObj = Instantiate(CD_PoolData.ObjectData[poolCount].PoolObject, poolHolder.transform);

                    poolObj.SetActive(false);

                    objectPool[CD_PoolData.ObjectData[poolCount].PoolObjectType].Enqueue(poolObj);
                }
            }
        }


        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            PoolSignals.Instance.onGetObjectFromPool += OnGetObjcetFromPool;
            PoolSignals.Instance.onReleaseObjectFromPool += OnReleaseObjectFromPool;
        }

        private void UnsubscribeEvents()
        {
            PoolSignals.Instance.onGetObjectFromPool -= OnGetObjcetFromPool;
            PoolSignals.Instance.onReleaseObjectFromPool -= OnReleaseObjectFromPool;
        }

        private void OnDisable() => UnsubscribeEvents();


        private GameObject OnGetObjcetFromPool(PoolObjectType type)
        {
            if (objectPool[type].Count == 0 && CD_PoolData.ObjectData[(int)type].PoolType == PoolType.Dynamic)
            {
                _outGoingObject = Instantiate(CD_PoolData.ObjectData[(int)type].PoolObject, poolHolder.transform);
            }
            else
            {
                if (objectPool[type].Count != 0)
                {
                    _outGoingObject = objectPool[type].Peek();

                    _outGoingObject.SetActive(true);

                    objectPool[type].Dequeue();
                }
            }

            return _outGoingObject;
        }

        private void OnReleaseObjectFromPool(PoolObjectType type, GameObject obj)
        {
            obj.SetActive(false);

            objectPool[type].Enqueue(obj);
        }
    }
}