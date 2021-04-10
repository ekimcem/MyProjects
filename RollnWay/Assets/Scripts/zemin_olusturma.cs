using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zemin_olusturma : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject son_zemin;
    public GameObject odul;


    static int olusturulan_zemin_sayisi;

    public float i = 1;
   

    void Start()
    {
        for ( int i=0;i<2; i++)
        {
            zemin_olustur();
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }





    public void zemin_olustur()


    {
        
        int x = Random.Range(0, 2);

        if (olusturulan_zemin_sayisi % 15 == 0 && i>0.6f && olusturulan_zemin_sayisi != 0)
        {
            i = i - 0.1f;
        }

        if (x == 0 )
        {
            son_zemin.transform.localScale = new Vector3(i, son_zemin.transform.localScale.y, i);

            son_zemin = Instantiate(son_zemin, son_zemin.transform.position + Vector3.left * i, son_zemin.transform.rotation);

            olusturulan_zemin_sayisi++;
        }
        else if (x != 0)
        {
            son_zemin.transform.localScale = new Vector3(i, son_zemin.transform.localScale.y,i);
            son_zemin = Instantiate(son_zemin, son_zemin.transform.position + Vector3.back * i, son_zemin.transform.rotation);

            olusturulan_zemin_sayisi++;

        }
        
        if ( olusturulan_zemin_sayisi % 20 == 0)
        {
            Instantiate(odul, son_zemin.transform.position + Vector3.up * 1.1f, odul.transform.rotation);
        }
        Debug.Log("i değeri  =  " + i + " olusturulan zemin sayısı = " + olusturulan_zemin_sayisi);
    }
}
