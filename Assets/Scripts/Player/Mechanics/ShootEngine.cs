using UnityEngine;

public class ShootEngine : MonoBehaviour
{
    [SerializeField] private Transform _placeShot;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private IntBehaviour _bulletSpeed;

    public void Shoot()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _placeShot.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * _bulletSpeed.Value, ForceMode.Impulse);
    }
}
