using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public interface IPool<T>
    {
        T Allocate();
        bool Recycle(T obj);
    }

    public interface IObjectFactory<T>
    {
        T Create();
    }

    public abstract class Pool<T> : IPool<T>
    {
        public T Allocate()
        {
            throw new System.NotImplementedException();
        }

        public bool Recycle(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
}