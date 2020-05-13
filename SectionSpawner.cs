using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public GameObject[] sections;
    public GameObject[] rewardSections;


    public float spawnRate;
    private float nextSpawn;
    public bool isTestMode = false;
    public int sectionNumber;
    private int currentSectionNumber = -1;
    private int nextSectionNumber;
    private int changeMultiplier = 0;


    [SerializeField] private int rewardSpawnWeight = 0;
    [SerializeField] private int sectionsBetweenReward;
    private int sectionsUntilReward = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sections[0],new Vector3(130,0,1),Quaternion.identity);
        Instantiate(sections[0],new Vector3(200,0,1),Quaternion.identity);
        
        nextSpawn = spawnRate;
        sectionsUntilReward = sectionsBetweenReward;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextSpawn>0){
            nextSpawn -= Time.deltaTime;
        }
        else{
            if(!isTestMode){
                if(sectionsUntilReward <= 0){
                    if(Random.Range(rewardSpawnWeight,100)>80){
                        Debug.Log(rewardSpawnWeight);
                        SpawnRewardSection();
                        
                    }
                    else{
                        SpawnNormalSection();
                        rewardSpawnWeight += 20;
                        Debug.Log(rewardSpawnWeight);
                    }    
                }
                else{
                    SpawnNormalSection();
                    Debug.Log(sectionsUntilReward);
                }   
            }   
            else
                Instantiate(sections[sectionNumber],new Vector3(200,0,1),Quaternion.identity);
            nextSpawn = spawnRate;
        }
    }

    private void SpawnNormalSection(){
        while(true){
            nextSectionNumber = Random.Range(1,sections.Length);
            if(nextSectionNumber != currentSectionNumber)
                break;
        }
        currentSectionNumber = nextSectionNumber;
        Instantiate(sections[nextSectionNumber],new Vector3(200,0,1),Quaternion.identity);
        sectionsUntilReward--;
    }

    private void SpawnRewardSection(){
        Instantiate(rewardSections[Random.Range(0,rewardSections.Length)],new Vector3(200,0,1),Quaternion.identity);
        sectionsUntilReward = sectionsBetweenReward;
        rewardSpawnWeight = 0;
    }
}
