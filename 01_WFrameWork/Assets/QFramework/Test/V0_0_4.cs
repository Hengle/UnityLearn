#if UNITY_EDITOR
using NUnit.Framework;

namespace QFramework
{
    public class V0_0_4
    {
        class MonoSingletonTestClass : MonoSingleton<MonoSingletonTestClass>
        {

        }

        [Test]
        public void MonoSingeltonTest()
        {
            var instanceA = MonoSingletonTestClass.Instance;
            var instanceB = MonoSingletonTestClass.Instance;

            Assert.AreEqual(instanceA.GetHashCode(), instanceB.GetHashCode());
            Assert.AreEqual(instanceA.name, "MonoSingletonTestClass");
        }
    }
}
#endif