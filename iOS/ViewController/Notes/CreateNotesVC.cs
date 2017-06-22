using System;

using UIKit;

namespace LucidX.iOS.Notes
{
	public partial class CreateNotesVC : UIViewController
	{
		public CreateNotesVC() : base("CreateNotesVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}



		void ConfigureView() { 
		
		
		}
	}
}

