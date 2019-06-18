using System;
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

        protected Stack<T> MCacheStack = new Stack<T>();

        protected IObjectFactory<T> MFactory;

        public int CurCount => MCacheStack.Count;
        
        public T Allocate()
        {
            return MCacheStack.Count > 0 ? MCacheStack.Pop() : MFactory.Create();
        }

        public abstract bool Recycle(T obj);
    }

    public class CustomObjectFactory<T> : IObjectFactory<T>
    {
        private Func<T> _mFactoryMethod;

        public CustomObjectFactory(Func<T> factoryMethod)
        {
            _mFactoryMethod = factoryMethod;
        }
        
        public T Create()
        {
            return _mFactoryMethod();
        }
    }

    public class SimpleObjectPool<T> : Pool<T>
    {
        private Action<T> _mResetMethod;

        public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
        {
            MFactory = new CustomObjectFactory<T>(factoryMethod);
            _mResetMethod = resetMethod;
            for (var i = 0; i < initCount; i++)
            {
                MCacheStack.Push(MFactory.Create());
            }
        }

        public override bool Recycle(T obj)
        {
            if (_mResetMethod != null)
            {
                _mResetMethod(obj);
            }

            MCacheStack.Push(obj);
            return true;
        }
    }

}