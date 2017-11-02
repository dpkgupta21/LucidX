// ***********************************************************************
// Assembly			: ComOps.IOS
// Author				: Akash Deep Kaushik
// CreatedAt			: 8/28/2017
//
// ***********************************************************************
// <copyright file="AddOrderSecondTVCell.cs" company="Pratham Software ">
//     Pratham Software Pvt. Ltd. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using Foundation;
using UIKit;

namespace LucidX.iOS.ViewController.Orders.AddOrder.AddOrderSecond.Cells
{
    public partial class AddOrderSecondTVCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("AddOrderSecondTVCell");
        public static readonly UINib Nib;

        static AddOrderSecondTVCell()
        {
            Nib = UINib.FromName("AddOrderSecondTVCell", NSBundle.MainBundle);
        }

        protected AddOrderSecondTVCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
