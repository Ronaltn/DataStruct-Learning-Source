using System;
using System.Collections.Generic;
using System.Text;

namespace DrawStars
{
    class Program
    {
        /// <summary>
        /// ���ͼ��������ʾ
        /// 
        /// ****
        /// ***
        /// **
        /// *
        /// *
        /// **
        /// ***
        /// ****
        /// 
        /// </summary>
        /// <param name="index">��������ַ�����</param>
        /// <param name="line">ָ����ǰ���Ƶ�����</param>
        /// <param name="count">��ǰ�е�ͼ����</param>
        /// <param name="total">������ͼ���е����ֵ</param>
        static void draw1(int index, int line, int count, int total)
        {
            if (line >= 1 && line <= total)
            {
                if (index == count + 1)
                {
                    Console.Write("\n");
                    draw1(1, line + 1, count - 1, total);
                }
                else if (index < count + 1)
                {
                    Console.Write("*");
                    draw1(index + 1, line, count, total);
                }
            }
            else if (line >= total + 1 && line <= total * 2)
            {
                if (index == line - total + 1)
                {
                    Console.Write("\n");
                    draw1(1, line + 1, count + 1, total);
                }
                else if (index < line - total + 1)
                {
                    Console.Write("*");
                    draw1(index + 1, line, count, total);
                }
            }
        }

        /// <summary>
        /// ���ͼ��������ʾ
        /// 
        /// *
        /// **
        /// ***
        /// ****
        /// ****
        /// ***
        /// **
        /// *
        /// 
        /// </summary>
        /// <param name="index">��������ַ�����</param>
        /// <param name="line">ָ����ǰ���Ƶ�����</param>
        /// <param name="count">��ǰ�е�ͼ����</param>
        /// <param name="total">������ͼ���е����ֵ</param>
        static void draw2(int index, int line, int count, int total)
        {
            if (line >= 1 && line <= total)
            {
                if (index == count + 1)
                {
                    Console.Write("\n");
                    draw2(1, line + 1, count + 1, total);
                }
                else if (index < count + 1)
                {
                    Console.Write("*");
                    draw2(index + 1, line, count, total);
                }
            }
            else if (line >= total + 1 && line <= total * 2)
            {
                if (index == count)
                {
                    Console.Write("\n");
                    draw2(1, line + 1, count - 1, total);
                }
                else if (index < count)
                {
                    Console.Write("*");
                    draw2(index + 1, line, count, total);
                }
            }
        }

        /// <summary>
        ///    *
        ///   * *
        ///  * * *
        /// * * * *
        ///  * * *
        ///   * *
        ///    *
        /// </summary>
        /// <param name="index">��������ַ�����</param>
        /// <param name="line">ָ����ǰ���Ƶ�����</param>
        /// <param name="space">��ǰ�еĿո���</param>
        /// <param name="count">��ǰ�е�ͼ����</param>
        /// <param name="total">������ͼ���е����ֵ</param>
        static void draw3(int index, int line, int space, int count, int total)
        {
            if (line >= 1 && line < total)
            {
                if (index <= space)
                {
                    Console.Write(" ");
                    draw3(index + 1, line, space, count, total);
                }
                else if (index > space && index <= space + count)
                {
                    Console.Write("* ");
                    draw3(index + 1, line, space, count, total);
                }
                else if (index >= space + count + 1)
                {
                    Console.Write("\n");
                    draw3(1, line + 1, space - 1, count + 1, total);
                }
            }
            else if (line == total)
            {
                if (index <= count)
                {
                    Console.Write("* ");
                    draw3(index + 1, line, 0, count, total);
                }
                else if (index > count)
                {
                    Console.Write("\n");
                    draw3(1, line + 1, 1, count - 1, total);
                }
            }
            else if (line > total && line < total * 2)
            {
                if (index <= space)
                {
                    Console.Write(" ");
                    draw3(index + 1, line, space, count, total);
                }
                else if (index > space && index <= space + count)
                {
                    Console.Write("* ");
                    draw3(index + 1, line, space, count, total);
                }
                else if (index >= space + count + 1)
                {
                    Console.Write("\n");
                    draw3(1, line + 1, space + 1, count - 1, total);
                }
            }
        }
       
        static void Main(string[] args)
        {
            draw1(1, 1, 4, 4);
            draw2(1, 1, 1, 4);
            draw3(1, 1, 3, 1, 4);
        }
    }
}
