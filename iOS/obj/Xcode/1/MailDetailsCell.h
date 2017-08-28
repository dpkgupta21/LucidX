// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface MailDetailsCell : UITableViewCell {
	UILabel *_IBDateTimeLbl;
	UIButton *_IBDeleteBtn;
	UILabel *_IBDescLbl;
	UILabel *_IBMailAddressLbl;
	UILabel *_IBTitleLbl;
}

@property (nonatomic, retain) IBOutlet UILabel *IBDateTimeLbl;

@property (nonatomic, retain) IBOutlet UIButton *IBDeleteBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBDescLbl;

@property (nonatomic, retain) IBOutlet UILabel *IBMailAddressLbl;

@property (nonatomic, retain) IBOutlet UILabel *IBTitleLbl;

- (IBAction)IBDeleteBtnClicked:(id)sender;

@end
