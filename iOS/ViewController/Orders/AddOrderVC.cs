using System;
using System.Collections.Generic;
using LucidX.ResponseModels;
using UIKit;

namespace LucidX.iOS
{
	public partial class AddOrderVC : UIViewController
	{
		public LedgerOrder LedgerOrderObj { get; set; }

		AddOrderFirstVC addFirstVC;
		AddOrderSecond addTwoVC;
		AddOrderThird addThridVC;
		UIPageViewController pageVC;
		List<BaseAddOrderVC> ViewControllers = new List<BaseAddOrderVC>();
		public int index = 0;


		public AddOrderVC() : base("AddOrderVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}


		void ConfigureView()
		{
			if (LedgerOrderObj != null) {
				LedgerOrderObj = new LedgerOrder();
			}


			this.EdgesForExtendedLayout = UIRectEdge.None;

			pageVC = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll,
											  UIPageViewControllerNavigationOrientation.Horizontal,
											  UIPageViewControllerSpineLocation.Mid);

			addFirstVC = new AddOrderFirstVC();
			addTwoVC = new AddOrderSecond();
			addThridVC = new AddOrderThird();

			addFirstVC.SuperVC = this;
			addTwoVC.SuperVC = this;
			addThridVC.SuperVC = this;

			ViewControllers.Add(addFirstVC);
			ViewControllers.Add(addTwoVC);
			ViewControllers.Add(addThridVC);

			pageVC.View.Frame = new CoreGraphics.CGRect(0, 0,
														ContentVw.Frame.Width,
														ContentVw.Frame.Height);

			this.ContentVw.AddSubview(pageVC.View);
			this.AddChildViewController(pageVC);
			ChangePage();
		}

		public void ChangePage()
		{
			LblPageCount.Text = (index + 1) + "/" + ViewControllers.Count;
			pageVC.SetViewControllers(new UIViewController[] { ViewControllers[index] },
										  UIPageViewControllerNavigationDirection.Forward,
										  true, null);
		}

		partial void BtnPreClicked(Foundation.NSObject sender)
		{
			index--;
			ChangePage();
		}

	}
}

