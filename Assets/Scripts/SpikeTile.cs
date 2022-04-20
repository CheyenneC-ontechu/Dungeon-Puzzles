using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Spike Tile", menuName = "Tiles/SpikeTile")]
public class SpikeTile : Tile
{
    public Sprite Up;
    public Sprite Down;
    public bool isUp;

    private void StartUp(){
        Debug.Log(base.sprite);
    }
    private void RefreshTile(Vector3Int position, ITilemap tilemap){
        
    }
}
