// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface MailDetailsVC : UIViewController {
	UIButton *_IBBtmReplyBtn;
	UILabel *_IBBtmReplyLbl;
	UITextView *_IBContnTxt;
	UIButton *_IBForwardBtn;
	UILabel *_IBForwardLbl;
	UIButton *_IBInboxbtn;
	UIButton *_IBMenuBtn;
	UILabel *_IBNameIconLbl;
	UILabel *_IBNameLbl;
	UIButton *_IBReplyAllBtn;
	UILabel *_IBReplyAllLbl;
	UIButton *_IBReplyBtn;
	UILabel *_IBSubjectLbl;
}

@property (nonatomic, retain) IBOutlet UIButton *IBBtmReplyBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBBtmReplyLbl;

@property (nonatomic, retain) IBOutlet UITextView *IBContnTxt;

@property (nonatomic, retain) IBOutlet UIButton *IBForwardBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBForwardLbl;

@property (nonatomic, retain) IBOutlet UIButton *IBInboxbtn;

@property (nonatomic, retain) IBOutlet UIButton *IBMenuBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBNameIconLbl;

@property (nonatomic, retain) IBOutlet UILabel *IBNameLbl;

@property (nonatomic, retain) IBOutlet UIButton *IBReplyAllBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBReplyAllLbl;

@property (nonatomic, retain) IBOutlet UIButton *IBReplyBtn;

@property (nonatomic, retain) IBOutlet UILabel *IBSubjectLbl;

- (IBAction)ForwardBtnClicked:(id)sender;

- (IBAction)InboxBtnClicked:(id)sender;

- (IBAction)MenuBtnClicked:(id)sender;

- (IBAction)ReplyAllBtnClicked:(id)sender;

- (IBAction)ReplyBtnClicked:(id)sender;

@end
