// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface CreateCalendarEventVC : UIViewController {
	UIToolbar *_IBAssignedToDoneBar;
	UIBarButtonItem *_IBAssignedToDoneBtn;
	UIPickerView *_IBAssignedToPicker;
	UITextField *_IBAssignedToTxt;
	UIButton *_IBCancelBtn;
	UIToolbar *_IBDateTimeDoneBar;
	UIBarButtonItem *_IBDateTimeDoneBtn;
	UIDatePicker *_IBDateTimePicker;
	UILabel *_IBDetailsLbl;
	UITextView *_IBDetailsTxt;
	UIBarButtonItem *_IBEventTypeBtn;
	UIToolbar *_IBEventTypeDoneBar;
	UIPickerView *_IBEventTypePicker;
	UITextField *_IBEventTypeTxt;
	UILabel *_IBFromDateTimeLbl;
	UITextField *_IBFromDateTxt;
	UIButton *_IBSaveBtn;
	UILabel *_IBSubjectLbl;
	UITextField *_IBSubjectTxt;
	UILabel *_IBToDateTimeLbl;
	UITextField *_IBToDateTxt;
}

@property (nonatomic, retain) IBOutlet UIToolbar *IBAssignedToDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBAssignedToDoneBtn;

@property (nonatomic, retain) IBOutlet UIPickerView *IBAssignedToPicker;

@property (nonatomic, retain) IBOutlet UITextField *IBAssignedToTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBCancelBtn;

@property (nonatomic, retain) IBOutlet UIToolbar *IBDateTimeDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBDateTimeDoneBtn;

@property (nonatomic, retain) IBOutlet UIDatePicker *IBDateTimePicker;

@property (nonatomic, retain) IBOutlet UILabel *IBDetailsLbl;

@property (nonatomic, retain) IBOutlet UITextView *IBDetailsTxt;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBEventTypeBtn;

@property (nonatomic, retain) IBOutlet UIToolbar *IBEventTypeDoneBar;

@property (nonatomic, retain) IBOutlet UIPickerView *IBEventTypePicker;

@property (nonatomic, retain) IBOutlet UITextField *IBEventTypeTxt;

@property (nonatomic, retain) IBOutlet UILabel *IBFromDateTimeLbl;

@property (nonatomic, retain) IBOutlet UITextField *IBFromDateTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBSaveBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBSubjectLbl;

@property (nonatomic, retain) IBOutlet UITextField *IBSubjectTxt;

@property (nonatomic, retain) IBOutlet UILabel *IBToDateTimeLbl;

@property (nonatomic, retain) IBOutlet UITextField *IBToDateTxt;

- (IBAction)BtnCancelClicked:(id)sender;

- (IBAction)BtnSaveClicked:(id)sender;

- (IBAction)IBAssignedToDoneClicked:(id)sender;

- (IBAction)IBDateTimeDoneClicked:(id)sender;

- (IBAction)IBEventTypeDoneClicked:(id)sender;

@end
