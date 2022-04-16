using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace data
{
    class Program
    {
        static void Main(string[] args)
        {
            bool over = false;   //是否下载完毕
            int j = 41;   //下载起始位置设置参数
            int i = 0;   //循环计数
            string oldName;   //音频原存储路径
            SqliteManager manager = new SqliteManager();
            List<string> list = manager.getWord();   //存储单词
            while(!over)
            {
                int cnt = 0;   //下载计数
                for (i = 100 * j; i < list.Count(); i++)   //一轮下载100个
                {
                    //浏览器访问下载网址，自动下载，下载好的音频文件存储在事先设置好的D:\.net架构程序设计\mp3路径下
                    System.Diagnostics.Process.Start(string.Format("https://fanyi.baidu.com/gettts?lan=en&text={0}&spd=3&source=web", list[i])); 
                    if(cnt == 0)   //第一个文件命名规则较特别，故特别处理
                    {
                        //为避免命名顺序与下载顺序不一致影响重命名，故仅当前一个文件下载完成后才开始下一个文件的下载
                        while (!File.Exists(string.Format("D:\\.net架构程序设计\\mp3\\tts.mp3", cnt)))
                            Thread.Sleep(10);
                    }
                    else
                    {
                        //为避免命名顺序与下载顺序不一致影响重命名，故仅当前一个文件下载完成后才开始下一个文件的下载
                        while (!File.Exists(string.Format("D:\\.net架构程序设计\\mp3\\tts ({0}).mp3", cnt)))
                            Thread.Sleep(10);
                    }                   
                    cnt++;
                    if (cnt >= 100)
                        break;
                }

                //进行重命名
                for (int k = 0; k < Program.min(100, list.Count() - 100 * j); k++)
                {
                    if (k == 0)
                        oldName = "D:\\.net架构程序设计\\mp3\\tts.mp3";
                    else
                        oldName = string.Format("D:\\.net架构程序设计\\mp3\\tts ({0}).mp3", k);
                    string newName = string.Format("D:\\.net架构程序设计\\mp3\\{0}.mp3", list[100 * j + k]);
                    File.Move(oldName, newName);   //重命名
                }

                j++;
                if (i >= list.Count())
                    over = true;
            }
        }

        public static int min(int a, int b)
        {
            return (a <= b) ? a : b;
        }
    }
}
