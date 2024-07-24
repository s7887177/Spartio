using UnityEngine;

public class ColliderDebugger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On Collider Entered.");
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("On Trigger Entered.");
    }
}