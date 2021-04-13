using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    // Reference to the player gameobject
    public GameObject player;

    // Reference to the pupil gameobject which will be a child of the eye gameobject
    public GameObject pupil;

    // References to sprite renderers to change alpha values to make the eyes 'fade' with distance
    public SpriteRenderer m_sr;
    public SpriteRenderer p_sr;

    // Min and max positions for the pupil to move relative to parent gameobject
    public Vector3 minpos;
    public Vector3 maxpos;

    // Color values global so new ones doesnt have to be made every frame in fixedupdate
    private Color eyeColor;
    private Color pupilColor;

    // Max distance from the player to the eye that the eye will be visible
    private float maxEyeDistance = 3.0f;

    // This is the axis pointing outward from the eye
    Vector3 m_Axis;

    void Start()
    {
        // Set the correct outward axis
        m_Axis = transform.forward * -1;

        // set default color values for eye and pupil
        eyeColor = m_sr.color;
        pupilColor = p_sr.color;
    }

    private void FixedUpdate()
    {
        // Find vector from eye to player
        Vector3 d = player.transform.position - transform.position;

        // Use linear interpolation to create a value between 0 and 1 based on distance
        float eyeVisibility = Mathf.Lerp(1, 0, Mathf.Clamp((d.magnitude - .5f) / (maxEyeDistance - .5f), 0 ,1));

        // Update the alpha color value of the eye based on the distance
        eyeColor.a = eyeVisibility;
        pupilColor.a = eyeVisibility;

        // Assign new color value to sprite renderer
        m_sr.color = eyeColor;
        p_sr.color = pupilColor;

        // set the y value to 0 because it is not needed for angle calculation
        d.y = 0;

        // Normalize the vector because we care about direction, not magnitude
        d.Normalize();

        // Use dot product and trig to find angle between the outward axis of the eye and the player
        float adj = Vector3.Dot(d, m_Axis);
        Vector3 temp = (m_Axis * adj) - d;
        float opp = Vector3.Dot(Vector3.one, temp);
        float ang = Mathf.Rad2Deg * Mathf.Atan(opp / adj);

        // Use cross product to make sure the angle is oriented the correct way since the eyes can be rotated
        if (Vector3.Cross(m_Axis, d).y <= 0)
        {
            if (ang <= 0)
            {
                ang = -ang;
            }
        }
        else
        {
            if (ang >= 0)
            {
                ang = -ang;
            }
        }

        // Use linear interpolation to find the correct position of the pupil
        Vector3 pos = Vector3.Lerp(minpos, maxpos, (ang + 45) / 90);

        // Update the position of the pupil to make the eye 'look' at the player
        pupil.transform.localPosition = pos;
    }
}