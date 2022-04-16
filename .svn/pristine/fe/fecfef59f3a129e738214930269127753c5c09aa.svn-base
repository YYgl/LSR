using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSR
{
    public partial class MainView : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private SqliteManager manager = new SqliteManager();
        public static int Kc = 0;
        FunView1 view1;
        FunView2 view2;
        FunView3 view3;
        FunView7 view7;
        public MainView()
        {
            InitializeComponent();
            manager.refreshKc();
            manager.refreshRecitedWord();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
            view7 = new FunView7(manager);
        }
        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }

        private void newWord_Click(object sender, EventArgs e)
        {
            view1 = new FunView1(manager);
            view1.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view1);
        }

        private void reviewWord_Click(object sender, EventArgs e)
        {
            view2 = new FunView2(manager);
            view2.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view2);
        }

        private void selectDic_Click(object sender, EventArgs e)
        {
            view3 = new FunView3(manager);
            view3.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view3);
        }

        private void regret_Click(object sender, EventArgs e)
        {
            FunView4 view4 = new FunView4();
            view4.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view4);
        }

        private void learnCondition_Click(object sender, EventArgs e)
        {
            FunView5 view5 = new FunView5();
            view5.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view5);
        }

        private void sustain_Click(object sender, EventArgs e)
        {
            FunView6 view6 = new FunView6();
            view6.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view6);
        }

        private void set_Click(object sender, EventArgs e)
        {
            view7.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view7);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            view1 = new FunView1(manager);
            view1.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view1);
        }
    }
}
