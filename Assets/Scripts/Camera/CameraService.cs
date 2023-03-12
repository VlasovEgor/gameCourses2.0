using UnityEngine;

public class CameraService : MonoBehaviour
{
    [SerializeField] private new Camera _camera;
    [SerializeField] private Transform _cameraTransform;

    public Camera Camera
    {
        get { return _camera; }
    }

    public Transform CameraTransfrom
    {
        get { return _cameraTransform; }
    }
}
