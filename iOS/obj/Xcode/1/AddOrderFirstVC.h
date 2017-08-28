// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <LucidX/LucidX.h>
#import <UIKit/UIKit.h>
#import <TPKeyboardAvoiding/TPKeyboardAvoiding.h>


@interface AddOrderFirstVC : UIViewController {
	UIButton *_BtnNext;
	UIToolbar *_IBAccountDoneBar;
	UIBarButtonItem *_IBAccountDoneBtn;
	UIPickerView *_IBAccountPicker;
	UIToolbar *_IBDateDoneBar;
	UIBarButtonItem *_IBDateDoneBtn;
	UIDatePicker *_IBDatePicker;
	UILabel *_LblAddresTitle;
	UILabel *_LblCurrencyTitle;
	UILabel *_LblDateTitle;
	UILabel *_LblOrderNameTitle;
	UILabel *_LblSelectAcoountTilte;
	TPKeyboardAvoidingScrollView *_Scrollvw;
	UITextView *_TxtAddress;
	UITextField *_TxtCurrency;
	UITextField *_TxtOrderDate;
	UITextField *_TxtOrderName;
	UITextField *_TxtSelectAcoountTilte;
}

@property (nonatomic, retain) IBOutlet UIButton *BtnNext;

@property (nonatomic, retain) IBOutlet UIToolbar *IBAccountDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBAccountDoneBtn;

@property (nonatomic, retain) IBOutlet UIPickerView *IBAccountPicker;

@property (nonatomic, retain) IBOutlet UIToolbar *IBDateDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *IBDateDoneBtn;

@property (nonatomic, retain) IBOutlet UIDatePicker *IBDatePicker;

@property (nonatomic, retain) IBOutlet UILabel *LblAddresTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblCurrencyTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblDateTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblOrderNameTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblSelectAcoountTilte;

@property (nonatomic, retain) IBOutlet TPKeyboardAvoidingScrollView *Scrollvw;

@property (nonatomic, retain) IBOutlet UITextView *TxtAddress;

@property (nonatomic, retain) IBOutlet UITextField *TxtCurrency;

@property (nonatomic, retain) IBOutlet UITextField *TxtOrderDate;

@property (nonatomic, retain) IBOutlet UITextField *TxtOrderName;

@property (nonatomic, retain) IBOutlet UITextField *TxtSelectAcoountTilte;

- (IBAction)BtnNextClicked:(id)sender;

- (IBAction)DatePickerValueChanged:(id)sender;

- (IBAction)IBDateDoneClicked:(id)sender;

- (IBAction)IBDoneClicked:(id)sender;

- (IBAction)TxtAcountEditingEnded:(id)sender;

@end
