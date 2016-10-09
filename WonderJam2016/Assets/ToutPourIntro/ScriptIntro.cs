using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptIntro : MonoBehaviour {

    private int n = 0;
    private int etape = 0;
    private int pause = 0;

    private int i = 0;
    private string[] txts = {
        "*GGRRRRRRRR* BIENVENUE EN ENFER !",
        "VOUS AVEZ VECU EN TANT QU'AVOCATS, CE QUI VOUS A POUSSE A PROTEGER DES INNOCENTS MAIS AUSSI DES CRIMINELS.",
        "VOUS ALLEZ DONC PASSER DES EPREUVES POUR SAVOIR QUI DE VOUS DEUX DEVRA TERMINER EN ENFER !",
        "CELUI QUI ME RAPPORTERA LE MOINS DE JOYAUX FINIRA AVEC MOI !",
        "ALORS PARTEZ ! COUREZ ! TRAHISSEZ-VOUS ! MAIS RAMENER MOI UN MAXIMUM D'EMERAUDES !",
        "QUE LA CHASSE COMMENCE MOUAHAHAHAHA !!!" };

    private Text txt;

	// Use this for initialization
	void Start () {
        GameObject g = GameObject.Find("diable");
        g.transform.position = new Vector2(g.transform.position.x, -6);

        g = GameObject.Find("PanelTxt");
        RectTransform rpt = g.GetComponent<RectTransform>();
        rpt.GetComponent<Image>().color = new Color(200, 200, 200, 0.0f);

        g = GameObject.Find("TxtIntro");
        txt = g.GetComponent<Text>();

        g = GameObject.Find("PanelFin");
        RectTransform rpf = g.GetComponent<RectTransform>();
        rpf.GetComponent<Image>().color = new Color(0, 0, 0, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {

        GameObject diable = GameObject.Find("diable");

        if ( pause > 0 )
        {
            pause--;
            return;
        }

        if (etape == 0)
        {
            if (n % 3 != 0)
                diable.transform.position = new Vector2(diable.transform.position.x, diable.transform.position.y + 0.10f);
            else
                diable.transform.position = new Vector2(diable.transform.position.x, diable.transform.position.y - 0.15f);
            if (diable.transform.position.y >= -1.45)
                etape++;
        }

        if (etape == 1)
        {
            GameObject obj = GameObject.Find("PanelTxt");
            RectTransform rpt = obj.GetComponent<RectTransform>();
            rpt.GetComponent<Image>().color = new Color(200, 200, 200, rpt.GetComponent<Image>().color.a + 0.005f);

            if (rpt.GetComponent<Image>().color.a >= 0.8f)
                etape++;
        }

        if ( etape >= 2 && etape < txts.Length + 2 )
        {
            if ( i == 0 )
                txt.text = "";
            if (n % 4 == 0)
            {
                char c = txts[etape-2].ToCharArray()[i];
                txt.text += c;
                i++;
                if (i >= txts[etape - 2].Length)
                {
                    pause = 100;
                    etape++;
                    i = 0;
                }
            }
        }

        if ( etape == txts.Length + 2 )
        {
            GameObject obj = GameObject.Find("PanelFin");
            RectTransform rpf = obj.GetComponent<RectTransform>();
            rpf.GetComponent<Image>().color = new Color(0, 0, 0, rpf.GetComponent<Image>().color.a + 0.005f);

            if (rpf.GetComponent<Image>().color.a >= 1.0f)
                etape++;
        }

        if (etape == txts.Length + 3)
        {
            // LIEN VERS L'AUTRE SCENE
        }

        n++;
	}
}
