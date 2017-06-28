using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactCalc;
using ReactCalc.Models;

namespace WinCalc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var calc = new Calc();
            var operations = calc.Operations;

            lboperations.DataSource = operations;
            lboperations.DisplayMember = "Name";
            lboperations.SelectedIndex = 0;

            this.ActiveControl = tbx;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void res_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var oper = lboperations.SelectedItem as IDisplayOperation;
            if (!oper.hard)
                doIt();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            doIt();
        }
        /// <summary>
        /// Функция, считывающая операцию с входными данными и выполняющая ее
        /// </summary>
        private void doIt()
        {
            //Определяем операцию
            var oper = lboperations.SelectedItem as IDisplayOperation;
            if (oper == null)
            {
                res.Text = "Введите существующую операцию";
                return;
            }
            //Определяем входные данные
            var x = ReactCalc.Calc.ToNumber(tbx.Text);
            var y = ReactCalc.Calc.ToNumber(tby.Text);
            //Вычисляем 
            try
            {
                var result = new ReactCalc.Calc();
                var doubRes = result.Execute(oper.Execute, new[] { x, y });
                res.Text = string.Format("\n{0} = {1}", oper.rusName, doubRes);
            }
            catch (Exception ex)
            {
                res.Text = string.Format("Опаньки: {0} ", ex.Message);
            }
        }

        private void lboperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var displayOper = lboperations.SelectedItem as IDisplayOperation;
            discplabel.Text = displayOper.Discription; 
            if (displayOper != null)
            {
                lboperations.Text = string.Format("Автор: {0} Описание: {1}", displayOper.Author, 
                    !string.IsNullOrWhiteSpace(displayOper.Discription)? 
                    displayOper.Discription:"Описания нет");
            }
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            var oper = lboperations.SelectedItem as IDisplayOperation;
            if (!oper.hard)
                doIt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbx.Text == "")
            {
                this.ActiveControl = tbx;
                return;
            }
            if (tby.Text == "")
            {
                this.ActiveControl = tby;
                return;
            }
            doIt();
        }

        private void calc_KeyPress(object sender, KeyPressEventArgs e)
        {
            doIt();
        }
    }
}
