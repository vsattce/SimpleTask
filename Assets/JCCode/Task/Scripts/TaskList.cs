using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JCCode
{
    public class TaskList:Task
    {
        private Task begin_ = null;
        private Task end_ = null;
        private List<Task> taskList_ = new List<Task>();

        private bool isOver_ = false;
        private bool isCompleted_ = false;

        public TaskList()
        {
            this._taskInit = Initialize;
            this._taskIsOver = IsOver;
        }

        public void Push(Task task)
        {
            if (this.isCompleted_)
                Debug.LogError("this task is completed...");

            if (this.begin_ == null && this.end_ == null)
            {
                this.begin_ = task;
                this.end_ = task;
            }
            else
            {
                Task end = this.end_;
                TaskStop stop = end._taskStop;
                end._taskStop = delegate ()
                {
                    stop();
                    TaskManager.Run(task);
                };
                taskList_.Add(task);
                this.end_ = task;
            }
        }

        void Initialize()
        {
            if (this.begin_ != null)
            {
                this.isOver_ = false;
                TaskManager.Run(begin_);
            }
            else
            {
                this.isOver_ = true;
            }
        }

        bool IsOver()
        {
            return this.isOver_;
        }
    }
}