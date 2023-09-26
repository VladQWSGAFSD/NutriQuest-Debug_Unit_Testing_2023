using UnityEngine;

/// <summary>
/// Collects the different collectibles the player encounters.
/// </summary>
public class PlayerCollector : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] public float _detectorLength;


    private RaycastHit _hit;

    private void FixedUpdate()
    {
        ActiveCollect();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * _detectorLength);
    }

    private void ActiveCollect()
    {
        // Check if the player is colliding with a collectible
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _detectorLength))
        {
            Debug.Log($"Raycast hit object: {_hit.collider.gameObject.name}");

            // Check if the collectible implements the ICollect interface
            if (_hit.collider.TryGetComponent(out ICollect collectible))
            {
                Debug.Log("Collectible found and collected.");

                // Collect the collectible
                collectible.Collect();
            }
            else
            {
                Debug.Log("Object hit is not collectible.");
            }
        }
        else
        {
            //Debug.Log("No object hit by raycast.");
        }
    }
    public void ActiveCollectActivated()
    {
        ActiveCollect();
    }
}
