// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <TPKeyboardAvoiding/TPKeyboardAvoiding.h>


@interface CreateNotesVC : UIViewController {
	UIToolbar *_IBAccountCodeDoneBar;
	UIPickerView *_IBAccountCodePicker;
	UILabel *_IBAccountCodeTitleLbl;
	UITextField *_IBAccountCodeTxt;
	UIBarButtonItem *_IBaccountDoneBtn;
	UIButton *_IBCancelBtn;
	UILabel *_IBEntityCodeTiltleLbl;
	UIToolbar *_IBEntityDoneBar;
	UIBarButtonItem *_IBEntityDoneBtn;
	UIPickerView *_IBEntityPicker;
	UITextField *_IBEntityTxt;
	UIButton *_IBMeBtn;
	UILabel *_IBNotesDetailsLbl;
	UITextView *_IBNotesDetailsTxt;
	UILabel *_IBNotesHeaderLbl;
	UITextField *_IBNotesHeaderTxt;
	UIButton *_IBPubicBtn;
	UIButton *_IBSaveBtn;
	UIButton *_IBSelectedBtn;
	TPKeyboardAvoidingScrollView *_ScrollVw;
}

@property (nonatomic, retain) IBOutlet UIToolbar *IBAccountCodeDoneBar;

@property (nonatomic, retain) IBOutlet UIPickerView *IBAccountCodePicker;

@property (nonatomic, retain) IBOutlet UILabel *IBAccountCodeTitleLbl;

@property (nonatomic, retain) IBOutlet UITextField *IBAccountCodeTxt;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBaccountDoneBtn;

@property (nonatomic, retain) IBOutlet UIButton *IBCancelBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBEntityCodeTiltleLbl;

@property (nonatomic, retain) IBOutlet UIToolbar *IBEntityDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBEntityDoneBtn;

@property (nonatomic, retain) IBOutlet UIPickerView *IBEntityPicker;

@property (nonatomic, retain) IBOutlet UITextField *IBEntityTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBMeBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBNotesDetailsLbl;

@property (nonatomic, retain) IBOutlet UITextView *IBNotesDetailsTxt;

@property (nonatomic, retain) IBOutlet UILabel *IBNotesHeaderLbl;

@property (nonatomic, retain) IBOutlet UITextField *IBNotesHeaderTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBPubicBtn;

@property (nonatomic, retain) IBOutlet UIButton *IBSaveBtn;

@property (nonatomic, retain) IBOutlet UIButton *IBSelectedBtn;

@property (nonatomic, retain) IBOutlet TPKeyboardAvoidingScrollView *ScrollVw;

- (IBAction)BtnCancelClicked:(id)sender;

- (IBAction)BtnSaveClicked:(id)sender;

- (IBAction)IBAccountDoneClicked:(id)sender;

- (IBAction)IBEntityDoneClicked:(id)sender;

- (IBAction)IBRadioBtnClicked:(id)sender;

@end
