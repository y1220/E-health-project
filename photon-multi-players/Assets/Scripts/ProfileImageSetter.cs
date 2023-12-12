using UnityEngine;
using UnityEngine.UI;

public class ProfileImageSetter : MonoBehaviour
{
    public Sprite esterSprite;
    public Sprite hardirSprite;

    // Example function to set the sprite based on user role
    public void SetSpriteBasedOnRole(string userRole)
    {
        Image spriteRenderer = GetComponent<Image>();


        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on GameObject.");
            return;
        }
        else
        {
            Debug.Log("Ester Sprite Name: " + esterSprite.name);
            Debug.Log("Ester Sprite: " + esterSprite);

            Debug.Log("Hardir Sprite Name: " + hardirSprite.name);
            Debug.Log("Hardir Sprite Name: " + hardirSprite);

        }

        switch (userRole.ToLower())
        {
            case "ester":
                spriteRenderer.sprite = esterSprite;
                break;
            case "hardir":
                spriteRenderer.sprite = hardirSprite;
                break;
            default:
                Debug.LogWarning($"Unknown user role: {userRole}");
                break;
        }
    }
}
