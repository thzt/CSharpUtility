using System;

namespace CSharpUtility
{
    /// <summary>
    /// this class will check a given time whether the first time fall into a time region.
    /// each time we invoke check method, the checker will validate by given time/boundary/inner variable
    /// </summary>
    public class FirstTimeFallIntoRegionChecker
    {
        /// <summary>
        /// inner flag to recognize have falled in early.
        /// </summary>
        private bool isFirstTimeFallIntoRegion = false;

        private DateTime left;
        private DateTime right;

        /// <summary>
        /// as user can config boundary, we have to support this method to modify time boundary.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void ChangeBoundary(DateTime left, DateTime right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// input: current time
        /// output: whether the first time fall into the time region.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public bool Check(DateTime current)
        {
            if (current < left)
            {
                return isFirstTimeFallIntoRegion = false;
            }

            if (current > right)
            {
                return isFirstTimeFallIntoRegion = false;
            }

            if (isFirstTimeFallIntoRegion)
            {
                return false;
            }

            return isFirstTimeFallIntoRegion = true;
        }
    }
}
