﻿using UnityEngine;

namespace WFrameWork
{
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
    }
}