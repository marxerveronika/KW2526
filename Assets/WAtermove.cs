using UnityEngine;

public class MiscareApa : MonoBehaviour
{
    // Aici setam viteza cu care curge apa
    public float vitezaX = 0.1f;
    public float vitezaY = 0.05f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calculeaza noua pozitie in functie de timp
        float offsetX = Time.time * vitezaX;
        float offsetY = Time.time * vitezaY;

        // Aplica miscarea pe material (pe textura)
        rend.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}