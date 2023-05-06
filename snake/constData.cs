using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake {
    public class constData {

        // 蛇所在框体的宽度
        public const int snakeTableWidth = 15;
        // 得分窗体的宽度
        public const int gradeTableWidth = 6;
        // 蛇所在框体的高度
        public const int snakeTableHeight = 18;
        // 右蛇头
        public const string snakeHeadRight = "●";
        // 左蛇头
        public const string snakeHeadLeft= "●";
        // 上蛇头
        public const string snakeHeadUp = "▲";
        // 下蛇头
        public const string snakeHeadDown = "▼";
        // 蛇头
        public const string snakeHead = "●";
        // 蛇身
        public const string snakeBody = "■";
        // 食物
        public const string snakeFood = "★";
        // 方向上
        public const int directionUp = 0;
        // 方向下
        public const int directionDown = 1;
        // 方向左
        public const int directionLeft = 2;
        // 方向右
        public const int directionRight = 3;

        // 等级坐标
        public static int[] GradeCoordinate = { snakeTableWidth + gradeTableWidth / 2 - 1, snakeTableHeight / 2 - 2 };
        // 当前游戏等级
        public static int Grade = 1;
        // 等级文字坐标
        public static int[] GradeTextCoordinate = { snakeTableWidth , snakeTableHeight / 2 - 3 };
        // 当前游戏等级文字说明
        public static string GradeText = "游戏等级为";
        // 分数坐标
        public static int[] FractionCoordinate = { snakeTableWidth + gradeTableWidth / 2 - 1, snakeTableHeight / 2+1 };
        // 当前游戏分数
        public static int Fraction = 0;
        // 分数文字坐标
        public static int[] FractionTextCoordinate = { snakeTableWidth + 1, snakeTableHeight / 2  };
        // 当前游戏分数文字说明
        public static string FractionText = "分数为";

        // 升级需要的分数
        public const int Upgrade = 20;
        // 通关需要的等级
        public const int Clearance = 11;
        // 是否接受按键
        public static bool AcceptKey = true;

        // 线程休眠时间
        public static int[] ThreadSleepTime = {600,550,500,450,400,350,300,250,200,150};
        // 游戏名
        public static string userName = "test";
    }
}