﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRIZ
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
            btnLogoCreativeThinker.MouseEnter += Program.LogoMouseEnter;
            btnLogoCreativeThinker.MouseLeave += Program.LogoMouseLeave;
            btnLogoEducationEra.MouseEnter += Program.LogoMouseEnter;
            btnLogoEducationEra.MouseLeave += Program.LogoMouseLeave;
            this.FormClosing += Program.ApplicationQuit;
            // 1) Создаем объект программы. С ним теперь всегда и работаем.
            RefreshUserList();
            //MessageBox.Show(tbPassword.PasswordChar.ToString());
        }

        public void RefreshUserList()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(User.GetUserNames().ToArray());
            tbLogin.AutoCompleteCustomSource = source;
        }

        #region Buttons' hover effects

        private void btnRegistration_MouseEnter(object sender, EventArgs e)
        {
            btnRegistration.BackgroundImage = Properties.Resources.btn_registration_hover;
        }
        private void btnRegistration_MouseLeave(object sender, EventArgs e)
        {
            btnRegistration.BackgroundImage = Properties.Resources.btn_registration;
        }

        private void btnLogoCreativeThinker_MouseEnter(object sender, EventArgs e)
        {
            btnLogoCreativeThinker.BackgroundImage = Properties.Resources.logo_creativethinker_hover;
        }
        private void btnLogoCreativeThinker_MouseLeave(object sender, EventArgs e)
        {
            btnLogoCreativeThinker.BackgroundImage = Properties.Resources.logo_creativethinker;
        }

        private void btnLogoEducationEra_MouseEnter(object sender, EventArgs e)
        {
            btnLogoEducationEra.BackgroundImage = Properties.Resources.logo_educationfornewera_hover;
        }
        private void btnLogoEducationEra_MouseLeave(object sender, EventArgs e)
        {
            btnLogoEducationEra.BackgroundImage = Properties.Resources.logo_educationfornewera;
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackgroundImage = Properties.Resources.btn_submitt_hover;
        }
        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackgroundImage = Properties.Resources.btn_submitt;
        }
        #endregion

        #region TextBoxes' focus effects
        static string _earlierText;
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).ForeColor = Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
                (sender as TextBox).Text = _earlierText;
            }

        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            _earlierText = (sender as TextBox).Text;
            (sender as TextBox).Text = "";
            (sender as TextBox).ForeColor = Color.Black;
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Пароль")
            {
                tbPassword.ForeColor = Color.Black;
                tbPassword.PasswordChar = '•';
                tbPassword.Text = "";
            }
        }
        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.ForeColor = Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
                tbPassword.Text = "Пароль";
                tbPassword.PasswordChar = ' ';
            }
        }
        #endregion TextBoxes' focus effects

       
        private void btnLogoCreativeThinker_Click(object sender, EventArgs e)
        {
            Program.InitWindow(Forms.fAboutCreativeSchool);
            //this.Hide();
            Program.fAboutCreativeSchool.Show();
        }
        private void btnLogoEducationEra_Click(object sender, EventArgs e)
        {
            Program.InitWindow(Forms.fAboutEducation);
            //this.Hide();
            Program.fAboutEducation.Show();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var users = User.GetListOfObjects();

            for (int i = 0; i < users.Count; i++)
            {
                if (
                    (users[i]._surname.ToLower() + " " + users[i]._name.ToLower()) == tbLogin.Text.ToLower()
                    &&
                    users[i]._password == tbPassword.Text
                    )
                {
                    Program.p._currentUser = i;
                    Program.InitWindow(Forms.fModules);
                    Program.fModules.Show();
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Неправильный логин или пароль");
        }
        static public FormRegistration f;
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            f = new FormRegistration();
            f.Show();
        }
        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click((object)sender, (EventArgs)e);
            }
        }

        private void btnLogoCreativeThinker_MouseEnter_1(object sender, EventArgs e)
        {
            btnLogoCreativeThinker.BackColor = Color.White;
        }

        private void FormLogin_SizeChanged(object sender, EventArgs e)
        {
            Program.currentSize = this.Size;
        }

        private void FormLogin_LocationChanged(object sender, EventArgs e)
        {
            Program.currentLocation = this.Location;
        }
    }
}

