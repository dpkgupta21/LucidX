using System;

using Foundation;
using LucidX.ResponseModels;
using UIKit;

namespace LucidX.iOS.CustomCells
{
	public partial class NotesCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("NotesCell");
		public static readonly UINib Nib = UINib.FromName("NotesCell", NSBundle.MainBundle);

		CrmNotesResponse Data;

		protected NotesCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void ConfigureCell(CrmNotesResponse model) {
			Data = model;
			IBDateLbl.Text = Data.CreatedDate.ToString("d");
			IBNameLbl.Text = Data.CreatedBy;
		}

	}
}
