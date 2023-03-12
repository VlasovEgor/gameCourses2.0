using UnityEngine;
using UnityEngine.UIElements;

public class ConveyorWidget : MonoBehaviour
{
    [SerializeField]
    private GameObject root;

    [SerializeField]
    private ProgressBar progressBar;

    public void SetProgress(float progress)
    {
       // progressBar.SetProgress(progress);
    }

    public void SetVisible(bool isVisible)
    {
       // root.SetActive(isVisible);
    }

}
