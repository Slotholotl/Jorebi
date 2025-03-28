using UnityEngine;

public class GetPickup : MonoBehaviour
{
    private MeshRenderer r;
    private AudioSource source;
    private ParticleSystem ps;
    private KeepScore scoreScript;

    void Start()
    {
        // Haal de Renderer, AudioSource en ParticleSystem op
        r = GetComponentInChildren<MeshRenderer>();
        Debug.Log(r);
        source = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();

        // Zoek het KeepScore script
        scoreScript = FindAnyObjectByType<KeepScore>();

        // Zet het particle systeem uit bij start
        ps.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check of de speler de pickup raakt
        {
            r.enabled = false; // Verberg de pickup direct
            ps.Play(); // Speel het particle effect af
            source.Play(); // Speel het geluid af

            // Voeg 5 punten toe aan de score
            scoreScript.AddScore(1);

            // Verwijder de pickup na 2 seconden
            Destroy(gameObject, 1f);
        }
    }
}
