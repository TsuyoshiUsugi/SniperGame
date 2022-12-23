using UnityEngine;
using System;

namespace MyExtension
{
    /// <summary>
    /// Vector3���g������N���X
    /// </summary>
    public static class Vector3Extension
    {
        /// <summary>
        /// �^����ꂽVector3�̒l�̎w�肵����������艺���ۂ߂�
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
