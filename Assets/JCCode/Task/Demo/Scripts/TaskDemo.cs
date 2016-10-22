using UnityEngine;
using System.Collections;
using JCCode;

public class TaskDemo : MonoBehaviour 
{
    void Awake()
    {
        TaskList taskList = new TaskList();

        
        Task task1 = new Task();
        task1._taskInit = delegate()
        {
            Debug.Log("this is task1");
        };
        taskList.Push(task1);

        Task taskWait1 = new TaskWait();
        (taskWait1 as TaskWait).SetWaitTime(2.0f);
        taskList.Push(taskWait1);

        Task task2 = new Task();
        task2._taskInit = delegate()
            {
                Debug.Log("this is task2");
            };
        taskList.Push(task2);


        Task task3 = new Task();
        task3._taskInit = delegate()
            {
                Debug.Log("this is task3");
            };

        Task task4 = new Task();
        task4._taskInit = delegate()
            {
                Debug.Log("this is task4");
            };

        Task taskWait2 = new TaskWait();
        (taskWait2 as TaskWait).SetWaitTime(2.0f);

        Task taskSet = new TaskSet();
        (taskSet as TaskSet).Push(task3);
        (taskSet as TaskSet).Push(task4);
        (taskSet as TaskSet).Push(taskWait2);

        taskList.Push(taskSet);

        Task task5 = new Task();
        task5._taskInit = delegate()
            {
                Debug.Log("this is task5");
            };
        taskList.Push(task5);

        TaskManager.Run(taskList);
    }
}
