using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace snake {
    class Program {

        // 主函数
        static void Main(string[] args) {
            Console.CursorVisible = false;
            // initSnake frame = new initSnake();
            // List<int[]> snakes = new List<int[]>();
            initData();
            Console.WriteLine("请输入你的游戏名（回车键确定）\n");
            constData.userName = Console.ReadLine();
            Console.Clear();
            Console.Write("\n\n\t上下左右控制方向，空格键暂停，按下Y键开始游戏（Tips:英文状态下）");
            Console.Write("\n\n\t目前每"+constData.Upgrade + "分升一级，到达"+ constData.Clearance + "级就可以通关，通关有特殊奖励");
            Console.Write("\n\n\t已开启积分排行榜，可以访问网站查看  aifamily.top \n\t备用地址：139.219.227.29:1234");
            // 开启线程
            Thread thread1 = new Thread(new ThreadStart(snakeThread)); 
            while (true) {
                if (constData.AcceptKey == false && initSnake.suspend == false) {// 不接收按键且没有暂停
                    continue;
                }
                ConsoleKeyInfo info = Console.ReadKey();
                if (initSnake.suspend == true) {
                    if(info.Key != ConsoleKey.Spacebar) {
                        continue;
                    }
                }
                if (info.Key == ConsoleKey.Y) { // 开始
                    if (thread1.IsAlive == false) {
                        thread1.Start();
                    }
                }
                if (info.Key == ConsoleKey.Spacebar) { // 暂停
                    if (initSnake.suspend == false) {
                        initSnake.suspend = true;
                        continue;
                    }
                    else if (initSnake.suspend == true) {
                        initSnake.suspend = false;
                    }
                }
                switch (info.Key) {
                case ConsoleKey.UpArrow:
                    if (initSnake.direction != constData.directionDown) {
                        if (initSnake.direction == constData.directionUp) {
                            constData.AcceptKey = true;
                        } else {
                            constData.AcceptKey = false;
                        }
                        initSnake.direction = constData.directionUp;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (initSnake.direction != constData.directionUp) {
                        if (initSnake.direction == constData.directionDown) {
                            constData.AcceptKey = true;
                        } else {
                            constData.AcceptKey = false;
                        }
                        initSnake.direction = constData.directionDown;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (initSnake.direction != constData.directionRight) {
                        if (initSnake.direction == constData.directionLeft) {
                            constData.AcceptKey = true;
                        } else {
                            constData.AcceptKey = false;
                        }
                        initSnake.direction = constData.directionLeft;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (initSnake.direction != constData.directionLeft) {
                        if (initSnake.direction == constData.directionRight) {
                            constData.AcceptKey = true;
                        } else {
                            constData.AcceptKey = false;
                        }
                        initSnake.direction = constData.directionRight;
                    }
                    break;
                default:   
                    break;
                }   
            }      
        }
// 线程
        public static void snakeThread() {
            initSnake a = new initSnake();
            a.updateSnake();  
        }
// 初始化数据
        public static void initData() {
            int[] snake0 = { 5, 6 };
            int[] snake1 = { 5, 7 };
            int[] snake2 = { 5, 8 };
            int[] snake3 = { 5, 9 };
            int[] food = { 5, 3 };
            initSnake.snakes.Clear();
            initSnake.snakes.Add(snake0);
            initSnake.snakes.Add(snake1);
            initSnake.snakes.Add(snake2);
            initSnake.snakes.Add(snake3);
            initSnake.direction = constData.directionUp;
            initSnake.food = food;
            constData.AcceptKey = true;
        }
    }
// 蛇运动
    class initSnake {
        // 蛇运动方向
        // </summary>                       
        public static int direction = constData.directionUp;
        // 蛇的坐标
        public static List<int[]> snakes = new List<int[]>();
        // 是否暂停
        public static bool suspend = false;
        // 食物坐标
        public static int[] food = { 5, 3};
                    
        // 显示出蛇
        public void init() {
            while (suspend == true) {
                Thread.Sleep(1);
            }
            
            string snakeValue = ""; 
            for (int i = 0; i < constData.snakeTableHeight; i++) {
                for (int j = 0; j < constData.snakeTableWidth+constData.gradeTableWidth; j++) {
                    bool isHave = false;     
                    if (food[0] == j && food[1] == i) { // 判断是否是食物坐标
                        // Console.Write(constData.snakeFood);
                        snakeValue += constData.snakeFood;
                        continue;
                    }
                    for (int k = 0; k < snakes.Count; k++) {
                        if (Convert.ToInt32(snakes[k][0]) == j && Convert.ToInt32(snakes[k][1]) == i && k == 0) { // 判断是否为蛇头
                            // Console.Write(constData.snakeHeadUp);
                            // 蛇头改变
                            // switch (direction)
                            // {
                            //    case constData.directionUp:
                            //        snakeValue += constData.snakeHeadUp;
                            //        break;
                            //    case constData.directionDown:
                            //        snakeValue += constData.snakeHeadDown;
                            //        break;
                            //    case constData.directionLeft:
                            //        snakeValue += constData.snakeHeadLeft;
                            //        break;
                            //    case constData.directionRight:
                            //        snakeValue += constData.snakeHeadRight;
                            //        break;
                            // }
                            snakeValue += constData.snakeHead;
                            isHave = true;
                            break;
                        }
                        if (Convert.ToInt32(snakes[k][0]) == j && Convert.ToInt32(snakes[k][1]) == i && k != 0) { // 判断是否为蛇身
                            // Console.Write(constData.snakeBody);
                            snakeValue += constData.snakeBody;
                            isHave = true;
                            break;
                        }
                    }
                    if (isHave == true) {
                        continue;
                    }
                    if (j == constData.GradeTextCoordinate[0] && i == constData.GradeTextCoordinate[1]) {
                        snakeValue += constData.GradeText;
                        j += constData.GradeText.Length - 1;
                        continue;
                    }
                    else if (j == constData.GradeCoordinate[0] && i == constData.GradeCoordinate[1]) {
                        snakeValue += constData.Grade.ToString().PadLeft(2,'0');
                        continue;
                    }
                    else if (j == constData.FractionTextCoordinate[0] && i == constData.FractionTextCoordinate[1]) {
                        snakeValue += constData.FractionText;
                        j += constData.FractionText.Length - 1;
                        continue;
                    }
                    else if (j == constData.FractionCoordinate[0] && i == constData.FractionCoordinate[1]) {
                        snakeValue += constData.Fraction.ToString().PadLeft(2, '0');
                        continue;
                    }
                    if (i == 0 || i == constData.snakeTableHeight - 1) { // 判断是否为上下墙壁
                        // Console.Write("▇");
                        snakeValue += "▇";
                    }
                    else if (j == 0 || j == constData.snakeTableWidth - 1 || j == (constData.snakeTableWidth + constData.gradeTableWidth - 1)) { // 判断是否为左右墙壁
                        // Console.Write("▇");
                        snakeValue += "▇";
                    }
                    else {   // 填充没有东西的坐标
                        // Console.Write("  ");
                        snakeValue += "  ";
                    }
                }
// Console.WriteLine("");
                snakeValue += "\r\n";
            }
            Console.Clear();
            Console.Write(snakeValue);
            constData.AcceptKey = true;
            Thread.Sleep(constData.ThreadSleepTime[constData.Grade-1]);
            updateSnake();
// updateSnake(ref snakes);
        }
// 改变蛇的坐标
        public  void updateSnake() {   
            List<int[]> CopyList = Clone<int[]>(snakes); // 深复制蛇的坐标
            int[] snake0 = snakes[0];
            switch (direction) {
            case constData.directionUp:
                if (Convert.ToInt32(snake0[1]) - 1 == 0) {
                    Console.Clear();
                    Console.Write("你输了");
                    postData.RequestData();
                    return;
                } else {
                    snakes[0][1] = Convert.ToInt32(snake0[1]) - 1;
                }
                break;
            case constData.directionDown:
                if (Convert.ToInt32(snake0[1]) + 2 == constData.snakeTableHeight) {
                    Console.Clear();
                    Console.Write("你输了");
                    postData.RequestData();
                    return;
                } else {
                    snakes[0][1] = Convert.ToInt32(snake0[1]) + 1;
                }
                break;
            case constData.directionLeft:
                if (Convert.ToInt32(snake0[0]) - 1 == 0) {
                    Console.Clear();
                    Console.Write("你输了");
                    postData.RequestData();
                    return;
                } else {
                    snakes[0][0] = Convert.ToInt32(snake0[0]) - 1;
                }
                break;
            case constData.directionRight:
                if (Convert.ToInt32(snake0[0]) + 2 == constData.snakeTableWidth) {
                    Console.Clear();
                    Console.Write("你输了");
                    postData.RequestData();
                    return;
                } else {
                    snakes[0][0] = Convert.ToInt32(snake0[0]) + 1;
                }
                break;
            default:
                return;
            }    
            for (int i = 1; i < snakes.Count; i++) {
                if (snakes[0][0] == snakes[i][0]&& snakes[0][1] == snakes[i][1]) {
                    Console.Clear();
                    Console.Write("你输了");
                    postData.RequestData();
                    return;
                }
                snakes[i] = CopyList[i-1]; 
            }  
            if (snakes[0][0] == food[0]&& snakes[0][1] == food[1]) { // 吃到了食物
                snakes.Add(CopyList[CopyList.Count - 1]);
                constData.Fraction++; 
                RandomFood();
                if (constData.Fraction == constData.Upgrade * constData.Grade) {
                    constData.Grade++;
                    if (constData.Grade == constData.Clearance) {
                        Console.Clear();
                        Console.Write("\n\n\n\t大侠你已经通关了，特奖励作者联系方式：lhj0502@vip.qq.com");
                        postData.RequestData();
                        return;
                    } else {
                        Program.initData();
                    }
                }
            }
            init(); 
        }
// 递归随机生成食物
        public void RandomFood() {
            Random x = new Random();
            int n = x.Next(1, constData.snakeTableWidth-2);
            Random y = new Random();
            int m = x.Next(1, constData.snakeTableHeight-2);
            int[] coordinate = { n, m };
            for (int i = 0; i < snakes.Count; i++) {
                if (coordinate[0] == snakes[i][0] && coordinate[1] == snakes[i][1]) {
                    RandomFood();
                    return;
                } 
            }
            food = coordinate; 
        }
// list深复制
        public static List<T> Clone<T>(object List) {
            using (Stream objectStream = new MemoryStream()) {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, List);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as List<T>;
            }
        }
    }
}
