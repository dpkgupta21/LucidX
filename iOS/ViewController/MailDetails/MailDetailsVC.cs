using System;
using Foundation;
using UIKit;
using LucidX.ResponseModels;
using LucidX.Webservices;
namespace MailDetails
{
	public partial class MailDetailsVC : UIViewController
	{
		public EmailResponse mail;
		public MailDetailsVC() : base("MailDetailsVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.EdgesForExtendedLayout = UIRectEdge.None;
			ConfigureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		#region Helping Methods

		void ConfigureView()
		{
			IBNameLbl.Text = mail.SenderName;
			IBSubjectLbl.Text = mail.Subject;
			IBNameIconLbl.Text = mail.SenderName[0].ToString();
			GetDetails();
		}

		async void GetDetails()
		{
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				var desc = await WebServiceMethods.EmailDetail(mail.MailId, IosUtils.Settings.UserId);
				if (desc != null)
				{
					IBContnTxt.AttributedText = GetAttributedStringFromHtml(desc);
				}
				IosUtils.Utility.hideProgressHud();
			}
		}

		#endregion

		/// <summary>
		/// Gets the attributed string from html-string.
		/// </summary>
		/// <returns>The attributed string from html.</returns>
		/// <param name="html">Html.</param>
		NSAttributedString GetAttributedStringFromHtml(string html)
		{
			NSError error = null;
			NSAttributedString attributedString = new NSAttributedString(NSData.FromString(html),
				new NSAttributedStringDocumentAttributes { DocumentType = NSDocumentType.HTML, StringEncoding = NSStringEncoding.UTF8 },
				ref error);
			return attributedString;
		}

	}
}

