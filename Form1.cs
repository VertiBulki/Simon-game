﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Random rn = new Random();

        int startCount = 1;

        int currentCount = 0;

        bool isStarted = false;
        
        bool isFinished = false;

        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;

        bool isOpened1 = false;
        bool isOpened2 = false;
        bool isOpened3 = false;
        bool isOpened4 = false;

        MediaPlayer pl1 = new MediaPlayer();
        MediaPlayer pl2 = new MediaPlayer();
        MediaPlayer pl3 = new MediaPlayer();
        MediaPlayer pl4 = new MediaPlayer();

        PictureBox[] ranBoxes = new PictureBox[4];
        
        PictureBox[] arr = new PictureBox[3];
        PictureBox[] currentarr = new PictureBox[3];
        
        public Form1()
        {
            InitializeComponent();
            ranBoxes[0] = pictureBox1;
            ranBoxes[1] = pictureBox2;
            ranBoxes[2] = pictureBox3;
            ranBoxes[3] = pictureBox4;
        }

         private void button1_Click_1(object sender, EventArgs e)
        {
            this.KeyPreview = false;
            label1.Text = "";
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
            pictureBox3.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            pictureBox4.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            startCount = 1;
            f = 0;
            currentCount = 0;
            isStarted = false;
            Game_Meth();
            
        }
        async public void Game_Meth()
        {
            
            //if (isFinished == true)
                //return;
            button1.Enabled = false;

            this.KeyPreview = false;

            if (isStarted == false) //заполнение массива плиток
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = ranBoxes[rn.Next(4)];
                }
            }
            isStarted = true;

            for (int i = 0; i < startCount; i++)
            {
                
                await Task.Delay(500);
                if (startCount-1 == arr.Length)
                {
                    label1.Text = $"у вас {startCount-1} очка. уровень пройден";
                    return;
                }
                if (arr[i].BackColor == System.Drawing.Color.FromArgb(255, 128, 128))
                {
                    arr[i].BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    await Task.Delay(500);
                    arr[i].BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                }

                else if (arr[i].BackColor == System.Drawing.Color.FromArgb(128, 255, 128))
                {
                    arr[i].BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    await Task.Delay(500);
                    arr[i].BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                }

                else if (arr[i].BackColor == System.Drawing.Color.FromArgb(128, 128, 255))
                {
                    arr[i].BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
                    await Task.Delay(500);
                    arr[i].BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
                }

                else
                {
                    arr[i].BackColor = System.Drawing.Color.FromArgb(192, 192, 0);
                    await Task.Delay(500);
                    arr[i].BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                }
            } //демонстрация нажатия плиток в последовательности



            this.KeyPreview = false;
            await Task.Delay(500);
            this.KeyPreview = true;
            button1.Enabled = true;
            startCount++;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            DownTile(e);
            //Game_Meth();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            UpTile(e);
            
        }
        int f = 0;
         public void DownTile(KeyEventArgs ev)
        {
            switch (ev.KeyCode)
            {
                case Keys.Q:
                    if (flag1 == true)
                        return;
                    flag1 = true;
                    pictureBox1.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    if(isOpened1 == false)
                    { pl1.Open(new Uri(@"D:\работы в csharp\MemoryGame\MemoryGame\Resources\do1.wav")); isOpened1 = true; }
                    pl1.Position = TimeSpan.Zero;
                    pl1.Play();
                    currentarr[currentCount] = pictureBox1;
                    
                    
                    //after_Switch();
                    
                    return;
                case Keys.W:
                    if (flag2 == true)
                        return;
                    flag2 = true;
                    pictureBox2.BackColor = System.Drawing.Color.FromArgb(0,192,0);
                    if (isOpened2 == false)
                    { pl2.Open(new Uri(@"D:\работы в csharp\MemoryGame\MemoryGame\Resources\re1.wav")); isOpened2 = true; }
                    pl2.Position = TimeSpan.Zero;
                    pl2.Play();
                    currentarr[currentCount] = pictureBox2;
                    //after_Switch();
                    return;
                case Keys.E:
                    if (flag3 == true)
                        return;
                    flag3 = true;
                    pictureBox3.BackColor = System.Drawing.Color.FromArgb(0,0,192);
                    if (isOpened3 == false)
                    { pl3.Open(new Uri(@"D:\работы в csharp\MemoryGame\MemoryGame\Resources\mi1.wav")); isOpened3 = true; }
                    pl3.Position = TimeSpan.Zero;
                    pl3.Play();
                    currentarr[currentCount] = pictureBox3;
                    //after_Switch();
                    return;
                case Keys.R:
                    if (flag4 == true)
                        return;
                    flag4 = true;
                    pictureBox4.BackColor = System.Drawing.Color.FromArgb(192, 192, 0);
                    if (isOpened4 == false)
                    { pl4.Open(new Uri(@"D:\работы в csharp\MemoryGame\MemoryGame\Resources\fa1.wav")); isOpened4 = true; }
                    pl4.Position = TimeSpan.Zero;
                    pl4.Play();
                    currentarr[currentCount] = pictureBox4;
                    //after_Switch();
                    return;


            }
            
            
            
            //Game_Meth();
        }
        public void after_Switch()
        {
            
            if(f == currentCount)
            {
                for (int i = 0; i < currentCount + 1; i++) // проверка массивов на равные элементы, иначе игра окончена
                {
                    if (currentarr[i] != arr[i])
                    {
                        label1.Text = $"вы проебали со счетом{currentCount}";

                        Reset();
                        currentCount = 0;
                        startCount = 1;
                        f = 0;
                        return;
                    }


                }
                currentCount = 0;
                Game_Meth();
                f++;
                return;
            }
            currentCount++;
            
        }
        public void Reset()
        {
            this.KeyPreview = false;
            
        }
        public void UpTile(KeyEventArgs ev)
        {
            switch (ev.KeyCode)
            {
                case Keys.Q:
                    flag1 = false;
                    pictureBox1.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    after_Switch();
                    return;
                case Keys.W:
                    flag2 = false;
                    pictureBox2.BackColor = System.Drawing.Color.FromArgb(128,255,128);
                    after_Switch();
                    return;
                case Keys.E:
                    flag3 = false;
                    pictureBox3.BackColor = System.Drawing.Color.FromArgb(128,128,255);
                    after_Switch();
                    return;
                case Keys.R:
                    flag4 = false;
                    pictureBox4.BackColor = System.Drawing.Color.FromArgb(255,255,128);
                    after_Switch();
                    return;
            }
        }

        
        
    }
}
