﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class Form1 : Form
    {
        int totalTime = 1500;
        bool timerOn = true;
        bool workTime = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            lblTime.ForeColor = Color.FromArgb(1, 255, 236, 209);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Up)
            {
                if (workTime == true)
                {
                    timer.Start();
                    totalTime = 300;
                    lblTime.Text = "5:00";
                    lblTime.ForeColor = Color.FromArgb(1, 6, 123, 194);
                    workTime = false;
                }
                else
                {
                    lblTime.Text = "25:00";
                    lblTime.ForeColor = Color.FromArgb(1, 255, 236, 209);
                    timer.Start();
                    totalTime = 1500;                    
                    workTime = true;
                }

            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Right)
            {
                totalTime += 60;
                int minutes = totalTime / 60;
                int seconds = totalTime - (minutes * 60);
                lblTime.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Down)
            {
                if (timerOn == true)
                {
                    timer.Stop();
                    lblTime.ForeColor = Color.FromArgb(1, 191, 49, 0);                    
                    timerOn = false;
                }
                else
                {
                    timer.Start();
                    if (workTime == false)
                    {
                        lblTime.ForeColor = Color.FromArgb(1, 6, 123, 194);
                    }
                    else
                    {
                        lblTime.ForeColor = Color.FromArgb(1, 255, 236, 209);
                    }
                    timerOn = true;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(totalTime > 0)
            {
                totalTime--;
                int minutes = totalTime / 60;
                int seconds = totalTime - (minutes * 60);
                lblTime.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                if (workTime == true)
                {
                    totalTime = 300;
                    workTime = false;
                }
                else
                {
                    totalTime = 1500;
                    workTime = true;
                }
            }
        }
    }
}
