using UnityEngine;

namespace WFramework
{

	public enum EnviromentMode
	{
		Developing,
		Test,
		Production,
	}

	public abstract class MainManager : MonoBehaviour
	{
		public EnviromentMode Mode;
		
		private static EnviromentMode _mSharedMode;
		private static bool _mModeSetted = false;


		void Start()
		{
			if (!_mModeSetted)
			{
				_mSharedMode = Mode;
				_mModeSetted = true;
			}

			switch (_mSharedMode)
			{
				case EnviromentMode.Developing:
					LauchInDevelopingMode();
					break;
				case EnviromentMode.Test:
					LaunchInTestMode();
					break;
				case EnviromentMode.Production:
					LaunchInProductionMode();
					break;
			}
		}

		protected abstract void LauchInDevelopingMode();
		protected abstract void LaunchInTestMode();
		protected abstract void LaunchInProductionMode();
	}
}
