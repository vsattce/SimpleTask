using UnityEngine;
using System.Collections;

namespace JCCode
{
    public delegate void TaskInit();
    public delegate void TaskStop();
    public delegate void TaskUpdate(float time);
    public delegate bool TaskIsOver();

}