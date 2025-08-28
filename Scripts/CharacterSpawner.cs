using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Transform spawnPosA;
    public Transform spawnPosB;

    public GameObject characterA;
    public GameObject characterB;

    void Awake()
    {
        var instanceA = Instantiate(characterA, spawnPosA.position, spawnPosA.rotation);
        var instanceB = Instantiate(characterB, spawnPosB.position, spawnPosB.rotation);

        instanceB.transform.localScale = new Vector3(-1, 1, 1);

        instanceA.GetComponent<CharacterMain>().lookAtTarget = instanceB.transform;
        instanceB.GetComponent<CharacterMain>().lookAtTarget = instanceA.transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
