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
        [SerializeField]
        private Cd_ObjectData cdObjectDatas;//gidecek

        [SerializeField]
        private SerializedDictionary<PoolObjectType, Queue<GameObject>> objectPool;

        [SerializeField]
        private GameObject poolholder;

        private GameObject _outGoingObject;

        private readonly int _loadPoolCount = Enum.GetNames(typeof(PoolObjectType)).Length;

        private int poolCount = 0;

        private void Awake()
        {
            objectPool = new SerializedDictionary<PoolObjectType, Queue<GameObject>>();

            for (; poolCount < _loadPoolCount; poolCount++)
            {
                objectPool.Add(cdObjectDatas.ObjectData[poolCount].poolObjectType, new Queue<GameObject>());

                for (int j = 0; j < cdObjectDatas.ObjectData[poolCount].PoolCount; j++)
                {
                    var poolObj = Instantiate(cdObjectDatas.ObjectData[poolCount].PoolObject, poolholder.transform);

                    poolObj.SetActive(false);

                    objectPool[cdObjectDatas.ObjectData[poolCount].poolObjectType].Enqueue(poolObj);
                }
            }
        }

        #region EventSubscribtion

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

        #endregion EventSubscribtion

        private GameObject OnGetObjcetFromPool(PoolObjectType type)
        {
            if (objectPool[type].Count == 0 && cdObjectDatas.ObjectData[(int)type].poolType == PoolType.Dynamic)
            {
                _outGoingObject = Instantiate(cdObjectDatas.ObjectData[(int)type].PoolObject, poolholder.transform);
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