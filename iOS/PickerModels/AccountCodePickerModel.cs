using System;
using System.Collections.Generic;
using UIKit;
using LucidX.ResponseModels;

namespace LucidX.iOS.PickerModels
{
	public class AccountCodePickerModel: UIPickerViewModel
	{
		public string currentTextFieldValue;
		UITextField txtField;
		public List<AccountCodesResponse> lstDropDownData = new List<AccountCodesResponse>();

		public AccountCodePickerModel(List<AccountCodesResponse> data, UITextField txt)
		{
			lstDropDownData.AddRange(data);
			txtField = txt;
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			if (lstDropDownData == null)
				return 0;

			return lstDropDownData.Count;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			var model = lstDropDownData[(int)row];
			return model.AccountCode;
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			if (lstDropDownData == null || lstDropDownData.Count == 0)
				return;
			var model = lstDropDownData[(int)row];
			txtField.Text = model.AccountCode;
		}

	}
}
