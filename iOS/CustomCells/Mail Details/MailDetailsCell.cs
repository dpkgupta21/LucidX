using System;

using Foundation;
using UIKit;

namespace CustomCells
{
	public partial class MailDetailsCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("MailDetailsCell");
		public static readonly UINib Nib = UINib.FromName("MailDetailsCell", NSBundle.MainBundle);

		protected MailDetailsCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void ConfigureView() {
			IBMailAddressLbl.Text = "abc@xyz.com";
			IBDescLbl.Text = "fsfdf s g s";
			IBDateTimeLbl.Text="8 dec\n 3:56 am";
		}

	}
}
