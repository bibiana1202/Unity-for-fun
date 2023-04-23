using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MonoBehaviour : 유니티 게임 오브젝트 클래스
public class NewBehaviourScript : MonoBehaviour
{
    //전역번수 : 함수 바깥에 선언된 변수
    string title = "legend of";
    string playName = "나채리";
    int level = 5;
    float strength = 15.5f;
    int exp = 1500;
    int health = 30;
    int mana = 25;
    bool isFullLevel = true;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("안녕하세냥");

        // 선언 > 초기화 > 호출(사용)
        // 1. 변수 
        //int level = 5;
        ///float strength = 15.5f;
        //string playName = "나채리";
        //bool isFullLevel = true;

        Debug.Log("name?");
        Debug.Log(playName);
        Debug.Log("level?");
        Debug.Log(level);
        Debug.Log("power?");
        Debug.Log(strength);
        Debug.Log("maanlab?");
        Debug.Log(isFullLevel);

        // 2.그룹형 변수
        string[] monsters = { "슬라임", "사막뱀", "악마" };

        Debug.Log(monsters[0]);
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]);

        int[] monsterlevel = new int[3];
        monsterlevel[0] = 1;
        monsterlevel[1] = 6;
        monsterlevel[2] = 20;

        Debug.Log(monsterlevel[0]);
        Debug.Log(monsterlevel[1]);
        Debug.Log(monsterlevel[2]);

        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약30");

        //items.RemoveAt(0);

        Debug.Log(items[0]);
        Debug.Log(items[1]);

        // 3. 연산자
        //int exp = 1500;
        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;

        int nextExp = 300 - (exp % 300);
        Debug.Log(nextExp);

        //
        Debug.Log(title + " " + playName);

        int fulllevel = 99;
        isFullLevel = level == fulllevel;
        Debug.Log("is yongsa is maan lab??" + isFullLevel);

        
        bool isEndTutorial = level >= 10;
        Debug.Log("tutorial is over?" + isEndTutorial);

        //지역변수 : 함수안에서 선언된 변수  
        //int health = 30;
        //int mana = 25;
        bool isBadCondition = health <= 50 && mana <= 20;
        bool isBadCondition2 = health <= 50 || mana <= 20;

        Debug.Log("채리 의 상태가 나 쁨 니 까 ?" + isBadCondition);

        string condition = isBadCondition2 ? "나 쁨 " : "좋 음 ";
        Debug.Log("상 태 가 나 쁨 니 까 ?" + condition);

        //4. 키워드 : 프로그래밍 언어를 구성하는 특별한 언어 
        //int float string bool new List
        //int float = 1;

        //5. 조건문
        if (condition =="나 쁨 ")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요");

        }
        else
        {
            Debug.Log("플레이어 상태가 좋습니다");
        }

        if (isBadCondition && items[0] == "생명물약30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명포션30을 사용하였습니다");
        }
        else if (isBadCondition && items[0] == "마냐물약30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나포션30 을 사용하였습니다 ");
        }

        switch (monsters[1])
        {
            case "슬라임":
            case "사막뱀":
                Debug.Log("소형 몬스터가 출현 !");
                break;
            case "악마":
                Debug.Log("중형 몬스터가 출현 !");
                break;
            case "골렘":
                Debug.Log("대형 몬스터가 출현 !");
                break;
            default:
                Debug.Log("??? 몬스터가 출현");
                break;

        }

        // 6.반복문
        while (health>0)
        {
            health--;
            if (health > 0)
                Debug.Log("독 데미지를 입었습니. " + health);
            else
                Debug.Log("사망하였습니다");

            if(health == 10)
            {
                Debug.Log("해독제를 사용합니다 ");
                break;
            }

        }

        //for (연산될 변수; 조건; 연산) { 로직 }
        for (int count =0; count< 10;  count++)
        {
            health++;
            Debug.Log("붕대로 치료 중 " + health);
        }

        for (int index = 0; index < monsters.Length; index++){
            Debug.Log("이 지역에 있는 몬스터: " + monsters[index]);
             
        }

        foreach(string monster in monsters)
        {
            Debug.Log("이 지역에 있는 몬스터:" + monster);
        }


        //health = Heal(health);
        Heal();

        for(int index= 0; index <monsters.Length; index++)
        {
            Debug.Log("용사는 " + monsters[index] + " 에게 " + Battle(monsterlevel[index]));
        }

        //8.클래스 : 하나의 사물 (오브젝트 )와 대응하는 로직
        //class : 클래스 선언에 사용
        //Actor player = new Actor(); //인스턴스 : 정의된 클래스를 변수 초기화로 실체화
        //player.LevelUp();
        //Debug.Log(player.name + "의 레벨은 " + player.level + "입니다 ");
        Player player = new Player();
        player.id = 0;
        player.name = "나법사 ";
        player.title = "";
        player.strength = 2.4f;
        player.weapon = "나무지팡이";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "의 레벨은 " + player.level + "입니다 ");
        Debug.Log(player.move());

    }



    //7.함수(메소드)

    //int Heal(int currentHealth)
    void Heal()
    {
        //currentHealth += 10;
        health += 10;
        Debug.Log("힘을 받았습니다 " + health);//currentHealth);
        //return health;
    }


    string Battle(int monsterlevel)
    {
        string result;
        if (level == monsterlevel)
            result = "이겼습니다";
        else
            result = "졌습니다 ";

        return result;
    }

}