using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform _progressBarTransform;

    public void SetProgress(float progress)
    {
        float xScale = progress;
        _progressBarTransform.localScale = new Vector3(xScale, 1, 1);
    }
}
