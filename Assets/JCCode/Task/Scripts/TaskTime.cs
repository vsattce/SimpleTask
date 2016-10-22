using UnityEngine;
using System.Collections;

namespace JCCode
{
    public class TaskTime
    {
        const int LENGTH = 12;
        const float DELTATIME = 0.012f;

        private int num_ = 0;
        private float[] taskTime_ = new float[LENGTH];

        public TaskTime()
        {
            for (int i = 0; i < taskTime_.Length; i++)
            {
                this.taskTime_[i] = DELTATIME;
            }
        }

        public float Interval(float time)
        {
            this.taskTime_[num_] = time;
            num_++;

            if (num_ >= LENGTH)
                num_ = 0;

            float all = 0.0f;
            foreach (var t in taskTime_)
            {
                all += t;
            }
            return (all / (LENGTH * 1.0f));
        }
    }
}
