﻿using CPSC481Group12FoodyApp.Logic;
using System;
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

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for ExpandRestaurant.xaml
    /// </summary>
    public partial class ExpandRestaurant : UserControl
    {
        public ExpandRestaurant()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            enableUnderDev();
        }

        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            enableUnderDev();
        }

        private void editBtn(object sender, RoutedEventArgs e)
        {
            AllNotesText.IsReadOnly = false;
            AllNotesText.Focus();
            Save.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }

        private void saveBtn(object sender, RoutedEventArgs e)
        {
            string newBio = AllNotesText.Text;
            if (newBio.Length > 250)
            {
                AllNotesText.Text = "Please limit your notes to 250 characters or less.";
            }
            else
            {
                AllNotesText.IsReadOnly = true;
                Logic_Home.editUserRestaurantNotes(AllNotesText.Text);
            }

            Edit.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Hidden;
        }

        private void Trash_Click(object sender, RoutedEventArgs e)
        {
            Logic_Home.delUserRestaurant();
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListControl.ItemsSource = formatRestaurantCriteria();
        }

        private List<string> formatRestaurantCriteria() {
            var original = SessionData.getRestaurantCriteria(SessionData.getCurrentResId());
            var collection = new List<string>();

            foreach (var info in original)
            {
                collection.Add("• " + SessionData.getCriterionName(info));
            }

            return collection;        
        }

        private void AllNotesText_Loaded(object sender, RoutedEventArgs e)
        {
            AllNotesText.Text = Logic_Home.getUserRestaurantNotes();
        }

        private void RestaurantName_Loaded(object sender, RoutedEventArgs e)
        {
            RestaurantName.Text = SessionData.getRestaurantName(SessionData.getCurrentResId());
        }

        public void enableUnderDev()
        {
            UnderDevRec.Visibility = Visibility.Visible;
            UnderDevGrid.Visibility = Visibility.Visible;

            TopBar.IsHitTestVisible = false;
            BottomBar.IsHitTestVisible = false;
            Star.IsHitTestVisible = false;
            send.IsHitTestVisible = false;
            Edit.IsHitTestVisible = false;
            Save.IsHitTestVisible = false;
            Trash.IsHitTestVisible = false;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            TopBar.IsHitTestVisible = true;
            BottomBar.IsHitTestVisible = true;
            Star.IsHitTestVisible = true;
            send.IsHitTestVisible = true;
            Edit.IsHitTestVisible = true;
            Save.IsHitTestVisible = true;
            Trash.IsHitTestVisible = true;

            UnderDevRec.Visibility = Visibility.Hidden;
            UnderDevGrid.Visibility = Visibility.Hidden;
        }
    }
}
