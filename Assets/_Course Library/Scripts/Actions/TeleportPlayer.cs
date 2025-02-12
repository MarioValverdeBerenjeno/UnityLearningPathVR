using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // ✅ Importa correctamente las clases

/// <summary>
/// Manually teleport the player to a specific anchor
/// </summary>
public class TeleportPlayer : MonoBehaviour
{
    [Tooltip("The anchor the player is teleported to")]
    public TeleportationAnchor anchor = null;  // ✅ Ya no usa Locomotion.

    [Tooltip("The provider used to request the teleportation")]
    public TeleportationProvider provider = null;  // ✅ Ya no usa Locomotion.

    public void Teleport()
    {
        if (anchor && provider)
        {
            TeleportRequest request = CreateRequest();  // ✅ Ya no usa Locomotion.
            provider.QueueTeleportRequest(request);
        }
    }

    private TeleportRequest CreateRequest()
    {
        Transform anchorTransform = anchor.teleportAnchorTransform;

        TeleportRequest request = new TeleportRequest()  // ✅ Ya no usa Locomotion.
        {
            requestTime = Time.time,
            matchOrientation = anchor.matchOrientation,

            destinationPosition = anchorTransform.position,
            destinationRotation = anchorTransform.rotation
        };

        return request;
    }
}