// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface AddOrderSecondTVCell : UITableViewCell {
	UIButton *_BtnDelete;
	UIButton *_BtnEdit;
	UILabel *_LblAccountNameTilte;
	UILabel *_LblAccountNameValue;
	UILabel *_LblBaseAmountTitle;
	UILabel *_LblBaseAmountValue;
	UILabel *_LblItemTitle;
	UILabel *_LblTaxTitle;
	UILabel *_LblTaxValue;
}

@property (nonatomic, retain) IBOutlet UIButton *BtnDelete;

@property (nonatomic, retain) IBOutlet UIButton *BtnEdit;

@property (nonatomic, retain) IBOutlet UILabel *LblAccountNameTilte;

@property (nonatomic, retain) IBOutlet UILabel *LblAccountNameValue;

@property (nonatomic, retain) IBOutlet UILabel *LblBaseAmountTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblBaseAmountValue;

@property (nonatomic, retain) IBOutlet UILabel *LblItemTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblTaxTitle;

@property (nonatomic, retain) IBOutlet UILabel *LblTaxValue;

- (IBAction)BtndeleteClicked:(id)sender;

- (IBAction)BtnEditClicked:(id)sender;

@end
