using UnityEngine;
using System.Collections;

namespace JCCode
{
    public class Task
    {
        public Task()
        {
        }
        public TaskInit _taskInit = delegate (){};
        public TaskStop _taskStop = delegate (){};
        public TaskUpdate _taskUpdate = delegate (float time){};
        public TaskIsOver _taskIsOver = delegate (){return true;};
    }
}
