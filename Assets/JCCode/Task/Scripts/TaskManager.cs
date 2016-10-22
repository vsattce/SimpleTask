using UnityEngine;
using System.Collections;

namespace JCCode
{
    public class TaskManager : MonoBehaviour 
    {
        private static TaskManager instance_;
        private static TaskManager _instance
        {
            get
            {
                if(instance_ == null)
                {
                    instance_ = new GameObject("TaskManager").AddComponent<TaskManager>();
                }
                return instance_;
            }
        }

        private TaskRunner taskRunner_;

        #region Function
        public static void AddTaskStopFunc(Task task, TaskStop func)
        {
            TaskStop stop = task._taskStop;
            task._taskStop = delegate()
            {
                stop();
                func();
            };
        }

        public static void Run(Task task)
        {
            TaskManager.GetInstance().GetTaskRunner().AddTask(task);
        }

        public TaskRunner GetTaskRunner()
        {
            return taskRunner_;
        }

        public static TaskManager GetInstance()
        {
            return TaskManager._instance;
        }
        #endregion

        #region System
        void Awake()
        {
            if (taskRunner_ == null)
            {
                taskRunner_ = this.gameObject.GetComponent<TaskRunner>();
            }
            if (taskRunner_ == null)
            {
                taskRunner_ = this.gameObject.AddComponent<TaskRunner>();
            }
        }
        #endregion
    }
}
