using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace snake {
    // 上传数据
    class postData {

        // 开启上传数据线程
        public static void RequestData() {
            Thread thread1 = new Thread(new ThreadStart(RequestThread));
            thread1.Start();
        }

        // 上传数据
        private static void RequestThread() {
            try {
                Console.WriteLine("\n\n上传数据中。。。\n\n");
                string hostname = Dns.GetHostName();// 得到本机名   
                // IPHostEntry localhost = Dns.GetHostByName(hostname);// 方法已过期，只得到IPv4的地址   
                IPHostEntry localhost = Dns.GetHostEntry(hostname);
                IPAddress localaddr = localhost.AddressList[2];
                Uri Url = new Uri("http:// 139.219.227.29:1234/index.aspx");
                string postDataStr = "Ip="+ localaddr.ToString()+ "&Player="+ constData.userName + "&Fraction="+constData.Fraction;
               
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                // request.ContentLength = postDataStr.Length;
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1) {
                    encoding = "UTF-8"; // 默认编码
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();
                Console.WriteLine(retString);
            }
            catch (Exception e) {
                Console.WriteLine("上传失败!!!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
