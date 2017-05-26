using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake
{
    public class constData
    {
        /// <summary>
        /// 蛇所在框体的宽度
        /// </summary>
        public const int snakeTableWidth = 15;
        /// <summary>
        /// 得分窗体的宽度
        /// </summary>
        public const int gradeTableWidth = 6;
        /// <summary>
        /// 蛇所在框体的高度
        /// </summary>
        public const int snakeTableHeight = 18;
        /// <summary>
        /// 右蛇头
        /// </summary>
        public const string snakeHeadRight = "●";
        /// <summary>
        /// 左蛇头
        /// </summary>
        public const string snakeHeadLeft= "●";
        /// <summary>
        /// 上蛇头
        /// </summary>
        public const string snakeHeadUp = "▲";
        /// <summary>
        /// 下蛇头
        /// </summary>
        public const string snakeHeadDown = "▼";
        /// <summary>
        /// 蛇头
        /// </summary>
        public const string snakeHead = "●";
        /// <summary>
        /// 蛇身
        /// </summary>
        public const string snakeBody = "■";
        /// <summary>
        /// 食物
        /// </summary>
        public const string snakeFood = "★";
        /// <summary>
        /// 方向上
        /// </summary>
        public const int directionUp = 0;
        /// <summary>
        /// 方向下
        /// </summary>
        public const int directionDown = 1;
        /// <summary>
        /// 方向左
        /// </summary>
        public const int directionLeft = 2;
        /// <summary>
        /// 方向右
        /// </summary>
        public const int directionRight = 3;
        /// <summary>
        /// 等级坐标
        /// </summary>
        public static int[] GradeCoordinate = { snakeTableWidth + gradeTableWidth / 2 - 1, snakeTableHeight / 2 - 2 };
        /// <summary>
        /// 当前游戏等级
        /// </summary>
        public static int Grade = 1;
        /// <summary>
        /// 等级文字坐标
        /// </summary>
        public static int[] GradeTextCoordinate = { snakeTableWidth , snakeTableHeight / 2 - 3 };
        /// <summary>
        /// 当前游戏等级文字说明
        /// </summary>
        public static string GradeText = "游戏等级为";

        /// <summary>
        /// 分数坐标
        /// </summary>
        public static int[] FractionCoordinate = { snakeTableWidth + gradeTableWidth / 2 - 1, snakeTableHeight / 2+1 };
        /// <summary>
        /// 当前游戏分数
        /// </summary>
        public static int Fraction = 0;
        /// <summary>
        /// 分数文字坐标
        /// </summary>
        public static int[] FractionTextCoordinate = { snakeTableWidth + 1, snakeTableHeight / 2  };
        /// <summary>
        /// 当前游戏分数文字说明
        /// </summary>
        public static string FractionText = "分数为";
        /// <summary>
        /// 升级需要的分数
        /// </summary>
        public const int Upgrade = 20;
        /// <summary>
        /// 通关需要的等级
        /// </summary>
        public const int Clearance = 11;
        /// <summary>
        /// 是否接受按键
        /// </summary>
        public static bool AcceptKey = true;
        /// <summary>
        /// 线程休眠时间
        /// </summary>
        public static int[] ThreadSleepTime = {600,550,500,450,400,350,300,250,200,150};
        /// <summary>
        /// 游戏名
        /// </summary>
        public static string userName = "test";
    }
}
