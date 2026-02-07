using UnityEngine;
using UnityEngine.UI; // Avem nevoie de asta pentru UI

public class StoryController1 : MonoBehaviour
{
    [Header("Trage obiectele tale aici exact dupa nume:")]
    public GameObject InteractButton;   // Trage aici obiectul "InteractButton"
    public GameObject EnterWorld;       // Trage aici obiectul "EnterWorld"

    public GameObject Text1;            // Trage aici obiectul "Text1"
    public GameObject Text2;            // Trage aici obiectul "Text2"
    public GameObject Text3;            // Trage aici obiectul "Text3"

    public AudioSource AudioSource;     // Trage aici obiectul "Audio Source"

    // Variabile interne
    private int stadiu = 0;
    private bool aInceput = false;

    void Start()
    {
        // 1. Pregatim scena: Ascundem tot ce nu trebuie sa se vada la inceput
        if (InteractButton != null) InteractButton.SetActive(true);
        if (EnterWorld != null) EnterWorld.SetActive(false);

        if (Text1 != null) Text1.SetActive(false);
        if (Text2 != null) Text2.SetActive(false);
        if (Text3 != null) Text3.SetActive(false);

        // Ne asiguram ca muzica nu porneste singura
        if (AudioSource != null) AudioSource.Stop();
    }

    void Update()
    {
        // Ascultam click-urile DOAR daca a inceput povestea (am apasat Interact)
        if (aInceput == true)
        {
            if (Input.GetMouseButtonDown(0)) // Click Stanga
            {
                Avanceaza();
            }
        }
    }

    // Functia asta o legam de butonul INTERACT
    public void StartPoveste()
    {
        aInceput = true;

        // Ascundem butonul de start
        InteractButton.SetActive(false);

        // Pornim muzica
        if (AudioSource != null) AudioSource.Play();

        // Afisam primul text
        Text1.SetActive(true);
        stadiu = 1;
    }

    void Avanceaza()
    {
        if (stadiu == 1)
        {
            // Trecem la Text 2
            Text1.SetActive(false);
            Text2.SetActive(true);
            stadiu = 2;
        }
        else if (stadiu == 2)
        {
            // Trecem la Text 3
            Text2.SetActive(false);
            Text3.SetActive(true);
            stadiu = 3;
        }
        else if (stadiu == 3)
        {
            // Final: Apare butonul EnterWorld
            Text3.SetActive(false);
            EnterWorld.SetActive(true);

            // Oprim click-urile
            aInceput = false;
        }
    }
}