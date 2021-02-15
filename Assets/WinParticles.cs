using UnityEngine;

public class WinParticles : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    void Start()
    {
        InvokeRepeating("LaunchParticle", 0.5f, 1f);
    }

    void LaunchParticle()
    {
        var pos = Random.insideUnitCircle * 5;
        Instantiate(particlePrefab, pos, particlePrefab.transform.rotation, gameObject.transform);
    }
}
