using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DXCollectionTest01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }


        List<Product> originProducts1;
        ObservableCollection<Product> originProducts2;
        ObservableCollection<Product> originProducts3;
        List<Product> originProducts4;
        ObservableCollection<Product> Products;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Products == null)
                Products = new ObservableCollectionCore<Product>();

            for (int i = 1; i < 4; i++)
            {
                Products.Add(new Product() { Chk = true, Text = String.Format("{0}00", i.ToString()) });
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            originProducts1 = Products.ToList();
            originProducts2 = new ObservableCollection<Product>(Products.ToList());
            originProducts3 = new ObservableCollection<Product>(Products.Clone());
            originProducts4 = Products.ToList();

            for (int i = 1; i < 2; i++)
            {
                Products[i].Text = String.Format("{0}00", (i + 3).ToString());
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in originProducts1)
                System.Diagnostics.Debug.WriteLine(String.Format("originProducts1 {0} / {1}", item.Chk, item.Text));

            System.Diagnostics.Debug.WriteLine("");

            foreach (var item in originProducts2)
                System.Diagnostics.Debug.WriteLine(String.Format("originProducts2 {0} / {1}", item.Chk, item.Text));

            System.Diagnostics.Debug.WriteLine("");

            foreach (var item in originProducts3)
                System.Diagnostics.Debug.WriteLine(String.Format("originProducts3 {0} / {1}", item.Chk, item.Text));

            System.Diagnostics.Debug.WriteLine("");

            foreach (var item in originProducts4)
                System.Diagnostics.Debug.WriteLine(String.Format("originProducts4 {0} / {1}", item.Chk, item.Text));

            List<Product> tmplist = new List<Product>();

            for (int i = 0; i < Products.Count; i++)
            {
                if (!Products[i].HasSameValues(originProducts3[i]))
                    tmplist.Add(Products[i]);
            }

            var tmp2 = Products.Where(x => originProducts3.Any(y => x.HasSameValues(y)) == false);
            var tmp3 = Products.Where(x => originProducts3.Any(y => x.GetHashCode() != y.GetHashCode()));

            // Products.Remove(tmp2.First());

        }
    }

    public static class Extensions
    {
        public static List<T> Clone<T>(this List<T> source)
        {
            return source.GetRange(0, source.Count);
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        //public static IList<T> Equals<T>(this IList<T> list) where T : IEquatable<T>
        //{
        //    return list.Select(item => (T)item.Equals()).ToList();
        //}
    }
}
