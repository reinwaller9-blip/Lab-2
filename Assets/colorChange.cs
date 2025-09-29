using UnityEngine;

public class colorChange : MonoBehaviour
{
    public void Press()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            // Create a random color
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // Assign it to the material
            rend.material.color = randomColor;
        }
        else
        {
            Debug.LogWarning("No Renderer component found on this GameObject.");
        }
    }
}
