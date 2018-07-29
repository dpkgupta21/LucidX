// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface CalendarVC : UIViewController {
	UIToolbar *_IBAssignedDoneBar;
	UIBarButtonItem *_IBAssignedDoneBtn;
	UIPickerView *_IBAssignedToPicker;
	UITextField *_IBAssignedToTxt;
	UITextField *_IBCalendarTypeTxt;
	UITableView *_IBContntTbl;
	UIToolbar *_IBDateTimeDoneBar;
	UIBarButtonItem *_IBDateTimeDoneBttn;
	UIDatePicker *_IBDateTimePicker;
	UILabel *_IBEmptyLbl;
	UITextField *_IBFromDateTxt;
	UIButton *_IBSearchBtn;
	UITextField *_IBToDateTxt;
	UILabel *_IBToLbl;
}

@property (nonatomic, retain) IBOutlet UIToolbar *IBAssignedDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBAssignedDoneBtn;

@property (nonatomic, retain) IBOutlet UIPickerView *IBAssignedToPicker;

@property (nonatomic, retain) IBOutlet UITextField *IBAssignedToTxt;

@property (nonatomic, retain) IBOutlet UITextField *IBCalendarTypeTxt;

@property (nonatomic, retain) IBOutlet UITableView *IBContntTbl;

@property (nonatomic, retain) IBOutlet UIToolbar *IBDateTimeDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBDateTimeDoneBttn;

@property (nonatomic, retain) IBOutlet UIDatePicker *IBDateTimePicker;

@property (nonatomic, retain) IBOutlet UILabel *IBEmptyLbl;

@property (nonatomic, retain) IBOutlet UITextField *IBFromDateTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBSearchBtn;

@property (nonatomic, retain) IBOutlet UITextField *IBToDateTxt;

@property (nonatomic, retain) IBOutlet UILabel *IBToLbl;

- (IBAction)IBAssignedDoneClicked:(id)sender;

- (IBAction)IBDateTimeDoneClicked:(id)sender;

- (IBAction)SearchClicked:(id)sender;

@end
