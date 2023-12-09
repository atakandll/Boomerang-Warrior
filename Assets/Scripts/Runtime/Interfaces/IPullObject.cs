using Runtime.Enums.ObjectPooling;
using UnityEngine;

namespace Runtime.Interfaces
{
    public interface IPullObject
    {
        GameObject PullFromPool(PoolObjectType poolObjectType);

    }
}