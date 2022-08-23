using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objAngle : MonoBehaviour
{
    //オブジェクトをターゲットへ向ける。
    //何もいじらなければプレイヤー向く
    [Header("[オブジェクトをターゲットへ向けるため]\n全方位へ回転するか")]
    [SerializeField]
    bool allangle = false;
    [Header("開始時だけ回転するか")]
    [SerializeField]
    bool startangle = false;
    [Header("回転の制限")]
    [SerializeField]
    float limitangle = -1;
    GameObject P;
    
    bool movetrg = true;
    [Header("プレイヤー用にするか")]
    [SerializeField]
    bool ptrg = false;
    [Header("向く方向のオブジェクト")]
    [SerializeField]
    GameObject[] targetobj = null;
    [Header("向く方向オブジェクトの選択")]
    [SerializeField]
    int indextarget = -1;
    [Header("向く方向オブジェクトを名前で指定")]
    [SerializeField]
    string objname;
    private Vector3 vec;
    [Header("回転速度")]
    [SerializeField]
    float RotSpeed = 2;
    private bool startTrg = false;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        if(targetobj != null && objname != "")
        {
            targetobj[0] = GameObject.Find(objname);
        }
        if (P != null && startangle)
        {
            if (indextarget == -1)
            {
                var rotation = Quaternion.LookRotation(P.transform.position - this.transform.position);

                if (!allangle)
                {
                    rotation.x = 0;
                    rotation.z = 0;
                }
                this.transform.rotation = rotation;
                //変換
                if (limitangle != -1)
                {
                    float rotateY = (this.transform.localEulerAngles.y > 180) ? this.transform.localEulerAngles.y - 360 : this.transform.localEulerAngles.y;
                    if (rotateY > limitangle)
                    {
                        Vector3 er = this.transform.localEulerAngles;
                        er.y = limitangle;
                        this.transform.localEulerAngles = er;
                    }
                    else if (rotateY < -limitangle)
                    {
                        Vector3 er = this.transform.localEulerAngles;
                        er.y = -limitangle;
                        this.transform.localEulerAngles = er;
                    }
                }
            }
            if (indextarget != -1 && targetobj != null)
            {
                var rotation = Quaternion.LookRotation(targetobj[indextarget].transform.position - this.transform.position);

                if (!allangle)
                {
                    rotation.x = 0;
                    rotation.z = 0;
                }
                this.transform.rotation = rotation;
                //変換
                if (limitangle != -1)
                {
                    float rotateY = (this.transform.localEulerAngles.y > 180) ? this.transform.localEulerAngles.y - 360 : this.transform.localEulerAngles.y;
                    if (rotateY > limitangle)
                    {
                        Vector3 er = this.transform.localEulerAngles;
                        er.y = limitangle;
                        this.transform.localEulerAngles = er;
                    }
                    else if (rotateY < -limitangle)
                    {
                        Vector3 er = this.transform.localEulerAngles;
                        er.y = -limitangle;
                        this.transform.localEulerAngles = er;
                    }
                }
            }
        }
        Invoke("startAngle", 0.1f);
    }
    void startAngle()
    {
        startTrg = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (P != null && !startangle && movetrg && !ptrg)
        {
            _Rot();
        }
        else if (P != null && !startangle && movetrg && ptrg && GManager.instance.Triggers[23] != 1)
        {
            _Rot();
        }
        if(!startTrg && startangle )
        {
            _Rot();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "area" && !movetrg)// && es != null)
        {
            // 表示されている場合の処理
            movetrg = true;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "area"&& !movetrg)// && es != null)
        {
            // 表示されている場合の処理
            movetrg = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "area" && movetrg)// && es != null)
        {
            // 表示されている場合の処理
            movetrg = false;
        }
    }

    private void _Rot()
    {
        if (indextarget == -1)
        {
            if (!allangle)
            {
                Vector3 tDir = new Vector3(P.transform.position.x, this.transform.position.y, P.transform.position.z) - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, tDir, RotSpeed * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
            else if (allangle)
            {
                Vector3 tDir = new Vector3(P.transform.position.x, P.transform.position.y, P.transform.position.z) - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, tDir, RotSpeed * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
            //var rotation = Quaternion.LookRotation(P.transform.position - this.transform.position);
            //if (allangle == false)
            //{
            //    rotation.x = 0;
            //    rotation.z = 0;
            //}
            //this.transform.rotation = rotation;
            //if (allangle == false)
            //{
            //    vec = this.transform.eulerAngles;
            //    vec.x = 0;
            //    vec.z = 0;
            //    this.transform.eulerAngles = vec;
            //}
            //変換
            if (limitangle != -1)
            {
                float rotateY = (this.transform.localEulerAngles.y > 180) ? this.transform.localEulerAngles.y - 360 : this.transform.localEulerAngles.y;
                if (rotateY > limitangle)
                {
                    Vector3 er = this.transform.localEulerAngles;
                    er.y = limitangle;
                    this.transform.localEulerAngles = er;
                }
                else if (rotateY < -limitangle)
                {
                    Vector3 er = this.transform.localEulerAngles;
                    er.y = -limitangle;
                    this.transform.localEulerAngles = er;
                }
            }
        }
        else if (indextarget != -1 && targetobj != null)
        {
            if (targetobj[indextarget] != null)
            {
                if (!allangle)
                {
                    Vector3 tDir = new Vector3(targetobj[indextarget].transform.position.x, this.transform.position.y, targetobj[indextarget].transform.position.z) - transform.position;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, tDir, RotSpeed * Time.deltaTime, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
                else if (allangle)
                {
                    Vector3 tDir = new Vector3(targetobj[indextarget].transform.position.x, targetobj[indextarget].transform.position.y, targetobj[indextarget].transform.position.z) - transform.position;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, tDir, RotSpeed * Time.deltaTime, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
                //var rotation = Quaternion.LookRotation(targetobj[indextarget].transform.position - this.transform.position);
                //if (allangle == false)
                //{
                //    rotation.x = 0;
                //    rotation.z = 0;
                //}
                //this.transform.rotation = rotation;
                //if (allangle == false)
                //{
                //    vec = this.transform.eulerAngles;
                //    vec.x = 0;
                //    vec.z = 0;
                //    this.transform.eulerAngles = vec;
                //}
                //変換
                if (limitangle != -1)
                {
                    float rotateY = (this.transform.localEulerAngles.y > 180) ? this.transform.localEulerAngles.y - 360 : this.transform.localEulerAngles.y;
                    if (rotateY > limitangle)
                    {
                        Vector3 er = this.transform.localEulerAngles;
                        er.y = limitangle;
                        this.transform.localEulerAngles = er;
                    }
                    else if (rotateY < -limitangle)
                    {
                        Vector3 er = this.transform.localEulerAngles;
                        er.y = -limitangle;
                        this.transform.localEulerAngles = er;
                    }
                }
            }
        }
    }
}
