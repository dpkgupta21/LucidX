using System;
using UIKit;
using Plugin.Connectivity;
using Xamarin.SWRevealViewController;
using WSI_NintaBlackBoxAlert_App.Lib.RestApis;
using WSI_NintaBlackBoxAlert_App.Lib.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WSI_NintaBlackBoxAlert_App.iOS
{
	public partial class HomeVC : UIViewController
	{
		public string number;
		public SWRevealViewController revealVC;

		public bool BtnToogle;

		public HomeVC() : base("HomeVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			UpdateNumber();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


		#region Helping Methods

		/// <summary>
		/// Configures the view.
		/// </summary>
		void ConfigureView()
		{
			this.EdgesForExtendedLayout = UIRectEdge.None;
			this.NavigationItem.Title = "";
			IBSendAlertLbl.Text = "Send Alert";
			IBCopyRightLbl.Text = StringConstants.Instance.CopyRightText;
			IBCopyRightLbl.AdjustsFontSizeToFitWidth = true;
			var menuBtn = new UIBarButtonItem(UIImage.FromBundle("Menu"),
											  UIBarButtonItemStyle.Plain,
			                                  MenuClicked);
			this.NavigationItem.LeftBarButtonItem = menuBtn;
		}

		/// <summary>
		/// Updates the number label value.
		/// </summary>
		void UpdateNumber()
		{
			IBNumberLbl.Text = Regex.Replace(UserDefaultManager.Instance.Number,
			                                 @"(\d{3})(\d{3})(\d{4})(\d{9})",
			                                 "($1)$2-$3-$4");
		}

		/// <summary>
		/// call api to send alert
		/// </summary>
		async void SendAlert()
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				var alert = new UIAlertView(StringConstants.Instance.No_Connection_Title,
											StringConstants.Instance.No_Connection_Msg,
											null,
											StringConstants.Instance.Ok_Title);
				alert.Show();
			}
			else {
				ToogleView();
				var response = await RestApiMethods.SendAlert(UserDefaultManager.Instance.Number);
				if (response != null && response.StatusCode == 0)
				{
					IBSendAlertLbl.Text = response.Message;
				}
				else if (response != null)
				{
					IBSendAlertLbl.Text = response.Message;

				}
				else {
					IBSendAlertLbl.Text = StringConstants.Instance.UnHandledError_Msg;
				}
				await Task.Delay(2000);
				ToogleView();
			}

		}

		/// <summary>
		/// Toogles the view between SendAlert and SentAlert.
		/// </summary>
		void ToogleView()
		{

			if (BtnToogle)
			{
				IBBtnLeadingSpaceConstarint.Constant = 30;
				IBBtntrailingSpaceConstarint.Constant = 30;
				IBSendAlertLbl.Text = StringConstants.Instance.SendAlert;

				UIView.Animate(0.1, () => { IBBtn1Vw.LayoutIfNeeded(); });

				IBRoundBtnImg.Highlighted = false;
				BtnToogle = false;
			}
			else {
				IBBtnLeadingSpaceConstarint.Constant = 0;
				IBBtntrailingSpaceConstarint.Constant = 0;
				IBSendAlertLbl.Text = StringConstants.Instance.AlertSending;
				UIView.Animate(0.1, () => { IBBtn1Vw.LayoutIfNeeded(); });
				IBRoundBtnImg.Highlighted = true;
				BtnToogle = true;
			}
		}
		#endregion

		#region IBAction Methods

		partial void IBSendAlertClicked(Foundation.NSObject sender)
		{
			SendAlert();
		}

		void MenuClicked(object sender, EventArgs e)
		{
			if (!BtnToogle)
				revealVC.RevealToggleAnimated(true);
		}

		#endregion

	}
}