using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    [Header("[ゲームマネージャー]\nーーーーーーーーーー\n-この部分はゲーム特有のやつです。-\n時間制限")]
    public float runTimer = 0;
    [Header("ゲームスコア")]
    public int gameScore = 0;
    [Header("ーーーーーーーーーー\n室内など識別するための")]
    public int houseTrg = 0; //室内など識別するための
    [Header("動ける状態か")]
    public bool walktrg = false; //動ける状態か
    [Header("所持金")]
    public int Coin = 0; //所持金
    [Header("ボス戦かどうか")]
    public int bossbattletrg = 0; //ボス戦時かどうか
    [Header("強制Esc")]
    public bool ESCtrg = false; //Escを押してるかどうか、または強制的にEscさせるための
    [Header("ゲームオーバーかどうか")]
    public bool over = false; //ゲームオーバーかどうか
    [Header("UIの状態")]
    public int setmenu = 0; //UIの表示状態、0はUIが無い時を示す
    [Header("文章の一時格納場所")]
    public string txtget; //様々なとこから一時的に格納する文章
    [Header("各イベント状態")]
    public int[] EventNumber; //各イベント状態、0はそのイベントが進行していないことを示す
    [Header("自由なfloat型の各変数")]
    public float[] freenums; //各々のスクリプトが使う、一時的な数値
    [Header("一時的な変数、あまり気にしないで大丈夫")]
    public bool pushtrg = false; //一時的な変数

    //プレイヤーの現在位置を格納、セーブする用。再開時に使用
    [Header("プレイヤーの位置情報をセーブするため")]
    public float posX = 0; 
    public float posY = 0;
    public float posZ = 0;
    [Header("サウンドマネージャーの指定用")]
    public int setrg = -1;
    [Header("現在のステージ状態")]
    public int stageNumber = 1; //現在のステージID
    //設定
    [Header("音量設定")]
    public float audioMax = 0.16f; //音量設定に使用
    [Header("難易度設定")]
    public int mode = 1; //難易度設定に使用
    [Header("言語設定")]
    public int isEnglish = 0; //言語設定に使用
    [Header("感度設定")]
    public float kando = 1; //感度設定に使用
    [Header("画面効果、軽量化設定")]
    public int reduction = 0; //画面効果設定に使用
    [Header("自動移動設定")]
    public int autolongdash = 1; //自動ダッシュ設定に使用
    [Header("回転速度設定")]
    public float rotpivot = 5; //回転速度設定に使用

    [Header("今は気にするな")]
    public bool subgameTrg = false; //ミニゲーム時かどうか
    public int subcharaTrg = 0; //ミニゲーム時のキャラについて

    [Header("自動攻撃設定")]
    public int autoattack = 0; //攻撃時に標的を自動で定めるかどうかの設定

    [System.Serializable]
    public struct item
    {
        
        public string itemname;
        [Multiline]
        public string itemscript;
        public Sprite itemimage;
        public int eventnumber;
        public int itemprice;
        public int itemnumber;
        public GameObject itemobj;
        public string itemname2;
        [Multiline]
        public string itemscript2;
        public int gettrg;
        public string rare;
        public int _equalsset;
        public int pl_equalsselect;
        public int _quickset;
    }
    [Header("アイテム情報")]
    public item[] ItemID;

    [System.Serializable]
    public struct _Equals
    {
        
        public int hand_equals;
        public int accessory_equals;
    }
    [Header("装備情報")]
    public _Equals[] P_equalsID;

    [Header("アイテムスロットの状態")]
    public int[] Quick_itemSet;//アイテムスロットの状態
    [Header("選択中アイテムスロット")]
    public int _quickSelect = -1;//現在選択してるアイテムスロット
    //------------------------------


    [System.Serializable]
    public struct magic
    {
      
        public string magicname;
        [Multiline]
        public string magicscript;
        public Sprite magicimage;
        public int magicprice;
        public GameObject itemobj;
        public GameObject magicobj;
        public string gunmode;
        public float shotmaxtime;
        public int inputmagicpower;
        public string magicname2;
        [Multiline]
        public string magicscript2;
        public int inputeventnumber;
        public string attacktype;
        public string attacktype2;
    }
    [Header("魔法情報")]
    public magic[] MagicID;
    [Header("選択中アイテム")]
    public int itemselect; //現在選択しているアイテム
    [System.Serializable]
    public struct player
    {
        
        public Sprite pimage;
        public string pname;
        public string pname2;
        [Multiline]
        public string pscript;
        [Multiline]
        public string pscript2;
        public int maxHP;
        public int hp;
        public int maxMP;
        public int mp;
        public float speed;
        public int defense;
        public int attack;
        public int Lv;
        public int maxExp;
        public int inputExp;
        public int[] inputskill;//秘伝用にセーブ
        public int selectskill;
        [System.Serializable]
        public struct pmagic
        {
            public int magicid;
            public int gettrg;
            public int inputlevel;
        }
        public pmagic[] getMagic;
        public int magicselect;
        public int[] magicSet;
        public string badtype;
        public string badtype2;
        public string attacktype;
        public string attacktype2;
        public GameObject pobj;
        public float loadtime;
        public float maxload;
        public int changemode;
        public int getpl;
        public int slskillID;
    }
    [Header("プレイヤー情報")]
    public player[] Pstatus;

    [System.Serializable]
    public struct clonep
    {
        //初期ステータス比較用、各プレイヤー情報
        public int maxHP;
        public int hp;
        public int maxMP;
        public int mp;
        public float speed;
        public int defense;
        public int attack;
        public int Lv;
        public int maxExp;
        public int inputExp;
    }
    //new
    [Header("気にするな")]
    public clonep[] Pclone;
    //new
    [Header("選択中プレイヤー")]
    public int playerselect; //現在操作しているプレイヤー(スライム)
    [System.Serializable]
    public struct skill
    {
        //各スキル情報
        public string skillname;
        public string skillname2;
        [Multiline]
        public string skillscript;
        [Multiline]
        public string skillscript2;
        public int skillmaxbar;
        public Sprite skillicon;
        public GameObject skillitem;
        public bool notrg;
        public GameObject inputskillobj;
    }
    [Header("スキル情報")]
    public skill[] SkillID;
    [Header("選択中スキル")]
    public int skillselect; //現在選択しているスキル
    //現在は廃止した機能
    [Header("気にしないで大丈夫")]
    public string skillsay; 
    public bool Sgetsay;

    [Header("各エフェクト格納場所")]
    public GameObject[] effectobj; //汎用的なエフェクトを格納
    [Header("一時的なアニメーション用変数")]
    public int animmode = -1; //一時的な、アニメーションを再生するための変数
    [Header("各トリガー")]
    public int[] Triggers; //各トリガーの状態。イベントとは違い、この宝箱は一度取ってあるのか、この敵は討伐した奴かどうかなどを格納
    [Header("シーンのサブ名用")]
    public string SceneText; //一時的なステージ名を指定する用
    [Header("一時的なUI格納場所")]
    public GameObject spawnUI; //表示させるUIを、会話イベントスクリプト等から一時的に格納
    [Header("気にしないで大丈夫")]
    public int skillnumber = -1; //現在は廃止した機能
    [Header("一時的な効果音格納場所")]
    public AudioClip ase; //一時的な効果音を格納する用
    [Header("会話イベントで一時的に使用")]
    public string sayobjname; //会話イベントで一時的に使用

    [Header("切り替えモード(UI)")]
    public string wheelMode = "Magic"; //切り替えモード(魔法、スキル、アイテムスロットのいずれか)の状態
    [System.Serializable]
    public struct mission
    {
        //各ミッション情報
        [Multiline]
        public string name;
        [Multiline]
        public string name2;
        [Multiline]
        public string script;
        [Multiline]
        public string script2;
        public bool subtrg;
        public int inputmission;
        public string client;
        public string client2;
        public Sprite clientimage;
        public int inputitemid;
        public int inputitemnumber;
        public int getcoin;
        public int getitemid;
        public int getachievementsid;
        public int getpl;
        [Multiline]public string getsource;
        [Multiline] public string getsource2;
    }
    [Header("クエスト情報")]
    public mission[] missionID;
    [System.Serializable]
    public struct achievements
    {
        //各実績情報
        [Multiline]
        public string name;
        [Multiline]
        public string name2;
        [Multiline]
        public string script;
        [Multiline]
        public string script2;
        public int gettrg;
        public Sprite image;
    }
    //new
    [Header("実績情報")]
    public achievements[] achievementsID;

    [System.Serializable]
    public struct enemynote
    {
        //敵図鑑内の各敵情報
        [Multiline]
        public string name;
        [Multiline]
        public string name2;
        [Multiline]
        public string script;
        [Multiline]
        public string script2;
        [Multiline]
        public string inputhouse;
        [Multiline]
        public string inputhouse2;
        public string inputattacktype;
        public string inputattacktype2;
        public string inputbadtype;
        public string inputbadtype2;
        public int gettrg;
        public Sprite image;
    }
    //new
    [Header("敵図鑑情報")]
    public enemynote[] enemynoteID;
    [Header("現在のタップ、マウス位置")]
    public Vector3 mouseP; //現在のマウス位置
    [Header("各ステージ名")]
    public string[] stageName; //各ステージ名_日本語
    public string[] stageName2; //各ステージ名_英語
    [Header("ゲーム内時間で使用")]
    public float sunTime = 72; //現在のゲーム内時間(太陽の移動にも使用)
    [Header("ゲーム内経過日数")]
    public int daycount = 0; //ゲーム内経過日数
    [Header("討伐状態")]
    public int[] mobDsTrg; //各敵モンスターの討伐状態(日が変わればリセットされる用)
    [Header("一時的なショップ情報")]
    public int[] shopID; //一時的な、ショップIDに該当する商品内容(会話イベントから各NPCに応じてショップを変えるため)
    public int[] stoneID; //旧ショップ内容、現在はほとんど使用していない
    [Header("アイテムから魔法を発動させる用")]
    public int itemMagicID; //アイテムから魔法を発動させるために、一時的な魔法ID格納
    [Header("気にするな")]
    public string villageName = ""; //集落関連の一時的な名前
    [Header("章、イベントの始終で行う演出用")]
    public string storyUI = ""; //章の始終で使用する、一時的な短い文章

    [System.Serializable]
    public struct CharaManager
    {
        //ステータス変化が起きる用
        [System.Serializable]
        public struct subManager
        {
            public int activeTrg;
            public int animInt;
            public int startseTime;
            public AudioClip se;
            public int seMnumber;
            public float startatTime;
            public GameObject atobj;
            public float addload;
            public int removemp;
            public int removeusegage;
            public Sprite atImage;
        }
        public subManager[] subM;
        public bool useTrg;
        public bool mainpartsTrg;
        public int usegage;
        public GameObject partsobj;
        public float speed;
        public int MaxHP;
        public int HP;
        public int MaxMP;
        public int MP;
        public float jump;
        public Sprite slImage;
    }
    [Header("あまり気にしないで")]
    public CharaManager[] charaM;
    [Header("攻撃で回復")]
    public bool hitcure = false;//敵に攻撃が当たってMPを回復させる用
    [Header("一時的なコライダー取得用")]
    public bool[] colTrg;//一時的な、コライダー取得用
    [Header("あまりにも汎用過ぎる音を格納")]
    public AudioClip[] managerSE; //汎用的な効果音を格納

    [System.Serializable]
    public struct miniGame
    {
        //かくれんぼ等で使用(後から徐々に追加される)
        [Header("ミッションが進んでいる状態か")]
        public int input_indexTrg;
        [Header("ミッションに割り振られた隠れ場所のID※スクリプトから変更")]
        public int[] input_missionID;
        [Header("各ミッションのヒント(日本語)")]
        public string[] set_itemScript;
        [Header("各ミッションのヒント(英語)")]
        public string[] set_itemScript2;
    }
    [Header("ミニゲーム用(現在はかくれんぼ)")]
    public miniGame _minigame;
    public float[] instantP;//(一時的な、会話中に位置情報を保存する用)

    [System.Serializable]
    public struct CraftID
    {
        //各クラフトレシピの情報
        public string recipeName;
        //public int input_getRecipe;
        [Header("作成するアイテム")]
        public int craftItem_id;
        public int craftGet_number;
        public int craftSub_id;
        public int craftSub_number;
        [Header("使用する素材(6種類まで)")]
        public int[] materialItem_id;
        public int[] materialSet_number;
    }
    [Header("クラフトレシピ情報")]
    public CraftID[] _craftRecipe;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
   
}
