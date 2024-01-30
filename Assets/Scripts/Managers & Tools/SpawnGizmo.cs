using UnityEngine;
using System.Collections;

// Sam Robichaud 
// NSCC Truro 2024

public class SpawnGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        //TODO: Update Gizmo to maybe use Solid block to make it easier to tell where the players feet will land, perhaps have the color of the arrown differnt so it stands out more...

        // Set the color of the Gizmo line
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, 1.0f);

        // Get the current position of the object
        Vector3 startPosition = transform.position;

        // Calculate the end point 1 meter forward
        Vector3 endPosition = startPosition + transform.forward * 1.5f;

        // Draw the line
        Gizmos.DrawLine(startPosition, endPosition);

        // Draw the arrowhead
        DrawArrowEnd(startPosition, endPosition);

        void DrawArrowEnd(Vector3 start, Vector3 end)
        {
            // Set the size of the arrowhead
            float arrowHeadLength = 0.25f;
            float arrowHeadAngle = 45.0f;

            // Calculate the direction from the start to the end
            Vector3 direction = (end - start).normalized;

            // Calculate the up, down, right and left lines of the arrowhead
            Vector3 up = Quaternion.LookRotation(direction) * Quaternion.Euler(180 + arrowHeadAngle, 0, 0) * new Vector3(0, 0, 1);
            Vector3 down = Quaternion.LookRotation(direction) * Quaternion.Euler(180 - arrowHeadAngle, 0, 0) * new Vector3(0, 0, 1);
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);

            // Draw the up, down right and left sides of the arrowhead
            Gizmos.DrawLine(end, end + right * arrowHeadLength);
            Gizmos.DrawLine(end, end + left * arrowHeadLength);
            Gizmos.DrawLine(end, end + up * arrowHeadLength);
            Gizmos.DrawLine(end, end + down * arrowHeadLength);
        }

    }
}

