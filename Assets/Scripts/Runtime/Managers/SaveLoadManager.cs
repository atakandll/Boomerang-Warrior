using System;
using System.Collections.Generic;
using Runtime.Data.ValueObject;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    [Serializable]
    public class SaveLoadManager : MonoBehaviour
    {
        [SerializeField]
        private List<DataContainer> dataContainer;

        private const string defaultFile = "NewFile";

        private void Awake()
        {
            Load();
        }

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            SaveLoadSignals.Instance.onSave += OnSave;
        }

        private void UnsubscribeEvents()
        {
            SaveLoadSignals.Instance.onSave -= OnSave;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnSave()
        {
            UpdateSave();
        }

        private void Load()
        {
            UpdateLoad();
        }

        public void UpdateSave()
        {
            foreach (DataContainer data in dataContainer)
            {
                string _dataPath = data._key + "-" + data._id + ".es3";

                //if (ES3.FileExists(_dataPath))
                //{
                //    Debug.Log("s");

                //    ES3.DeleteFile(_dataPath);

                //}

                ES3.Save(data._key, data.scriptableObject, _dataPath);
            }
        }

        public void UpdateLoad()
        {
            foreach (DataContainer data in dataContainer)
            {
                string _dataPath = data._key + "-" + data._id + ".es3";

                if (!ES3.FileExists(_dataPath))
                {
                    ES3.Save(data._key, data.scriptableObject, _dataPath);
                }
                else
                {
                    data.scriptableObject = ES3.Load<ScriptableObject>(data._key, _dataPath);
                }
            }
        }
    }
}