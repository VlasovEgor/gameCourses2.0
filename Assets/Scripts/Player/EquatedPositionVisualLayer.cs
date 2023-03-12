using UnityEngine;

public class EquatedPositionVisualLayer : MonoBehaviour
{
    [SerializeField] private GameObject _collisonLayer;

    void Update()
    {
        transform.position = _collisonLayer.transform.position;
        transform.rotation = _collisonLayer.transform.rotation;
    }
}
