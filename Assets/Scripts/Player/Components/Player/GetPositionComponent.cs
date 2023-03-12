using UnityEngine;

public class GetPositionComponent : MonoBehaviour, IGetPositionComponent
{
    [SerializeField] private Transform _objectTransform;

    public Vector3 GetPosition()
    {
        return _objectTransform.position;
    }
}
