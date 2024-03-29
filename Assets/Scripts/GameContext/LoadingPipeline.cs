using Sirenix.OdinInspector;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(
       fileName = "LoadingPipeline",
       menuName = "App/AppLoading/New LoadingPipeline"
   )]
public class LoadingPipeline : ScriptableObject
{
    [SerializeField]
    [FormerlySerializedAs("taskInfos")]
    [ListDrawerSettings(OnBeginListElementGUI = "DrawLabelForTask")]
    private TaskInfo[] _tasks;

    public Type[] GetTaskList()
    {
        var count = _tasks.Length;
        var result = new Type[count];
        for (var i = 0; i < count; i++)
        {
            var taskInfo = _tasks[i];
            var task = GetTaskType(taskInfo);
            result[i] = task;
        }

        return result;
    }

    private Type GetTaskType(TaskInfo info)
    {
        var classType = Type.GetType(info.className);
        if (classType == null)
        {
            throw new Exception($"Missed class {info.className} of MonoScript {info.script.name}");
        }

        return classType;
    }

    [Serializable]
    private sealed class TaskInfo
    {
#if UNITY_EDITOR
        [SerializeField]
        public MonoScript script;
#endif
        [HideInInspector]
        [SerializeField]
        public string className;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        foreach (var info in _tasks)
        {
            if (info.script != null)
            {
                info.className = info.script.GetClass().FullName;
            }
        }
    }

    private void DrawLabelForTask(int index)
    {
        GUILayout.Space(4);
        GUILayout.Label($"Task #{index + 1}");
    }
#endif
}
