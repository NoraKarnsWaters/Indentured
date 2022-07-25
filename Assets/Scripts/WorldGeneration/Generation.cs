using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{

    [SerializeField] 
    private int Width;

    [SerializeField]
    private int Height;

    [SerializeField]
    private List<GameObject> tiles;
    

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Generate()
    {
        int pos = -(Width / 2);

        for (int x = 0; x < Width; x++)
        {
            for(int y = 0; y > -Height; y--)
            {
                if (y == 0)
                    SpawnObj(tiles[0], x + pos, 0);

                else if (y > -(Height / 2))
                    SpawnObj(tiles[1], x + pos, y);

                else
                    SpawnObj(tiles[2], x + pos, y);
            }
        }
    }

    void SpawnObj(GameObject obj, int x, int y)
    {
        Instantiate(obj, new Vector2(x, y), Quaternion.identity);
    }
}
