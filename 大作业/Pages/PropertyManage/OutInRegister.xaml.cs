﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpfz;

namespace WpfzDemos.Pages.PropertyManage
{
    /// <summary>
    /// OutInRegister.xaml 的交互逻辑
    /// </summary>
    public partial class OutInRegister : Page
    {
        public OutInRegister()
        {
            InitializeComponent();
        }

        public void showAdmin()
        {
            var c = new Model1Container();
            var q = from t in c.OutInInfo select t;
            dataGrid.ItemsSource = q.ToList();
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            string _stuName = stuName.Text;
            int _stuID = int.Parse(stuID.Text);
            string _stuDepart = stuDepart.Text;
            string _stuProfession = stuProfession.Text;
            int _stuBuildingNum = int.Parse(stuBuildingNum.Text);
            int _stuDormNum = int.Parse(stuDormNum.Text);
            string _repairReason = repairReason.Text;
            string _repairTime = repairTime.Text;

            var c = new Model1Container();
            var q = from t in c.OutInInfo select t;
            int count = q.Count();
            OutInInfo outInInfo = new OutInInfo
            {
                Id = count + 1,
                name = _stuName,
                studentID = _stuID,
                partment = _stuDepart,
                profession = _stuProfession,
                buildingNum = _stuBuildingNum,
                dormNum = _stuDormNum,
                thing = _repairReason,
                time = _repairTime
            };


            c.OutInInfo.Add(outInInfo);
            c.SaveChanges();

            showAdmin();
            add_ok();
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            stuName.Text = "";
            stuID.Text = "";
            stuDepart.Text = "";
            stuProfession.Text = "";
            stuBuildingNum.Text = "";
            stuDormNum.Text = "";
            repairReason.Text = "";
            repairTime.Text = "";
        }

        private void add_ok()
        {
            MessageBoxz.ShowInfo("物品出入信息添加成功");
        }
    }
}
