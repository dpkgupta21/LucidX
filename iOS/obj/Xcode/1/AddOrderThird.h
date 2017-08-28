// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <LucidX/LucidX.h>
#import <UIKit/UIKit.h>


@interface AddOrderThird : UIViewController {
	UIButton *_BtnCancel;
	UIButton *_BtnSave;
	UILabel *_LblGross;
	UILabel *_LblNet;
	UILabel *_LblVat;
	UITextField *_TxtGross;
	UITextField *_TxtNet;
	UITextField *_txtVat;
}

@property (nonatomic, retain) IBOutlet UIButton *BtnCancel;

@property (nonatomic, retain) IBOutlet UIButton *BtnSave;

@property (nonatomic, retain) IBOutlet UILabel *LblGross;

@property (nonatomic, retain) IBOutlet UILabel *LblNet;

@property (nonatomic, retain) IBOutlet UILabel *LblVat;

@property (nonatomic, retain) IBOutlet UITextField *TxtGross;

@property (nonatomic, retain) IBOutlet UITextField *TxtNet;

@property (nonatomic, retain) IBOutlet UITextField *txtVat;

- (IBAction)BtnCancelClicked:(id)sender;

- (IBAction)BtnSaveClicked:(id)sender;

@end
