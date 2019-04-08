using System;
using System.Collections;
using System.Collections.Generic;

public class Var {
    //--------------
    //variable變數
    //--------------

    //變數宣告格式
    //--
    //變數型別 變數名稱;
    //--

    //浮點數(小數)
    float floatingPoint = .0f;
    //整數
    int integer = 1;
    //布林值
    bool boolean = true;
    //字元
    char character = 'm';
    //字串
    string sentence = "momokoKawaF";
    //整數陣列
    int [ ] intArray = new int [10];
    //浮點數陣列
    float [ ] floatArrayWithInit = new float [ ] { .1f, .2f, .3f, .4f, .5f };
    //物件
    Var basicObject = new Var ( );

    //-------------
    //Method/Function(方法/函式)
    //-------------

    //函式宣告
    //--
    // 回傳值型別 函式名稱 (參數){
    //     函式主題
    // }
    //--

    //沒有回傳值沒有參數
    void WithoutReturnAndParam ( ) {
        Console.WriteLine ("I Like Momoko");
    }

    //回傳整數沒有參數
    int returnIntWithoutParam ( ) {
        Console.WriteLine ("I Like Momoko");
        return 5;
    }

    //回傳整數有參數
    int returnParam (int numberUwantReturn) {
        Console.WriteLine ("I Like Momoko");
        return (numberUwantReturn);
    }

    //----------------------------
    //How to use Method/Function
    //如何使用方法/函式
    //-----------------------------
    void Test ( ) {
        int result;
        WithoutReturnAndParam ( );
        result = returnIntWithoutParam ( );
        Console.WriteLine ("Result:{0}", result);
        result = returnParam (6);
        Console.WriteLine ("Result:{0}", result);
    }

    //----------------
    //----------------
    //----------------
    //選擇(choose)
    //----------------
    //----------------
    //if else elseif
    //如果分數大於90分就是S級評價 或者分數大於80分就是A級評價 或者分數大於70分就是B級評價 否則就是C級評價
    void TestIf ( ) {
        int score = 69;
        if (score >= 90) {
            Console.WriteLine ("S rank");
        }
        else if (score >= 80) {
            Console.WriteLine ("A rank");
        }
        else if (score >= 70) {
            Console.WriteLine ("B rank");
        }
        else {
            Console.WriteLine ("C rank");
        }
        //輸出結果:C rank
    }

    //-----------------------
    //-----------------------
    //switch case
    void TestSwitch ( ) {
        int chosen = 2;
        switch (chosen) {
            case 1:
                Console.WriteLine ("安格思牛肉堡");
                break;
            case 2:
                Console.WriteLine ("華堡");
                break;
            case 3:
                Console.WriteLine ("鱈魚堡");
                break;
            default:
                Console.WriteLine ("可以認真點餐嘛？臭肥宅");
                break;
        }
        //輸出結果:華堡

        //若chosen=3
        //輸出結果:鱈魚堡

        //若chosen=4
        //輸出結果:可以認真點餐嘛？臭肥宅
    }
    //-------------------------------

    //-------------------------------
    //-------------------------------
    //迴圈(Loop)
    //-------------------------------
    //-------------------------------

    //--
    //while Loop
    void WhileTest ( ) {
        int i = 0;
        int [ ] students = new int [45];
        while (i < 45) {
            i++;
            students [i - 1] = i;
        }
    }
    //-------------------------------

    //--
    //do while loop
    void doWhileTest ( ) {
        int [ ] students = new int [45];
        int i = 0;
        do {
            i++;
            students [i - 1] = i;
        } while (i < 45);
    }
    //---------------------------------

    //--
    //for loop
    void forTest ( ) {
        int [ ] students = new int [45];
        for (int i = 0; i < 45; i++) {
            students [i] = i + 1;
        }
    }
    //----------------------------------
}
