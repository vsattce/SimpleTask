using UnityEngine;
using System.Collections;

namespace JCCode
{
    public class TaskRunner : MonoBehaviour
    {
        private TaskTime taskTime_ = new TaskTime();
        private ArrayList taskArray_ = new ArrayList();

        public static TaskRunner Create(GameObject obj)
        {
            TaskRunner runner = obj.GetComponent<TaskRunner>();
            if (runner == null)
            {
                runner = obj.AddComponent<TaskRunner>();
            }
            return runner;
        }

        public void UpdateArray(float time)
        {
            ArrayList array = new ArrayList();
            Task task;
            for (int i = 0; i < this.taskArray_.Count; i++)
            {
                task = this.taskArray_[i] as Task;
                task._taskUpdate(time);
                if (!task._taskIsOver())
                {
                    array.Add(task);
                }
                else
                {
                    task._taskStop();
                }
            }
            this.taskArray_ = array;
        }

        public void AddTask(Task task)
        {
            task._taskInit();

            this.taskArray_.Add(task);
        }

        void Update()
        {
            float deltaTime = this.taskTime_.Interval(Time.deltaTime);

            this.UpdateArray(deltaTime);
        }
    }
}