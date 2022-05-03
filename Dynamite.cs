using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : Usable
{
    
    public int explosivePower = 5;
    Vector3Int gridPosition;

    public int layerMask = 1 << 8;
    [SerializeField]
    Animator animator;
    /*
    protected override void Awake()
    {dw
        base.Awake();
        itemName = "Dynamite";
    }
    */
    public void Off()
    {
        gameObject.SetActive(false);
    }

    

    public void Explosive()
    {
        SoundManager.Instance.bombAudioSource.Play();

        for (int i = -ItemDB.Instance.Range; i <= ItemDB.Instance.Range; i++)
        {
            for (int j = -ItemDB.Instance.Range; j <= ItemDB.Instance.Range; j++)
            {
                Vector3 underPosition = transform.position + new Vector3(i, j);

                float distance = Vector2.Distance(transform.position, underPosition) - 0.001f;

                if (distance <= ItemDB.Instance.Range)
                {
                    gridPosition = Player.Instance.map.WorldToCell(underPosition);


                    Collider2D overcollider = Physics2D.OverlapCircle(underPosition, 0.01f , LayerMask.GetMask("OnlyDynamite","floor")) ;
                    Collider2D unCollider = Physics2D.OverlapCircle(underPosition, 0.01f, LayerMask.GetMask("UnMiningable"));

                    if (overcollider != null && unCollider == null)
                    {
                        TileManager.Instance.BreakAllCell(gridPosition);
                    }
                }
            }
        }

        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1);
        for (int k = 0; k < hit.Length; k++)
        {
            if (hit[k].gameObject.layer.Equals(11))
            {
                hit[k].GetComponent<Monster>().Attacked(explosivePower);
            }
            else if (hit[k].gameObject.layer.Equals(10))
            {
                Player.Instance.Attacked(explosivePower);
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
