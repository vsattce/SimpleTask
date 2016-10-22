using UnityEngine;
using System.Collections;

namespace JCCode
{
    public class TaskWait : Task
    {
        private float waitTime_ = 0.0f;
        private float waitTimer_ = 0.0f;

        public TaskWait()
        {
            this._taskInit = Initialize;
            this._taskUpdate = Update;
            this._taskIsOver = IsOver;
        }

        public static Task Create(float time)
        {
            TaskWait task = new TaskWait();
            task.SetWaitTime(time);
            return task;
        }

        public void SetWaitTime(float wait)
        {
            waitTime_ = wait;
        }

        void Initialize()
        {
            waitTimer_ = 0.0f;
        }

        void Update(float d)
        {
            waitTimer_ += d;
        }

        public bool IsOver()
        {
            if (waitTimer_ > waitTime_)
                return true;

            return false;
        }
    }
}
