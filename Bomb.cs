using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Usable
  //BombScript
{

    float Range = 1;
    public int explosivePower = 5;
    Vector3Int gridPosition;

    public int layerMask = 1 << 8;
    [SerializeField]
    Animator animator;
    /*
    protected override void Awake()
    {
        base.Awake();
        itemName = "Bomb";
        price = 50;
    }
    */
    
    public void Off()
    {
        gameObject.SetActive(false);
    }

    public void Explosive()
    {
        SoundManager.Instance.bombAudioSource.Play();

        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, Range);

        if(hit != null)
        {
            for(int i = 0; i < hit.Length; i++)
            {
                if (hit[i].gameObject.layer.Equals(11))
                {
                    hit[i].GetComponent<Monster>().Attacked(explosivePower);
                }else if (hit[i].gameObject.layer.Equals(10))
                {
                    Player.Instance.Attacked(explosivePower);
                }
            }
        }

        /*
        for (int i = -Range; i <= Range; i++)
        {
            for (int j = -Range; j <= Range; j++)
            {
                Vector3 underPosition = transform.position + new Vector3(i, j);

                float distance = Vector2.Distance(transform.position, underPosition) - 0.001f;

                if (distance <= Range)
                {
                    gridPosition = Player.Instance.map.WorldToCell(underPosition);

                    Collider2D overcollider = Physics2D.OverlapCircle(transform.position, 1, layerMask);
                    if (overcollider != null)
                    {
                        Player.Instance.tileManager.BreakCell(gridPosition);
                    }
                }
            }
        }
        */
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


        animator.SetTrigger("Explosion");
        
    }
    /*
    private void Start()
    {
        Range = 1;
        explosivePower = 5;
        layerMask = base.layerMask;
    }

   public override void Explosive()
   {

        base.Explosive();
   }
    */
}
