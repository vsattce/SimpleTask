using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JCCode
{
    public class TaskSet : Task 
    {
        private List<Task> taskList_ = new List<Task>();
        private int count_ = 0;

        public void Push(Task task)
        {
            this.taskList_.Add(task);
            TaskManager.AddTaskStopFunc(task, ()=>{count_++;});
        }

        public TaskSet()
        {
            this._taskInit = delegate()
            {
                count_ = 0;
                for (int i = 0; i < taskList_.Count; i++)
                {
                    Task task = this.taskList_[i] as Task;
                    TaskManager.Run(task);
                }
            };

            this._taskIsOver = delegate()
            {
                return (this.count_ == taskList_.Count);
            };
        }
    }
}