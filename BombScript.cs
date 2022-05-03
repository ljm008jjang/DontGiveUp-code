using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    protected int Range;
    public int explosivePower;
    Vector3Int gridPosition;

    public int layerMask = 1 << 8;

    public virtual void Explosive()
    {

        for (int i = -Range; i <= Range; i++)
        {
            for (int j = -Range; j <= Range; j++)
            {
                Vector3 underPosition = transform.position + new Vector3(i, j);

                float distance = Vector2.Distance(transform.position, underPosition) - 0.001f;

                if(distance <= Range)
                {
                    gridPosition = Player.Instance.map.WorldToCell(underPosition);

                    Collider2D overcollider = Physics2D.OverlapCircle(transform.position, 1, layerMask);
                    if(overcollider != null)
                    {
                        TileManager.Instance.BreakCell(gridPosition);
                    }
                }
            }
        }

        /*
        for (int i= -Range; i <= Range; i++)
        {
            for(int j=-Range; j <= Range; j++)
            {
                Vector3 underPosition = transform.position + new Vector3(i, j);

                Vector2 direction = underPosition - transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Range, layerMask);

                gridPosition = player.map.WorldToCell(underPosition);

                TileData data = player.tileManager.GetTileData(gridPosition);

                if(hit.collider != null && data != null && explosivePower >= data.health)
                {
                    player.tileManager.BreakCell(gridPosition);
                } 
            }
        }
        */

    }
}
