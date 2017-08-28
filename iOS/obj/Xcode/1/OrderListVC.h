// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface OrderListVC : UIViewController {
	UITableView *_IBContntTbl;
	UIToolbar *_IBDateDoneBar;
	UIDatePicker *_IBDatePicker;
	UITextField *_IBEndDateTxt;
	UIButton *_IBSearchBtn;
	UITextField *_IBStartDateTxt;
	UILabel *_IBToLbl;
}

@property (nonatomic, retain) IBOutlet UITableView *IBContntTbl;

@property (nonatomic, retain) IBOutlet UIToolbar *IBDateDoneBar;

@property (nonatomic, retain) IBOutlet UIDatePicker *IBDatePicker;

@property (nonatomic, retain) IBOutlet UITextField *IBEndDateTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBSearchBtn;

@property (nonatomic, retain) IBOutlet UITextField *IBStartDateTxt;

@property (nonatomic, retain) IBOutlet UILabel *IBToLbl;

- (IBAction)DoneClicked:(id)sender;

- (IBAction)IBDateChanged:(id)sender;

- (IBAction)IBSearchClicked:(id)sender;

@end
