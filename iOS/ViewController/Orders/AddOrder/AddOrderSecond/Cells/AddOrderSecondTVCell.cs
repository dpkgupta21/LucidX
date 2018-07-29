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
<<<<<<< HEAD

using Foundation;
using UIKit;

namespace LucidX.iOS.ViewController.Orders.AddOrder.AddOrderSecond.Cells
=======
using Foundation;
using LucidX.ResponseModels;
using UIKit;

namespace LucidX.iOS
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
{
    public partial class AddOrderSecondTVCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("AddOrderSecondTVCell");
        public static readonly UINib Nib;
<<<<<<< HEAD
=======
		int Index;
		public EventHandler EditClicked;
		public EventHandler DeleteClicked;
		
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7

        static AddOrderSecondTVCell()
        {
            Nib = UINib.FromName("AddOrderSecondTVCell", NSBundle.MainBundle);
        }

        protected AddOrderSecondTVCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
<<<<<<< HEAD
    }
=======

		public void configure(LedgerOrderItem data,int index)
		{
			Index = index;
			LblAccountNameValue.Text = data.AccountName;
			LblTaxValue.Text = data.TaxAmount.ToString();
			LblItemTitle.Text = data.LineDescription;
			LblBaseAmountValue.Text = data.BaseAmount.ToString();
		}

		partial void BtndeleteClicked(Foundation.NSObject sender) { 
			if (DeleteClicked != null)
			{
				DeleteClicked(Index, null);
			}
		}

		partial void BtnEditClicked(Foundation.NSObject sender) {
			if (EditClicked != null) {
				EditClicked(Index, null);
			}
		}

	}
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
}
