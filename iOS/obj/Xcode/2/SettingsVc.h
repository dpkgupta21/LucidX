// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface SettingsVc : UIViewController {
	UITableView *_IBContntTbl;
	UILabel *_IBMailAddLbl;
	UILabel *_IBNameLbl;
	UIImageView *_IBProfileImg;
	UIView *_IBProfileVw;
}

@property (nonatomic, retain) IBOutlet UITableView *IBContntTbl;

@property (nonatomic, retain) IBOutlet UILabel *IBMailAddLbl;

@property (nonatomic, retain) IBOutlet UILabel *IBNameLbl;

@property (nonatomic, retain) IBOutlet UIImageView *IBProfileImg;

@property (nonatomic, retain) IBOutlet UIView *IBProfileVw;

- (IBAction)CloseBtnClicked:(id)sender;

- (IBAction)IBCalendarClicked:(id)sender;

- (IBAction)IBDraftClicked:(id)sender;

- (IBAction)IBInboxClicked:(id)sender;

- (IBAction)IBInvoiceClicked:(id)sender;

- (IBAction)IBSentClicked:(id)sender;

- (IBAction)IBTrashClicked:(id)sender;

@end
