using UnityEngine;
using System;

namespace MyExtension
{
    /// <summary>
    /// Vector3を拡張するクラス
    /// </summary>
    public static class Vector3Extension
    {
        /// <summary>
        /// 与えられたVector3の値の指定した少数桁より下を丸める
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Vector3 Round (this Vector3 self, int roundValue)
        {
            return new Vector3
                (
                    (float)Math.Round(self.x, roundValue, MidpointRounding.AwayFromZero),
                    (float)Math.Round(self.y, roundValue, MidpointRounding.AwayFromZero),
                    (float)Math.Round(self.z, roundValue, MidpointRounding.AwayFromZero)
                );
        }
    }
}
