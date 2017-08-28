// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface MultiSelectionDialog : UIView {
	UIView *_ContntVw;
	UIButton *_IBCancelBtn;
	UITableView *_IBContntTable;
	UIButton *_IBSaveBtn;
	UILabel *_IBTtitleLbl;
}

@property (nonatomic, retain) IBOutlet UIView *ContntVw;

@property (nonatomic, retain) IBOutlet UIButton *IBCancelBtn;

@property (nonatomic, retain) IBOutlet UITableView *IBContntTable;

@property (nonatomic, retain) IBOutlet UIButton *IBSaveBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBTtitleLbl;

- (IBAction)IBCancelClicked:(id)sender;

- (IBAction)IBSaveClicked:(id)sender;

@end
