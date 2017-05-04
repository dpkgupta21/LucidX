﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LucidX.Constants
{
    public class WebserviceConstants
    {
        public const string CONNECTION_NAME = "DEMOConneection";

        public const string TOKEN = "CE708CEA-65A6-40D4-B51F-C05ED6B10D58";
        public const string URL = "http://elucidateapi.azurewebsites.net/api/";

        public const int INBOX_EMAIL_TYPE_ID = 1;
        public const int DRAFT_EMAIL_TYPE_ID = 2;
        public const int SENT_EMAIL_TYPE_ID = 3;
        public const int TRASH_EMAIL_TYPE_ID = 4;


        public const string LOGIN_URL = "ModValidationsSvc/IsAuthenticatedUser?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string EMAIL_COUNT_URL = "ModDataGridsSvc/ShowEmailCounts?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string MARK_READ_EMAIL_URL = "ModMailSvc/EMarkReadMail?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string SHOW_INBOX_EMAILS_URL = "ModDataGridsSvc/ShowEmails?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string EMAIL_DETAILS_URL = "ModMailSvc/EGetEmailDetails?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string SHOW_NOTES_LIST_URL = "ModDataGridsSvc/ShowCrmNotesDirect?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string ADD_NOTES_URL = "ModDataGridsSvc/SaveCrmNotesDirect?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string DELETE_NOTES_URL = "ModDataGridsSvc/DeleteCrmNotesDirect?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string GET_ENTITY_CODES_URL = "ModDataGridsSvc/LoadAccounts?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string GET_ACCOUNT_CODES_URL = "ModDataGridsSvc/LoadAccountCodesByCompCode?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string SHOW_REF_USERS_URL = "ModDataGridsSvc/ShowRefUsers?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string SHOW_NOTES_TYPES ="ModDataGridsSvc/ShowNotesTypes?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string GET_CALENDAR_EVENTS= "ModDataGridsSvc/ShowCrmNotes?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string SAVE_CALENDAR_EVENTS = "ModDataGridsSvc/SaveCrmNotes?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";
        public const string DELETE_EVENTS_URL = "ModDataGridsSvc/DeleteCrmNotes?token=NixpkcMC4gKP3OIQA8hBJqv1ByZ4c+ffMYLb5mfDwFeWEQ7XEReLXA==";

    }
}
