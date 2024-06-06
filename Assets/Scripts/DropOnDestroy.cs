using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance =1f;

    bool isQuitting = false;

    public AudioClip BoxDestroySound;
    MusicManager musicManager;


    private void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    private void OnApplicationQuit()
    {
        isQuitting= true;
    }

    public void CheckDrop()
    {
        musicManager.Play(BoxDestroySound);
        if (isQuitting) { return; }

        if (Random.value < chance)
        { 
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];
            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }
    }


}
