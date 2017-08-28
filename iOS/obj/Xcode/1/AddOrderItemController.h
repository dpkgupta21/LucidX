// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <TPKeyboardAvoiding/TPKeyboardAvoiding.h>


@interface AddOrderItemController : UIViewController {
	UIToolbar *_AmountDoneBar;
	UIBarButtonItem *_AmountDoneBtn;
	UIButton *_BtnCancel;
	UIButton *_BtnDelete;
	UIButton *_BtnOk;
	UIBarButtonItem *_BtnRevenueDone;
	UIBarButtonItem *_BtnTaxDone;
	UILabel *_LblAmount;
	UILabel *_LblDescription;
	UILabel *_LblRevenue;
	UILabel *_LblTaxType;
	UILabel *_LblTitle;
	UILabel *_LblVat;
	UIToolbar *_RevenueDoneBar;
	UIPickerView *_RevenuePicker;
	TPKeyboardAvoidingScrollView *_ScrollVw;
	UIPickerView *_TaxtTypePicker;
	UIToolbar *_TaxTypeDoneBar;
	UITextField *_TxtAmount;
	UITextField *_TxtDescription;
	UITextField *_TxtRevenue;
	UITextField *_TxtTaxType;
	UITextField *_TxtVat;
}
@property (retain, nonatomic) IBOutlet UIButton *BtnClose;
- (IBAction)BtnCloseClicked:(id)sender;

@property (nonatomic, retain) IBOutlet UIToolbar *AmountDoneBar;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *AmountDoneBtn;

@property (nonatomic, retain) IBOutlet UIButton *BtnCancel;

@property (nonatomic, retain) IBOutlet UIButton *BtnDelete;

@property (nonatomic, retain) IBOutlet UIButton *BtnOk;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *BtnRevenueDone;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *BtnTaxDone;

@property (nonatomic, retain) IBOutlet UILabel *LblAmount;

@property (nonatomic, retain) IBOutlet UILabel *LblDescription;

@property (nonatomic, retain) IBOutlet UILabel *LblRevenue;

@property (nonatomic, retain) IBOutlet UILabel *LblTaxType;

@property (nonatomic, retain) IBOutlet UILabel *LblTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblVat;

@property (nonatomic, retain) IBOutlet UIToolbar *RevenueDoneBar;

@property (nonatomic, retain) IBOutlet UIPickerView *RevenuePicker;

@property (nonatomic, retain) IBOutlet TPKeyboardAvoidingScrollView *ScrollVw;

@property (nonatomic, retain) IBOutlet UIPickerView *TaxtTypePicker;

@property (nonatomic, retain) IBOutlet UIToolbar *TaxTypeDoneBar;

@property (nonatomic, retain) IBOutlet UITextField *TxtAmount;

@property (nonatomic, retain) IBOutlet UITextField *TxtDescription;

@property (nonatomic, retain) IBOutlet UITextField *TxtRevenue;

@property (nonatomic, retain) IBOutlet UITextField *TxtTaxType;

@property (nonatomic, retain) IBOutlet UITextField *TxtVat;

- (IBAction)AmountDoneClicked:(id)sender;

- (IBAction)AmountEditingEnded:(id)sender;

- (IBAction)BtnDeleteClicked:(id)sender;

- (IBAction)BtnOkClicked:(id)sender;

- (IBAction)CancelClicked:(id)sender;

- (IBAction)RevenueDoneClicked:(id)sender;

- (IBAction)RevenueEditingEnded:(id)sender;

- (IBAction)TaxDoneClicked:(id)sender;

- (IBAction)TaxTypeEditingEnded:(id)sender;

@end
