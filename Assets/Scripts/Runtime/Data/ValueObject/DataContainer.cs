using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class DataContainer
    {
        public int _id;

        public string _key;

        public ScriptableObject scriptableObject;
    }
}