using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePosition : MonoBehaviour {

    #region gaze

    private float _gazeTimer = 0f;
    private GameObject loadUILeft;
    private GameObject loadUIRight;
    private bool _isGazed = false;
    private float loadCircle;
    private float _gazeDelay = 3f;

    void Update()
    {
        if (_isGazed)
        {

            _gazeTimer += Time.deltaTime;

            loadCircle = _gazeTimer / _gazeDelay;
            loadUILeft.GetComponent<Image>().fillAmount = loadCircle;
            //loadUIRight.GetComponent<Image>().fillAmount = loadCircle;

        }
        else
        {
            _gazeTimer = 0f;
        }

        if (_gazeTimer >= _gazeDelay)
        {
            ChangePos(position);
        }
    }

    public void Gazing()
    {
        _isGazed = true;
    }

    public void NotGazing()
    {
        loadUILeft.GetComponent<Image>().fillAmount = 0f;
        //loadUIRight.GetComponent<Image>().fillAmount = 0f;
        _isGazed = false;
    }

    #endregion

    public CubeControl.Position position;
    CubeControl cc;

    void Start()
    {
        loadUILeft = GameObject.Find("LoaderLeft"); // gaze
        cc = GameObject.Find("Cubes").GetComponent<CubeControl>();
    }

	void ChangePos(CubeControl.Position pos)
    {
        cc.SetPos(pos);
    }
}
