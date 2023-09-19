using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChange : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] replacementSprites;

    void Start()
    {
        tilemap = TilemapHolder.Instance.tilemapSetable;

        Debug.LogError("Tilemap or replacementSprites not set." + tilemap);
        ReplaceRandomTile();
    }

    void ReplaceRandomTile()
    {
        if (tilemap == null || replacementSprites.Length == 0)
        {
            Debug.LogError("Tilemap or replacementSprites not set.");
            return;
        }

        // Calculate the position in world space based on this GameObject's position
        Vector3Int positionInTilemap = tilemap.WorldToCell(transform.position);

        // Randomly select a replacement sprite
        int randomIndex = Random.Range(0, replacementSprites.Length);
        Tile randomReplacementSprite = replacementSprites[randomIndex];

        // Replace the tile at the calculated position with the random replacement sprite
        tilemap.SetTile(positionInTilemap, randomReplacementSprite);
    }
}
