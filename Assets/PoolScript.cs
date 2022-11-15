using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    private GameObject[] aimlist;
    int count = 0;


    public static Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        aimlist = new GameObject[2];
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        count += 1;
        


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("cliked");
        if (aimlist[0] !=null)
        {
            Destroy(aimlist[0]);
        }
        aimlist[count - 1] = Instantiate(aim, mousePos, Quaternion.identity);

        if (aimlist[1] != null)
        {
           
            Destroy(aimlist[0]);
            MoveToFirst();
            count = 0;

        }
    
    }





    void MoveToFirst()
    {
        aimlist[0] = aimlist[1];
        aimlist[1] = null;
    }
}
