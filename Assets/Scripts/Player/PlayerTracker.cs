using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _target;
     
    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, transform.position.z);
    }
}