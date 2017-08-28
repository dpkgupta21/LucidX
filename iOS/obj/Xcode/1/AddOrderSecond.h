// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <LucidX/LucidX.h>
#import <UIKit/UIKit.h>


@interface AddOrderSecond : UIViewController {
	UIButton *_BtnAdd;
	UIButton *_BtnNext;
	UITableView *_ContntTbl;
}

@property (nonatomic, retain) IBOutlet UIButton *BtnAdd;

@property (nonatomic, retain) IBOutlet UIButton *BtnNext;

@property (nonatomic, retain) IBOutlet UITableView *ContntTbl;

- (IBAction)BtnAddClicked:(id)sender;

- (IBAction)BtnNextClicked:(id)sender;

@end
