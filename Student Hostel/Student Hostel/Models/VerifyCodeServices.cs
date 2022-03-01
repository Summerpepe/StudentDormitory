using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class VerifyCodeServices
    {
        //生成指定长度的随机字符串，返回随机字符串
        private string RandomStr(int codeLength)
        {
            //组成字符串的集合,0-9数字、大小写字母,避免0和O同时出现
            string chars = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            //将集合按照,分开加入集合中
            string[] charArray = chars.Split(new Char[] { ',' });
            string code = "";
            int temp = -1;//记录上次随机数值，尽量避免产生几个一样的随机数
            Random rand = new Random();//生成随机数
            //采用几个简单算法以保证生成随机数的不同
            for (int i = 1; i < codeLength + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类
                }
                int t = rand.Next(60);
                if (temp == t)
                {
                    return RandomStr(codeLength);//如果产生的随机数与上一次的重复，则递归调用
                }
                temp = t;//把本次产生的随机数记录起来
                code += charArray[t];//随机数的位数加一
            }
            return code;//返回随机数
        }

        //将生成的字符串写入图像文件
        //验证码字符串
        //生成位数(默认四位)
        public MemoryStream Create(out string code, int length = 4)//输出验证码，长度制定
        {
            code = RandomStr(length);//调用RandomStr()方法，生成验证码
            Bitmap Img = null;
            Graphics graphics = null;
            MemoryStream ms = null;
            Random random = new Random();
            //颜色集合
            Color[] color = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan };
            //字体集合
            string[] fonts = { "Arial", "宋体" };
            //定义图像的大小也就是画布的大小，生成图像的实例//验证码的长度乘以18，高32
            Img = new Bitmap((int)code.Length * 18, 32);
            graphics = Graphics.FromImage(Img);//从Img对象生成新的Graphic对象
            graphics.Clear(Color.White);//背景设为白色
            //在随机位置画背景点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(Img.Width);
                int y = random.Next(Img.Height);
                graphics.DrawRectangle(new Pen(Color.LightCyan, 0), x, y, 1, 1);
            }
            //绘制验证码在graphic中,循环遍历验证码,依次给每个验证码赋予颜色和字体以及高度
            for (int i = 0; i <code.Length; i++)
            {
                //随机颜色索引值
                int colorIndex = random.Next(7);
                //随机字体索引值
                int fontIndex = random.Next(2);
                //字体
                Font font = new Font(fonts[fontIndex], 15, FontStyle.Bold);//大小15
                //颜色
                Brush brush = new SolidBrush(color[colorIndex]);
                int y = 4;
                //控制验证码不在同一高度
                if ((i + 1) % 2 == 0)
                {
                    y = 2;
                }
                //绘制一个验证字符
                graphics.DrawString(code.Substring(i, 1), font, brush, 3 + (i * 12), y);
            }

            //生成内存流对象
            ms = new MemoryStream();
            //将此图像以png图像文件的格式保存到流中
            Img.Save(ms, ImageFormat.Png);
            graphics.Dispose();
            Img.Dispose();
            return ms;
        }
    }
}
